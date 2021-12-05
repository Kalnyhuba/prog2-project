using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Buttons
    public Button DealButton;
    public Button HitButton;
    public Button StandButton;
    public Button QuitButton;

    // Texts
    public Text StandButtonText;
    public Text PlayerHandText;
    public Text DealerHandText;
    public Text MainText;

    // The dealer's hidden card object, until the round is over
    public GameObject HiddenCard;

    // The number of times the stand button is pushed
    private int NumberOfStands = 0;

    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    void Start()
    {
        // On-click listeners to the buttons using lambda functions
        DealButton.onClick.AddListener(() => DealClicked());
        HitButton.onClick.AddListener(() => HitClicked());
        StandButton.onClick.AddListener(() => StandClicked());
        QuitButton.onClick.AddListener(() => QuitGame());
    }

    // The actions taken when the deal button is pushed
    private void DealClicked()
    {
        playerScript.Reset();
        dealerScript.Reset();

        // Shuffling the cards, giving two cards to the player and dealer as well
        MainText.gameObject.SetActive(false);
        DealerHandText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();

        // Displaying the current hand value
        PlayerHandText.text = "Value of hand: " + playerScript.HandValue.ToString();
        DealerHandText.text = "Dealer's hand: " + dealerScript.HandValue.ToString();

        HiddenCard.GetComponent<Renderer>().enabled = true;
        // Button visibility
        DealButton.gameObject.SetActive(false);
        HitButton.gameObject.SetActive(true);
        StandButton.gameObject.SetActive(true);
        StandButtonText.text = "Stand";
    }

    // The actions taken when the hit button is pushed
    private void HitClicked()
    {
        // Giving cards to the player up to 10
        if (playerScript.CardIndex <= 10)
        {
            playerScript.GetCard();
            PlayerHandText.text = "Value of hand: " + playerScript.HandValue.ToString();

            if (playerScript.HandValue > 20)
            {
                RoundEnd();
            }
        }
    }

    // The actions taken when the stand button is pushed
    private void StandClicked()
    {
        NumberOfStands++;
        if (NumberOfStands > 1)
        {
            RoundEnd();
        }

        HitDealer();
        StandButtonText.text = "Call";
    }

    // Blackjack rule: if the dealer is below 16 he has to hit until at least 16 in value
    private void HitDealer()
    {
        while (dealerScript.HandValue < 16 && dealerScript.CardIndex < 10)
        {
            dealerScript.GetCard();
            DealerHandText.text = "Dealer's hand: " + dealerScript.HandValue.ToString();

            if (dealerScript.HandValue > 20)
            {
                RoundEnd();
            }
        }
    }

    void RoundEnd()
    {
        // Booleans for ending the round with different outcomes
        bool playerBust = playerScript.HandValue > 21;
        bool dealerBust = dealerScript.HandValue > 21;
        bool playerBlackJack = playerScript.HandValue == 21;
        bool dealerBlackJack = dealerScript.HandValue == 21;

        if (NumberOfStands < 2 && !playerBust && !dealerBust && !playerBlackJack && !dealerBlackJack) return;

        // The different outcomes and their text written in the main text object
        bool roundOver = true;
        if (playerBust && dealerBust)
        {
            MainText.text = "Both Player and Dealer busted";
        }
        else if (playerBust || (!dealerBust && dealerScript.HandValue > playerScript.HandValue))
        {
            MainText.text = "Dealer won!";
        }
        else if (dealerBust || playerScript.HandValue > dealerScript.HandValue)
        {
            MainText.text = "You won!";
        }
        else if (playerScript.HandValue == dealerScript.HandValue)
        {
            MainText.text = "You and the Dealer tied!";
        }
        else
        {
            roundOver = false;
        }

        // When the round has ended setting the stage for the next round, adjusting the game object accordingly
        if (roundOver)
        {
            HitButton.gameObject.SetActive(false);
            StandButton.gameObject.SetActive(false);
            DealButton.gameObject.SetActive(true);
            MainText.gameObject.SetActive(true);
            DealerHandText.gameObject.SetActive(true);
            HiddenCard.GetComponent<Renderer>().enabled = false;
            NumberOfStands = 0;
        }
        
    }

    // Quitting the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

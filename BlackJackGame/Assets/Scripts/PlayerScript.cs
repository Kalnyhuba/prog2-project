using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CardScript cardScript;
    public DeckScript deckScript;

    public int HandValue = 0;

    public GameObject[] hand;

    public int CardIndex = 0;

    List<CardScript> AceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Getting the cards one by one, and assigning the values of them to the hand of the player, checking for aces in the process
    public int GetCard()
    {
        int CardValue = deckScript.DealCard(hand[CardIndex].GetComponent<CardScript>());
        hand[CardIndex].GetComponent<Renderer>().enabled = true;

        HandValue += CardValue;

        if(CardValue == 1)
        {
            AceList.Add(hand[CardIndex].GetComponent<CardScript>());
        }

        AceCheck();
        CardIndex++;

        return HandValue;
    }

    // Setting the value of the aces in hand, according to the current hand value, if it would exceed 21 then the ace is 1, if it would'nt exceed 21, then the ace will be 11
    public void AceCheck()
    {
        foreach (CardScript Ace in AceList)
        {
            if (HandValue + 10 < 22 && Ace.GetValue() == 1)
            {
                Ace.SetValue(11);
                HandValue += 10;
            }
            else if (HandValue > 21 && Ace.GetValue() == 11)
            {
                Ace.SetValue(1);
                HandValue -= 10;
            }
        }
    }

    // Resetting the hand
    public void Reset()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }

        CardIndex = 0;
        HandValue = 0;
        AceList = new List<CardScript>();
    }
}

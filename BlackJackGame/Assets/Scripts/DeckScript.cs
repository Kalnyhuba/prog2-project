using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System;
using System.Linq;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardArray;
    int[] cardValues = new int[53];
    int CurrentIndex = 0;

    public void Start()
    {
        GetValues();
    }

    void GetValues()
    {
        int number = 0;

        //Give values to the cards using the modulo operator
        for (int i = 0; i < cardArray.Length; i++)
        {
            number = i;
            number %= 13;

            if(number > 10 || number == 0)
            {
                number = 10;
            }
            cardValues[i] = number++;
        }
    }

    public void Shuffle()
    {
        // Shuffling the cards using a randomizer method
        for(int i = cardArray.Length -1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(UnityEngine.Random.Range(0.0f, 1.0f) * cardArray.Length - 1) + 1;
            
            Sprite face = cardArray[i];
            cardArray[i] = cardArray[j];
            cardArray[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        CurrentIndex = 1;
    }

    public int DealCard(CardScript cardScript)
    {
        // Setting the values of the current dealt card, and actually setting a 2D graphical Sprite object to it to represent it 
        cardScript.SetSprite(cardArray[CurrentIndex]);
        cardScript.SetValue(cardValues[CurrentIndex]);
        CurrentIndex++;
        return cardScript.GetValue();
    }

    public Sprite GetCardBack()
    {
        return cardArray[0];
    }
}

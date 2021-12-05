using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    private int value = 0;

    // Getter and setter to assign values to the cards
    public int GetValue()
    {
        return value;
    }

    public void SetValue(int val)
    {
        value = val;
    }

    // Setting Sprite objects to represent the cards graphically
    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        Sprite back = GameObject.Find("Deck").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }

}

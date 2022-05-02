using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fichas : MonoBehaviour
{
    [SerializeField] private int id;

    [SerializeField] private CardManager cardManager;

    private bool isFlipped = false;
    private bool discovered = false;

    private Quaternion flippedRotation = Quaternion.Euler(180, 0, 0);
    private Quaternion originalRotation = Quaternion.Euler(0, 0, 0);

    private void Update()
    {
        RotateCard();
    }

    private void OnMouseDown()
    {
        if (cardManager.GetFlippedCardsCount() < 2 && !discovered)
        {
            if (!isFlipped)
            {
                isFlipped = true;
                cardManager.flippedCardsCount++;
            }
            else
            {
                isFlipped = false;
                cardManager.flippedCardsCount--;
            }
        }
    }

    private void RotateCard()
    {
        if (isFlipped || discovered)
        {
            transform.rotation = flippedRotation;
        }    
        else
        {
            transform.rotation = originalRotation;
        }
    }

    public void SetIsFlipped(bool isFlipped)
    {
        this.isFlipped = isFlipped;
    }

    public bool GetIsFlipped()
    {
        return isFlipped;
    }

    public int GetID()
    {
        return id;
    }

    public void SetIsDiscovered(bool isDiscovered)
    {
        discovered = isDiscovered;
    }
}

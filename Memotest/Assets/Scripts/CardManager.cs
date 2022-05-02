using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Fichas[] cards;

    private List<Fichas> cardsToCompare = new List<Fichas>();

    public int flippedCardsCount = 0;

    private int cardsCount = 10;

    private void Update()
    {
        CompareCards();
    }

    private void CompareCards()
    {
        for (int i = 0; i < cardsCount; i++)
        {
            if (cards[i].GetIsFlipped())
            {
                cardsToCompare.Add(cards[i]);
            }
        }

        if (cardsToCompare.Count == 2)
        {
            if (cardsToCompare[0].GetID() == cardsToCompare[1].GetID())
            {
                cardsToCompare[0].SetIsDiscovered(true);
                cardsToCompare[1].SetIsDiscovered(true);
                cardsToCompare[0].SetIsFlipped(false);
                cardsToCompare[1].SetIsFlipped(false);
                cardsToCompare.Clear();
            }
            else
            {
                flippedCardsCount = 3;
                StartCoroutine(ReverseCard(cardsToCompare[0], cardsToCompare[1]));
            }
            cardsToCompare.Clear();
        }
    }

    public int GetFlippedCardsCount()
    {
        return flippedCardsCount;
    }

    private IEnumerator ReverseCard(Fichas card1, Fichas card2)
    {
        yield return new WaitForSeconds(2.0f);
        cardsToCompare[0].SetIsFlipped(false);
        cardsToCompare[1].SetIsFlipped(false);
        flippedCardsCount = 0;
        cardsToCompare.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fichas : MonoBehaviour
{
    public bool facedUp, locked;
    public static bool coroutineAllowed;

    private Fichas firstInPair, secondInPair;
    private string firstInPairName, secondInPairName;

    public static Queue<Fichas> sequence;

    public static int pairsFound;

    public static GameObject winText;

    private void Start()
    {
        facedUp = false;
        coroutineAllowed = true;
        locked = false;
        sequence = new Queue<Fichas>();
        pairsFound = 0;

        if (winText == null)
        {
            winText = GameObject.Find("WinText");
            winText.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!locked && coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    public IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!facedUp)
        {
            sequence.Enqueue(this);
            for (float i = 0f; i <= 180f; i += 10)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
        }
        else if (facedUp)
        {
            for (float i = 180f; i >= 0f; i -= 10)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
                sequence.Clear();
            }
        }

        coroutineAllowed = true;

        facedUp = !facedUp;

        if (sequence.Count == 2)
        {
            CheckResults();
        }
    }

    private void CheckResults()
    {
        firstInPair = sequence.Dequeue();
        secondInPair = sequence.Dequeue();

        firstInPairName = firstInPair.name.Substring(0, firstInPair.name.Length - 1);
        secondInPairName = secondInPair.name.Substring(0, secondInPair.name.Length - 1);

        if (firstInPairName == secondInPairName)
        {
            firstInPair.locked = true;
            secondInPair.locked = true;
            pairsFound += 1;
        }
        else
        {
            firstInPair.StartCoroutine("RotateBack");
            secondInPair.StartCoroutine("RotateBack");
        }
    }

    public IEnumerator RotateBack()
    {
        coroutineAllowed = false;
        yield return new WaitForSeconds(0.2f);
        for (float i = 180f; i >= 0f; i -= 10)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            yield return new WaitForSeconds(0f);
            sequence.Clear();
        }
        facedUp = false;
        coroutineAllowed = true;
    }
}

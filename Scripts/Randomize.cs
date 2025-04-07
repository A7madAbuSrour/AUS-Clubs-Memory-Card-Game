using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    [SerializeField] private List<CardScript> cardList = new List<CardScript>();
    [SerializeField] private List<Vector2> transformList = new List<Vector2>();
    void Start()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            int pos = Random.Range(0, transformList.Count);
            cardList[i].transform.position = transformList[pos];
            transformList.RemoveAt(pos);
        }

        StartCoroutine(Memorize());
    }

    private IEnumerator Memorize()
    {
        for (int i = 0; i < cardList.Count; i++) 
        {
            cardList[i].Flip();
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < cardList.Count; i++)
        {
            cardList[i].FlipBack();
        }
    }
}

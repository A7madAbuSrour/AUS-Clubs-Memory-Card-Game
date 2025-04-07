using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public Sprite frontSprite;  
    public Sprite backSprite;
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;
    private bool isMatched = false;
    public Game_Manager gm;
    public AudioSource mySource;
    public AudioClip myClip;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backSprite;
    }

    void OnMouseDown()
    {
        if (!isFlipped && !isMatched && gm.flippedCards.Count < 2) // Prevent flipping more than 2 cards at once
        {
            Flip();
            gm.CardFlipped(this);
            mySource.PlayOneShot(myClip);
        }
    }

    public void Flip()
    {
        spriteRenderer.sprite = frontSprite;
        isFlipped = true;
    }

    public void FlipBack()
    {
        spriteRenderer.sprite = backSprite;
        isFlipped = false;
    }

    public void Matched()
    {
        isMatched = true; // Keeps the card flipped permanently
    }
}
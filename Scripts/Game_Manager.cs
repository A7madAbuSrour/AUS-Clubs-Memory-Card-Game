using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public List<CardScript> flippedCards = new List<CardScript>();
    public Text myScore;
    int score = 0;
    int count = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Update()
    {
        if(count == 6)
        {
            StartCoroutine(BacktoMenu());
        }
    }
    public void CardFlipped(CardScript card)
    {
        flippedCards.Add(card);

        if (flippedCards.Count == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f); // Delay to show both cards before flipping back

        if (flippedCards[0].frontSprite == flippedCards[1].frontSprite)
        {
            // Match found, keep them flipped
            flippedCards[0].Matched();
            flippedCards[1].Matched();
            score++;
            count++;
            UpdateScoreDisplay();
        }
        else
        {
            // Not matching, flip them back
            flippedCards[0].FlipBack();
            flippedCards[1].FlipBack();
            score--;
            UpdateScoreDisplay();
        }

        flippedCards.Clear(); // Reset for the next turn
    }

    private void UpdateScoreDisplay()
    {
        myScore.text = score.ToString();
    }

    private IEnumerator BacktoMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
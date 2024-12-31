using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
        if(scoreKeeper.DidPlayerAchieveHighScore())
        {
            highScoreText.text = "You beat your highscore!\nCurrent Highscore is " + scoreKeeper.GetHighScore();
        }
        else
        {
            highScoreText.text = "Your highscore is " + scoreKeeper.GetHighScore();
        }
    }
}

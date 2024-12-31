using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    static ScoreKeeper instance;

    int highscore;

    bool DidAchieveHighScore;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }

    public bool DidPlayerAchieveHighScore()
    {
        return DidAchieveHighScore;
    }
    public void ModifyScore(int value)
    {
        PlayerPrefs.GetInt("highscore",highscore);
        score += value;
        CheckIfPlayerAchievedHighScore();
        Mathf.Clamp(score,0, float.MaxValue);
    }

    public void ResetScore()
    {
        DidAchieveHighScore = false;
        score = 0;
    }

    void CheckIfPlayerAchievedHighScore()
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
            DidAchieveHighScore = true;
        }
    }
}

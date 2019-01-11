using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int currentScore = 0;
    Text scoreText;
    GameData gameData;

    // Use this for initialization
    void Start ()
    {
        gameData = FindObjectOfType<GameData>();
        scoreText = GetComponent<Text>();
        if(currentScore == 0)
        {
            currentScore = gameData.GetFinalScore();
        } else
        {

        }
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "score: " + currentScore.ToString();
    }

    public void ScoreHit(int scorePerDeath)
    {
        currentScore = currentScore + scorePerDeath;
        DisplayScore();
        gameData.SaveScore(currentScore);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    int finalScore;

    private void Awake()
    {
        int countGameData = FindObjectsOfType<GameData>().Length;

        if (countGameData > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveScore(int currentScore)
    {
        finalScore = currentScore;
        print(finalScore);
    }

    public void ResetScore()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public int GetFinalScore()
    {
        return finalScore;
    }
}

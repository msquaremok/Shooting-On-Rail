using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 40;

    int currentScore;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "score: " + currentScore.ToString();
    }
	
    public void ScoreHit()
    {
        currentScore = currentScore + scorePerHit;
        scoreText.text = "score: " + currentScore.ToString();
    }
}

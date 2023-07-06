using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int diamond = 0;
    public static ScoreManager instance;
    public int totalDiamonds;
    public int highScore;
    public int totalScore;

    public TextMeshProUGUI txtDiamond;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;

    void Awake()
    {
        instance = this;
        // PlayerPrefs.SetInt("TotalDiamonds", 0);
    }
    void Start() {
        totalDiamonds = PlayerPrefs.GetInt("TotalDiamonds", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTxt.text = "High Score " + highScore;
    }

    public void IncreaseDiamond()
    {
        diamond++;
        txtDiamond.text = "" + diamond;
    }

    public void IncreaseScore(int score) {
        totalScore += score;
        scoreTxt.text = "Score: " + totalScore;
    } 

    public void AddLastScore() {
        totalDiamonds += diamond;
        PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);
    }

    public void ControlTheHighScore() {
        if (totalScore > highScore) {
            PlayerPrefs.SetInt("HighScore", totalScore);
        }
        else {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    
    }
   
}

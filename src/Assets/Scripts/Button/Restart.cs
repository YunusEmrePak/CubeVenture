using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;

public class Restart : MonoBehaviour
{
    public void RestartTheGame() {
        ScoreManager.instance.ControlTheHighScore();
        PlayerMovementController.instance.StartScreen.SetActive(true);
        PlayerMovementController.instance.FailScreen.SetActive(false);
        Time.timeScale = 1;
        Finish.instance.LoadScene();
    }
}

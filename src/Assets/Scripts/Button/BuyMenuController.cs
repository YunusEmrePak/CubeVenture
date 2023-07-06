using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyMenuController : MonoBehaviour
{

    public void OpenBuyMenu() {
        PlayerMovementController.instance.BuyScreen.SetActive(true);
    }   

    public void CloseBuyMenu() {
        PlayerMovementController.instance.BuyScreen.SetActive(false);
        if (PlayerLevelController.instance.levelCount % 2 == 0) {
            SceneManager.LoadScene("Main2");
        }
        else {
            SceneManager.LoadScene("Main1");
            
        }
    }
}

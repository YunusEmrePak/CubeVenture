using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void GoToShop() {
        PlayerMovementController.instance.ShopScreen.SetActive(true);
    }

    public void CloseShop() {
        PlayerMovementController.instance.ShopScreen.SetActive(false);
        if (PlayerLevelController.instance.levelCount % 2 == 0) {
            SceneManager.LoadScene("Main2");
        }
        else {
            SceneManager.LoadScene("Main1");
            
        }
    }
}

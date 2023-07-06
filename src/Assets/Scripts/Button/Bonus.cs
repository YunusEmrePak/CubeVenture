using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
using HuaweiMobileServices.Ads;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
    public int totalDiamonds;

    void Start() {
        totalDiamonds = ScoreManager.instance.totalDiamonds;
        HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
    }

    public void OnRewarded(Reward reward) {
        totalDiamonds += 25;
        PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);
        if (PlayerLevelController.instance.levelCount % 2 == 0) {
            SceneManager.LoadScene("Main2");
        }
        else {
            SceneManager.LoadScene("Main1");
            
        }
    }

    public void ShowRewardedAd() {
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }
}

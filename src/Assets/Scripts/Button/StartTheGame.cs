using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
using HuaweiMobileServices.Ads;

public class StartTheGame : MonoBehaviour
{
    
    private string interstitialAdUnitId = "testb4znbuh3n2";

    void Start()
    {
        HMSAdsKitManager.Instance.LoadInterstitialAd(interstitialAdUnitId);
    }

    public void StartGame() {
        PlayerMovementController.instance.isClickedToStart = true;
        PlayerMovementController.instance.isStarted = true;
        // PlayerMovementController.instance.ScoreScreen.SetActive(true);
        PlayerMovementController.instance.StartScreen.SetActive(false);
        PlayerMovementController.instance.SettingsScreen.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using HuaweiMobileServices.IAP;
using TMPro;
using UnityEngine;

public class NoAdsButton : MonoBehaviour
{
    public static NoAdsButton instance;
    public TextMeshProUGUI textAdsButton;
    
    public int totalDiamonds;
    public int isAdsOn = 1;

    void Start()
    {
        isAdsOn = PlayerPrefs.GetInt("isAdsOn", 1);
        totalDiamonds = ScoreManager.instance.totalDiamonds;
        if (isAdsOn == 0)
        {
            textAdsButton.text = "Bought";
        }
    }

    void Awake()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        instance = this;
    }

    public void OnNoAdsClick()
    {
        if (PlayerPrefs.GetInt("isAdsOn", 1) == 0)
        {
            return;
        }
        HMSIAPManager.Instance.PurchaseProduct("remove_ads");
    }

    public void BuyDiamond300()
    {
        HMSIAPManager.Instance.PurchaseProduct("diamond300");
    }

    public void BuyDiamond600()
    {
        HMSIAPManager.Instance.PurchaseProduct("diamonds600");
    }

    public void OnBuyProductSuccess(PurchaseResultInfo result)
    {
        if (result.InAppPurchaseData.ProductId == "remove_ads")
        {
            PlayerPrefs.SetInt("isAdsOn", 0);
            HMSAdsKitManager.Instance.HideBannerAd();
            textAdsButton.text = "Bought";
            Debug.Log("OnBuyProductSuccess: Ads Removed");
        }
        else if (result.InAppPurchaseData.ProductId == "diamond300")
        {
            totalDiamonds += 300;
            PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);
            Debug.Log("OnBuyProductSuccess: Bought 300 Diamonds");
        }
        else if (result.InAppPurchaseData.ProductId == "diamonds600")
        {
            totalDiamonds += 600;
            PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);
            Debug.Log("OnBuyProductSuccess: Bought 600 Diamonds");
        }
        else
        {
            Debug.Log("OnBuyProductSuccess: Purchase failed");
        }
    }
}

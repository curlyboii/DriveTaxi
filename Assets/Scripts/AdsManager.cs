using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; //ads

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    public static AdsManager instance; //use everywhere

    string gameID = "5247588";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID); //ads intialize
        Advertisement.AddListener(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ShowAdsInterstitial()
    {

        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }

    }
    public void ShowRewardAds()
    {

        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }

    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("OnUnityAdsReady");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {

           // Debug.Log("+10 crystal");

        }

        GameManager.instance.ReloadScene();
    }
}

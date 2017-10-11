using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;
//using UnityEngine.Advertisements;

public class AdsControl : MonoBehaviour
{
	
	
	protected AdsControl ()
	{
	}

	private static AdsControl _instance;

//	ShowOptions options;
	InterstitialAd interstitial;
	RewardBasedVideoAd rewardAds;
	GetItem getItem;
	bool rewardAdFailToLoad;

	public string AdmobID_Android, AdmobID_IOS,AdmobRewardAdsID, UnityID_Android, UnityID_IOS, UnityZoneID;

	public static AdsControl Instance { get { return _instance; } }

	void Awake ()
	{
		
		if (FindObjectsOfType (typeof(AdsControl)).Length > 1) {
			Destroy (gameObject);
			return;
		}
		rewardAdFailToLoad = false;
		_instance = this;
		MakeNewInterstial ();
		MakeNewRewardAds ();
		
		DontDestroyOnLoad (gameObject); //Already done by CBManager


//		if (Advertisement.isSupported) { // If the platform is supported,
//			#if UNITY_IOS
//			Advertisement.Initialize (UnityID_IOS); // initialize Unity Ads.
//			#endif
//
//			#if UNITY_ANDROID
//			Advertisement.Initialize (UnityID_Android); // initialize Unity Ads.
//			#endif
//		}
//		options = new ShowOptions ();
//		options.resultCallback = HandleShowResult;
//
//	

	}


	public void HandleInterstialAdClosed (object sender, EventArgs args)
	{
	


		if (interstitial != null)
			interstitial.Destroy ();
		MakeNewInterstial ();
	

		
	}

	void MakeNewInterstial ()
	{


#if UNITY_ANDROID
		interstitial = new InterstitialAd (AdmobID_Android);
#endif
#if UNITY_IPHONE
		interstitial = new InterstitialAd (AdmobID_IOS);
#endif
		interstitial.OnAdClosed +=  HandleInterstialAdClosed; 
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitial.LoadAd (request);


	}
	void HandleRewardsAdClosed(object sender, EventArgs args)
	{
		Debug.Log ("Ads closed");

		MakeNewRewardAds ();
	}
	void MakeNewRewardAds ()
	{


		#if UNITY_ANDROID
		rewardAds =  RewardBasedVideoAd.Instance;
		#endif
		rewardAds.OnAdClosed += HandleRewardsAdClosed;
		rewardAds.OnAdRewarded += HandleRewardsAdSeen;
		rewardAds.OnAdFailedToLoad += HandleRewardsAdFailToLoad;
 		AdRequest request = new AdRequest.Builder ().Build ();
		rewardAds.LoadAd (request,AdmobRewardAdsID);


	}



	public void showAds ()
	{
		if(interstitial.IsLoaded())
	
		interstitial.Show ();
	
	

	}


	public bool GetRewardAvailable ()
	{
		bool avaiable = false;

		return avaiable;
	}

	public void ShowRewardVideo (GetItem _getitem)
	{
		if (rewardAdFailToLoad) {
			MakeNewRewardAds ();
		}
		getItem = _getitem;
		Debug.Log ("Show RW");
		if (rewardAds.IsLoaded())
			rewardAds.Show ();

//		Advertisement.Show (UnityZoneID, options);
	

		
	}
	void HandleRewardsAdFailToLoad (object sender, EventArgs args)
	{
		rewardAdFailToLoad = true;
	}
	void HandleRewardsAdSeen(object sender, Reward args)
	{
		getItem.isRewarded=true;
	}



	public void HideBannerAds ()
	{
	}

	public void ShowBannerAds ()
	{
	}

//	private void HandleShowResult (ShowResult result)
//	{
//		switch (result) {
//		case ShowResult.Finished:
//			//GameData.AddCash (1);
//			FindObjectOfType<GetItem> ().GetItemFree ();
//			break;
//		case ShowResult.Skipped:
//			break;
//		case ShowResult.Failed:
//			break;
//		}
//	}

}


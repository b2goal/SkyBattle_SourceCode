using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;


public class FaceBookController : MonoBehaviour {

	void Awake()
	{
		FB.Init(SetInit, OnHideUnity);
	}
	private void SetInit()
	{
		Debug.Log("Facebook init done!");
		if (FB.IsLoggedIn)
		{
			// Fb logged in
		}
		else
		{
			//call login facebook
		}
	}
	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
	public void FBLogin()
	{
		FB.LogInWithPublishPermissions (
			new List<string>(){"publish_actions"},
			AuthCallback
		);
	}
	void AuthCallback(ILoginResult result)
	{
		if (FB.IsLoggedIn)
		{
			Debug.Log("FB login worked");
			ShareWithFriends();
		}
		else
		{
			Debug.Log("FB login fail");
		}
	}
	public void ShareWithFriends()
	{
		if (FB.IsLoggedIn)
		{
			FB.ShareLink(
				new Uri("https://play.google.com/store/apps/details?id=com.galaxystrikeforce.airfighter.spacefighter"),
				callback: ShareCallback
			);

			Debug.Log("Fb logged in");
		}
		else
		{
			FBLogin();
		}
	}

	private void ShareCallback(IShareResult result)
	{
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}
	public void InviteFriends()
	{
		FB.AppRequest(
			message: "This game is awesome,join me. now",
			title: "Invite your friends to join you"
		);
	}
}

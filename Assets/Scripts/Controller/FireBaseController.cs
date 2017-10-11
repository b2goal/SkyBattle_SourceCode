using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseController : MonoBehaviour {

		// Use this for initialization
		void Start () {
			UnityEngine.Debug.Log("start -----");
			Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
			Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
			UnityEngine.Debug.Log("end -----");
		    	DontDestroyOnLoad (gameObject); 
		}

		// Update is called once per frame
		void Update () {

		}
		public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
		{
			UnityEngine.Debug.Log("Received a token");
			UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
		}

		public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
		{
			UnityEngine.Debug.Log("Received a new message");
			var notification = e.Message.Notification;
			if (notification != null)
			{
				UnityEngine.Debug.Log("title: " + notification.Title);
				UnityEngine.Debug.Log("body: " + notification.Body);
			}
			if (e.Message.From.Length > 0)
				UnityEngine.Debug.Log("from: " + e.Message.From);
			if (e.Message.Data.Count > 0)
			{
				UnityEngine.Debug.Log("data:");
				foreach (System.Collections.Generic.KeyValuePair<string, string> iter in
					e.Message.Data)
				{
					UnityEngine.Debug.Log("  " + iter.Key + ": " + iter.Value);
				}
			}
			UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
			//gameOverText.text = "asddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd";
		}
	}


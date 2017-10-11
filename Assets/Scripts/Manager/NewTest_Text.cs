using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTest_Text : MonoBehaviour {

	public Text tex;
	// Use this for initialization
	void Start () {
		tex.text = "Level " + PlayerPrefs.GetInt (MenuScript.LEVEL_KEY);
		//new Unlock().setTextPlayLevel();
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}

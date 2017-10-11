using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSlace : MonoBehaviour {
	public float slaceMin;
	public float slaceMax;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = Vector3.one * Random.Range (slaceMin, slaceMax);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

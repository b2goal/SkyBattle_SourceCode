using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectManager : MonoBehaviour {

	// Use this for initialization
	public Vector3 spawnValue;
	public float spawnWaitMin;
	public float spawnWaitMax;
	public float slaceMin;
	public float slaceMax;
	public float speedMin;
	public float speedMax;
	public float rotationMin;
	public float rotationMax;
	public Sprite[] listObject ;
	public GameObject ro;
	private GameManager _gameManager;
	void Start () {
		Debug.Log ("Start");
		Vector3 spwamPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, Random.Range (-spawnValue.z, spawnValue.z));
		Quaternion spawmRotation = Quaternion.identity;

		_gameManager = GameSetting._gameManager;
		ro.GetComponent<SpriteRenderer> ().sprite = listObject [Random.Range (0, listObject.Length - 1)];
		ro.transform.position = spwamPosition;
		Instantiate (ro, gameObject.transform.parent.transform);

		StartCoroutine (SpawmWavesObject());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator SpawmWavesObject ()
	{
		yield return new WaitForSecondsRealtime (Random.Range (spawnWaitMin, spawnWaitMax));
		while (true) {
			if (_gameManager.gameState == GameState.Play)
			{
			Vector3 spwamPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
			Quaternion spawmRotation = Quaternion.identity;
			ro.GetComponent<SpriteRenderer> ().sprite = listObject [Random.Range (0, listObject.Length - 1)];
			ro.transform.position = spwamPosition;
			Instantiate (ro, gameObject.transform.parent.transform);
			}
			yield return new WaitForSecondsRealtime (Random.Range (spawnWaitMin, spawnWaitMax));
		}
	}
}

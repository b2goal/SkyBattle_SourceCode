using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    private void Start()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.angularVelocity = Random.Range(0.1f,1f) * tumble;
    }

}

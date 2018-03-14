using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

	public Rigidbody rb;
	public float powerAmt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce(Vector3.forward * powerAmt);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce(Vector3.back * powerAmt);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce(Vector3.left * powerAmt);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce(Vector3.right * powerAmt);
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

	Rigidbody rb;
	Vector3 targetPos;
	public GameObject targetObj;
	public float thrustAmt = 10f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if we dont first check if it is null, then it will give us an error once it reaches its target
		//...because it wont be able to find targetObj after that (it has been destroyed)
		if (targetObj != null) {
			//we use the position of targetObj
			targetPos = targetObj.transform.position;
			//we determine the direction by first calculating the distance (targetPos - thisPosition)
			//and then "normalizing" it (turning it into terms of -1 to 1), aka converting it into a direction
			Vector3 direction = Vector3.Normalize (targetPos - transform.position);
			rb.AddForce (direction * thrustAmt);
		}

	}

	//this function runs any time the object this is attached to collides with another object
	void OnCollisionEnter(Collision colReport){ //it creates a new Collision when it executes, storing information about the collision
		//Destroy (gameObject);

		//we check to see if the gameObject collided with (as indicated in the colReport) is the same as our target
		if (colReport.gameObject == targetObj) {
			Destroy (targetObj);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedClone : MonoBehaviour {

	//setting our blueprint to a prefab we created by dragging our gameobject into our assets
	public GameObject blueprint;
	public float cloneTime = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if the time elapsed has surpassed our threshold
		if (Time.time > cloneTime) {
			//first, push the threshold back so it will "reset" the timer
			cloneTime += cloneTime;
			Debug.Log ("do a thing");
			//create a new instance of our blueprint at the same position of this game object with a default rotations
			Instantiate (blueprint, transform.position, Quaternion.identity);
		}
	}
}

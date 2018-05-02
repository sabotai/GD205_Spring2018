using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public Rigidbody bulletBlueprint; // assign in inspector
	public Transform bulletOrigin; // position an object to use its position as a spawn point
	public float bulletForce = 3000f; // this is the bullet speed.  3000 is the default

	bool rotateToClick = false;

	//something to store the destination rotation
	Quaternion newRot;

	// store the percentage achieved in the movement towards our new rotation
	float rotCount = 0f;

	void Start(){
		//this boolean just lets the script know when it should be moving into position
		//true = keep moving towards target; false = stop moving
		rotateToClick = false;
	}

	// Update is called once per frame
	void Update () {
		// generate a ray based on camera position + mouse cursor screen coordinate
		Ray ourRay = Camera.main.ScreenPointToRay ( Input.mousePosition );

		// reserve space for info about where the raycast hit a thing, what it hit, etc.
		// it will start off as an empty container that hit information will be recorded into
		RaycastHit rayHit = new RaycastHit(); // initialize forensics data container

		// actually shoot the raycast, 1000 is how far the raycast can go
		// which ray to cast? ourRay. which out to send hit info?  rayHit.  how far should the ray go? 1000 units
		if ( Physics.Raycast ( ourRay, out rayHit, 1000f ) && Input.GetMouseButtonDown (0) ) {
			// set the new rotation in our variable
			newRot = Quaternion.LookRotation(rayHit.point - transform.position);

			rotateToClick = true; //trigger the rotation of our camera and its children (our shooting thing)
			rotCount = 0; //reset our counter representing our rotation's % completed
		}

		if (rotateToClick){ //only do this once there was a hit ^
			float rotSpeed = Time.deltaTime; //go by time -- this will be the percentage to rotate each frame
			rotCount += rotSpeed; // count those percentages so we know how close we are
			Debug.Log("Barrel rotated by... " + rotCount*100f +"%"); //show us the % completed

			//use "slerp" to rotate smoothly
			transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotSpeed);

			if (rotCount > 1f){ //completed rotation
				//create a new bullet instance from our blueprint
				Rigidbody newBullet = (Rigidbody)Instantiate ( bulletBlueprint, bulletOrigin.position, bulletOrigin.rotation ); // make a new clone at raycast hit position

				//make the new bullet go forward by this much force
				newBullet.AddForce(bulletOrigin.forward * bulletForce);

				//play the boom sound that is contained in an AudioSource script
				//GetComponent<AudioSource>().Play();

				//stop rotating every frame
				rotateToClick = false;

				StartCoroutine (ScreenShake.Shake (0.3f, 0.5f));
			}
		}



	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementW3 : MonoBehaviour {

	public GameObject myObj;
	public int gridSize = 2;
	public GameObject winSpot;
	public int maxGrid = 8;
	public int minGrid = 0;
	Vector3 playerStart;
	public GameObject background;

	// Use this for initialization
	void Start () {
		playerStart = myObj.transform.position;
		int randoX = (int)(Random.Range(minGrid , maxGrid / gridSize));
		Debug.Log (randoX);
		randoX *= gridSize;
		int randoZ = (int)(Random.Range(minGrid , maxGrid / gridSize));
		Debug.Log (randoZ);
		randoZ *= gridSize;
		winSpot.transform.position = new Vector3 (randoX, winSpot.transform.position.y, randoZ);
		
	}
	// Update is called once per frame
	void Update () {
		movementInput ();
		checkBounds ();
		checkWin ();
	}
	void checkWin(){
		//IF MYOBJ IS AT THE WINSPOT POSITION, MAKE SOMETHING HAPPEN
		if (myObj.transform.position == winSpot.transform.position) {
			//myObj.transform.localScale *= 1.01f;
			myObj.transform.position =  playerStart;
			background.GetComponent<MeshRenderer> ().material.color = Color.cyan;
			Start ();
		}
	}
	void movementInput(){

		//Z MOVEMENT ON GRID
		if (Input.GetKeyDown (KeyCode.W)) {
			myObj.transform.position += new Vector3 (0, 0, gridSize);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			myObj.transform.position += new Vector3 (0, 0, -gridSize);
		}
		//X MOVEMENT ON GRID
		if (Input.GetKeyDown (KeyCode.D)) {
			myObj.transform.position += new Vector3 (gridSize, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			myObj.transform.position += new Vector3 (-gridSize, 0, 0);
		}
	}

	void checkBounds(){
		//Z RESET BOUNDS
		if (myObj.transform.position.z > maxGrid) {
			myObj.transform.position = new Vector3(myObj.transform.position.x,myObj.transform.position.y,0);
		}
		if (myObj.transform.position.z < minGrid) {
			myObj.transform.position = new Vector3(myObj.transform.position.x,myObj.transform.position.y,8);
		}
		//X RESET BOUNDS
		if (myObj.transform.position.x > maxGrid) {
			myObj.transform.position = new Vector3(0,myObj.transform.position.y,myObj.transform.position.z);
		}
		if (myObj.transform.position.x < minGrid) {
			myObj.transform.position = new Vector3(8,myObj.transform.position.y,myObj.transform.position.z);
		}
	}
}

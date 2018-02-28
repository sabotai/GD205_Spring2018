using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMovementW5 : MonoBehaviour {

	public GameObject myObj;
	public int gridSize = 2;
	public GameObject winSpot;
	public int maxGrid = 8;
	public int minGrid = 0;
	Vector3 playerStart;
	public GameObject background;
	public int score = 0;
	public Text scoreText;
	public GameObject[] enemySpot;
	public float enemySpeed;
	public AudioSource myAudSrc;
	public AudioClip moveClip, sadClip, happyClip;

	int randoX, randoZ;

	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString ();
		playerStart = myObj.transform.position;
		//call that function
		randoPos();
		winSpot.transform.position = new Vector3 (randoX, winSpot.transform.position.y, randoZ);


		//while randoX and randoZ are the same, reset them (until they are different)
		//this is so we dont have the enemy and winspot in the same position

		for (int i = 0; i < enemySpot.Length; i++) {
			randoPos ();
			while(randoX == winSpot.transform.position.x && randoZ == winSpot.transform.position.z){
				//call that function
				randoPos();
			}
			enemySpot[i].transform.position = new Vector3 (randoX, enemySpot[i].transform.position.y, randoZ);

		}

	}
	// Update is called once per frame
	void Update () {
		movementInput ();
		checkBounds ();
		checkWin ();
		checkLose ();
		moveEnemy ();
	}

	void randoPos(){
		randoX = (int)(Random.Range(minGrid / gridSize, maxGrid / gridSize));
		Debug.Log (randoX);
		randoX *= gridSize;
		randoZ = (int)(Random.Range(minGrid / gridSize, maxGrid / gridSize));
		Debug.Log (randoZ);
		randoZ *= gridSize;
	}

	void checkWin(){
		//IF MYOBJ IS AT THE WINSPOT POSITION, MAKE SOMETHING HAPPEN
		if (myObj.transform.position == winSpot.transform.position) {
			//increase our score
			score++;
			myAudSrc.PlayOneShot (happyClip);
			//reset the players position
			myObj.transform.position =  playerStart;
			background.GetComponent<MeshRenderer> ().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			//run start to reset the scene
			Start ();
		}
	}
	void checkLose(){
		//IF MYOBJ IS AT THE ENEMYSPOT POSITION, MAKE SOMETHING HAPPEN
		for (int i = 0; i < enemySpot.Length; i++) {
			if (myObj.transform.position == enemySpot[i].transform.position) {
				//decrease our score
				score--;
				myAudSrc.PlayOneShot (sadClip);
				//reset the players position
				myObj.transform.position = playerStart;
				//reset the background to be a random HSV color
				//H between the range 0 and 1
				//S between the range 1 and 1
				//V between the range 0.5 and 1
				background.GetComponent<MeshRenderer> ().material.color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
				//run start to reset the scene
				Start ();
			}
		}
	}
	void moveEnemy(){

		for (int i = 0; i < enemySpot.Length; i++) {
			//move our enemy along the x axis
			enemySpot[i].transform.position += new Vector3 ((float)gridSize / enemySpeed, 0f, 0f);

			//if the enemy goes off the grid
			if (enemySpot[i].transform.position.x > maxGrid) {
				//reset the x value to the left side and the move the z to the next row
				enemySpot[i].transform.position = new Vector3 (minGrid, enemySpot[i].transform.position.y, enemySpot[i].transform.position.z - gridSize);
			}

			//if the z goes past the bottom of our grid
			if (enemySpot[i].transform.position.z < minGrid) {
				//then reset it to the top left
				enemySpot[i].transform.position = new Vector3 (minGrid, enemySpot[i].transform.position.y, maxGrid);
			}
		}

	}
	void movementInput(){

		//Z MOVEMENT ON GRID
		if (Input.GetKeyDown (KeyCode.W)) {
			myObj.transform.position += new Vector3 (0, 0, gridSize);
			myAudSrc.PlayOneShot (moveClip);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			myObj.transform.position += new Vector3 (0, 0, -gridSize);
			myAudSrc.PlayOneShot (moveClip);
		}
		//X MOVEMENT ON GRID
		if (Input.GetKeyDown (KeyCode.D)) {
			myObj.transform.position += new Vector3 (gridSize, 0, 0);
			myAudSrc.PlayOneShot (moveClip);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			myObj.transform.position += new Vector3 (-gridSize, 0, 0);
			myAudSrc.PlayOneShot (moveClip);
		}
	}

	void checkBounds(){
		//Z RESET BOUNDS
		if (myObj.transform.position.z > maxGrid) {
			myObj.transform.position = new Vector3(myObj.transform.position.x,myObj.transform.position.y,minGrid);
		}
		if (myObj.transform.position.z < minGrid) {
			myObj.transform.position = new Vector3(myObj.transform.position.x,myObj.transform.position.y,maxGrid);
		}
		//X RESET BOUNDS
		if (myObj.transform.position.x > maxGrid) {
			myObj.transform.position = new Vector3(minGrid,myObj.transform.position.y,myObj.transform.position.z);
		}
		if (myObj.transform.position.x < minGrid) {
			myObj.transform.position = new Vector3(maxGrid,myObj.transform.position.y,myObj.transform.position.z);
		}
	}
}

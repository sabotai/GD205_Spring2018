using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

	Animator myAnim;
	public int animState = 0;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			animState = 1;
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			animState = 0;
		}

		if (Input.GetKey (KeyCode.LeftShift) && animState == 1) {
			animState = 2;
		}

		myAnim.SetInteger ("State", animState);

		if (animState == 2) {
			animState = 1;
		}
	}
}

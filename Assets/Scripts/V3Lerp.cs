using System.Collections;
using UnityEngine;
using System.Collections;

public class V3Lerp : MonoBehaviour {
	public Transform startMarker;
	public Transform endMarker;

	void Start() {
		
	}
	void Update() {
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, 0.5f);
	}
}
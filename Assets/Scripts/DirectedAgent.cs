using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedAgent : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent myAgent;
    public Transform target;

	// Use this for initialization
	void Start () {
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        myAgent.destination = target.position;

	}
}

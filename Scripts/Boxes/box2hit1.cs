using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box2hit1 : MonoBehaviour {

	public bool triggered = false;

	// Use this for initialization
	void Start () {
		triggered = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			triggered = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
			triggered = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

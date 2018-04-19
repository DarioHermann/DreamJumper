using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kairiBed : MonoBehaviour {

	private bool calmKairi;

	// Use this for initialization
	void Start () {
		calmKairi = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			calmKairi = true;
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player")
			calmKairi = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (calmKairi) {
			if (Input.GetKeyUp (KeyCode.F)) {
				if (npcOneBed.shadMissionDone && npcTwoBed.nessMissionDone) {
					PlayerController.completedLevelThree = true;
					PlayerController.completedGame = true;
					Application.LoadLevel ("Dream Jumper Scene");
				}
			}
		}
	}
}

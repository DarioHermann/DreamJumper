using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerBed : MonoBehaviour {

	private bool wantToSleep = false;
	public Text action_text;


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			wantToSleep = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			wantToSleep = false;
			action_text.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (wantToSleep) {
			if (PlayerController.energy < 3) {
				action_text.text = "Press F to sleep";
				if (Input.GetKeyUp (KeyCode.F)) {
					PlayerController.energy = 3;
					PlayerController.game_time += 8;
				}
			} else
				action_text.text = "Energy is full!";
		}
	}
}

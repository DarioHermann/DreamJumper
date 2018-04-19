using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerBed : MonoBehaviour { //This class is for the player's bed (where the player receives energy)

	private bool wantToSleep = false;
	public Text action_text;

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
				action_text.text = "Press F to sleep"; //On this bed, it only appears the text if the player has less than 3 of energy, otherwise the player can't even sleep
				if (Input.GetKeyUp (KeyCode.F)) {
					PlayerController.energy = 3; //Player's energy maximizes if he goes to sleep
					PlayerController.game_time += 8; //And moves 8 in-game hours forward
				}
			} else
				action_text.text = "Energy is full!"; //if the player already has 3 of energy this text appears.
		}
	}
}

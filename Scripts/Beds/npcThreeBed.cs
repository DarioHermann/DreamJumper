using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcThreeBed : MonoBehaviour {

	private bool wantToDreamJump=false;

	private Animator _animatorKairi;
	public Text action_text; 

	public static bool kairiMissionDone = false;

	public static int jumpCounter = 1;

	// Use this for initialization
	void Start () {
		GameObject kairi = GameObject.Find ("Kairi_KH2@Sleeping Idle");
		_animatorKairi = kairi.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			wantToDreamJump = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			wantToDreamJump = false;
			action_text.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		_animatorKairi.SetBool ("kairiIsCalm", kairiMissionDone);
		if (wantToDreamJump && !PlayerController.completedLevelOne) {
			if (PlayerController.energy >= jumpCounter) {
				action_text.text = "Press F to Dream Jump Kairi";
				if (Input.GetKeyUp (KeyCode.F)) {
					PlayerController.energy -= jumpCounter;
					if (jumpCounter < 3)
						jumpCounter++;
					PlayerController.insideDream = true;
					PlayerController.game_time += 3;
					Application.LoadLevel ("DreamThree");
				}
			} else
				action_text.text = "Not Enough Energy to Dream Jump!";
		}
	}
}

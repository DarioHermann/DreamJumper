using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcTwoBed : MonoBehaviour {

	private bool wantToDreamJump=false;

	private Animator _animatorMover;
	private Animator _animatorNess;

	public static bool nessMissionDone = false;

	public static int jumpCounter = 1;

	public Text action_text;

	// Use this for initialization
	void Start () {
		GameObject nessMover = GameObject.Find ("Ness Positioner");
		_animatorMover = nessMover.GetComponent<Animator> ();

		GameObject ness = GameObject.Find ("Ness@Sleeping Idle");
		_animatorNess = ness.GetComponent<Animator> ();
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
		_animatorMover.SetBool ("nessIsAwake", nessMissionDone);
		_animatorNess.SetBool ("nessIsAwake", nessMissionDone);
		if (wantToDreamJump && !PlayerController.completedLevelOne) {
			if (PlayerController.energy >= jumpCounter) {
				action_text.text = "Press F to Dream Jump Ness";
				if (Input.GetKeyUp (KeyCode.F)) {
					PlayerController.energy -= jumpCounter;
					if (jumpCounter < 3)
						jumpCounter++;
					PlayerController.insideDream = true;
					PlayerController.game_time += 3;
					if (!PlayerController.completedGame)
						Application.LoadLevel ("DreamTwo");
					else
						Application.LoadLevel ("DreamTwoSecondTry");
				}
			} else
				action_text.text = "Not Enough Energy to Dream Jump!";
		}
	}
}

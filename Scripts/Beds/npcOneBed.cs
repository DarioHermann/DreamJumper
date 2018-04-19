using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npcOneBed : MonoBehaviour {

	private bool wantToDreamJump=false;

	private Animator _animatorMover;
	private Animator _animatorShad;

	public static bool shadMissionDone = false;

	public static int jumpCounter = 1;

	public Text action_text;

	// Use this for initialization
	void Start () {
		GameObject shadMover = GameObject.Find ("Shad Positioner");
		_animatorMover = shadMover.GetComponent<Animator> ();

		GameObject shad = GameObject.Find ("Shad@Sleeping Idle (1)");
		_animatorShad = shad.GetComponent<Animator> ();
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
		_animatorMover.SetBool ("shadIsAwake", shadMissionDone); //both this line control Shad's animation, those depend if his dream is complete.
		_animatorShad.SetBool ("shadIsAwake", shadMissionDone);
		if (wantToDreamJump && !PlayerController.completedLevelOne) {
			if (PlayerController.energy >= jumpCounter) {
				action_text.text = "Press F to Dream Jump Shad";
				if (Input.GetKeyUp (KeyCode.F)) {
					PlayerController.energy -= jumpCounter;
					if (jumpCounter < 3)
						jumpCounter++;
					PlayerController.insideDream = true;
					PlayerController.game_time += 3;
					if (!PlayerController.completedGame)
						Application.LoadLevel ("DreamOne");
					else
						Application.LoadLevel ("DreamOneSecondTry");
				}
			} else
				action_text.text = "Not Enough Energy to Dream Jump!";
		}
	}
}

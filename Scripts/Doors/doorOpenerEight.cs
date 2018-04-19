using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorOpenerEight : MonoBehaviour {

	private Animator _animator;
	public static bool open = false;
	bool canOpen = false;
	public Text action_text;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (npcOneBed.shadMissionDone)
				action_text.text = "Press F to open door"; //The text appears when the player approaches the door and the player has completed the first dream
			canOpen = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			canOpen = false;
			action_text.text = ""; //The text disappears when the player moves away from the door
		}
	}

	// Update is called once per frame
	void Update () {
		if (canOpen && npcOneBed.shadMissionDone) {
			if (Input.GetKeyUp (KeyCode.F)) {
				_animator.SetBool ("open", true); //If the user is near the door, the player has completed the first dream and the player presses F, the door opens.
				open = true;
			}
		}
	}
}

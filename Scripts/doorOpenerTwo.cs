using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorOpenerTwo : MonoBehaviour {

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
			if (!open)
				action_text.text = "Press F to open door";
			canOpen = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			canOpen = false;
			action_text.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if (canOpen) {
			if (Input.GetKeyUp (KeyCode.F)) {
				_animator.SetBool ("open", true);
				open = true;
			}
		}
	}
}

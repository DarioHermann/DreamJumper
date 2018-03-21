using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenerThree : MonoBehaviour {

	private Animator _animator;
	bool open = false;

	public bool openedFirstDoor = false;

	GameObject theDoor;
	doorOpenerTwo doorScript;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		theDoor = GameObject.Find ("Room 1 door mover");
		doorScript = theDoor.GetComponent<doorOpenerTwo> ();

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			open = true;
		}
	}

	void OnTriggerExit(Collider other){
		open = false;
	}

	// Update is called once per frame
	void Update () {
		openedFirstDoor = doorScript.openedFirstDoor;
		if(open && openedFirstDoor)
			if(Input.GetKeyUp(KeyCode.F))
				_animator.SetBool ("open", true);
	}
}

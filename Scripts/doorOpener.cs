using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour {

	private Animator _animator;
	bool open = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
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
		if (open){
			if (Input.GetKeyUp (KeyCode.F)) {
				_animator.SetBool ("open", true);
			}
		}
	}
}

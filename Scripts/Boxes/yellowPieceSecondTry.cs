using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPieceSecondTry : MonoBehaviour {

	private bool onTop;

	// Use this for initialization
	void Start () {
		onTop = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Box") {
			//PlayerController.completedLevelTwo = true;
			onTop = true;
			StartCoroutine (waiter ());
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Box") {
			//PlayerController.completedLevelTwo = true;
			onTop = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waiter(){
		yield return new WaitForSeconds (3);
		if (onTop) {
			PlayerController.completedLevelFive = true;
			Application.LoadLevel ("Dream Jumper Scene");
		}

	}
}

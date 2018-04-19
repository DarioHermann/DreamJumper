using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPieceSecondTry : MonoBehaviour {

	private bool onTop;

	// Use this for initialization
	void Start () { //This class works as the objective for the second try of the second dream, the box has to be on top of it
		onTop = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Box") {
			onTop = true;
			StartCoroutine (waiter ());
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Box") {
			onTop = false;
		}

	}

	IEnumerator waiter(){
		yield return new WaitForSeconds (3); //This one differs from the first in the way that the first, the box simply had to touch the objective
		if (onTop) { //In this one, the box has to be on top of the yellow piece for 3 seconds.
			PlayerController.completedLevelFive = true;
			Application.LoadLevel ("Dream Jumper Scene");
		}

	}
}

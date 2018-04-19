using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPiece : MonoBehaviour {

	void OnTriggerEnter(Collider other){ //This class works as the objective for the second dream, the box has to be on top of it
		if (other.tag == "Box") {
			PlayerController.completedLevelTwo = true;
			StartCoroutine (waiter ());
		}

	}

	IEnumerator waiter(){
		yield return new WaitForSeconds (2); //after the box touches it, the first scene is loaded again.
		Application.LoadLevel ("Dream Jumper Scene");
	}
}

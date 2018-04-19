using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPiece : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Box") {
			PlayerController.completedLevelTwo = true;
			StartCoroutine (waiter ());
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waiter(){
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Dream Jumper Scene");
	}
}

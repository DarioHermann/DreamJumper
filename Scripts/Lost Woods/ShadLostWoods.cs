using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadLostWoods : MonoBehaviour {

	private bool helpShad;
	private bool realShad;

	GameObject shadOne;
	GameObject shadTwo;
	GameObject shadThree;

	private Vector3[] positions = new [] {new Vector3 (-45.397f, 1.751f, -40.0f), new Vector3 (0.0f, 1.751f, -40.0f), new Vector3 (45.397f, 1.751f, -40.0f),
		new Vector3(85.0f, 1.751f, 0.0f), new Vector3 (45.397f, 1.751f, 40.0f), new Vector3 (0.0f, 1.751f, 40.0f), new Vector3 (-45.397f, 1.751f, 40.0f),
		new Vector3(-85.0f, 1.751f, 0.0f)}; //I made an array of Vector3 for Shad's position. It will be decided by a random that will select one of these vectors for his position on the map

	// Use this for initialization
	void Start () { //This class works pretty much the same way as ShadLostWoodsFirst, with the slight difference that it spawns 3 Shads instead of just one
		shadOne = GameObject.Find("Shad Positioner"); //But only the first one is the real Shad (Oh Damn! Deep)
		shadTwo = GameObject.Find("Shad Positioner2");
		shadThree = GameObject.Find("Shad Positioner3");
		helpShad = false;
		realShad = false;

		GameObject[] shads = {shadOne, shadTwo, shadThree};
		int[] places = new int[3];
		places[0] = Random.Range (0, 8); //the next lines prevent that two Shads receive the same position.
		int i = 1;
		bool repeat;
		do{
			repeat = false;
			places[i] = Random.Range(0, 8);
			if(i >= 1){
				if(places[i] == places[i-1]){
					repeat = true;
				}
			}
			if(i==2){
				if(places[i] == places[i-2]){
					repeat = true;
				}
			}
			if(!repeat)
				i++;
		}while(i<=2);

		int shadpos;

		for (i = 0; i < 3; i++) {
			shadpos = places[i];
			shads[i].transform.position = positions [shadpos];
			//speaker.transform = vectorShad;
			if (shadpos < 3)
				shads[i].transform.rotation = Quaternion.EulerAngles (0.0f, 0.0f, 0.0f);
			else if (shadpos == 3)
				shads[i].transform.rotation = Quaternion.EulerAngles (0.0f, -90.0f, 0.0f);
			else if (shadpos < 7)
				shads[i].transform.rotation = Quaternion.EulerAngles (0.0f, -180.0f, 0.0f);
			else
				shads[i].transform.rotation = Quaternion.EulerAngles (0.0f, 90.0f, 0.0f);
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			helpShad = true;
		if (this.tag == "realShad")
			realShad = true;
		else
			realShad = false;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
			helpShad = false;
		realShad = false;
	}

	// Update is called once per frame
	void Update () {
		if(helpShad){
			if (Input.GetKeyUp (KeyCode.F)) {
				helpShad = false;
				if (realShad) { //The player can only leave the dream if he encounters the real Shad
					PlayerController.completedLevelFour = true;
					Application.LoadLevel ("Dream Jumper Scene");
				}


			}
		}
	}
}

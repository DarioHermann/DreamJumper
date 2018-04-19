using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadLostWoodsFirst : MonoBehaviour {

	private bool helpShad;

	private Vector3[] positions = new [] {new Vector3 (-45.397f, 1.751f, -40.0f), new Vector3 (0.0f, 1.751f, -40.0f), new Vector3 (45.397f, 1.751f, -40.0f),
		new Vector3(85.0f, 1.751f, 0.0f), new Vector3 (45.397f, 1.751f, 40.0f), new Vector3 (0.0f, 1.751f, 40.0f), new Vector3 (-45.397f, 1.751f, 40.0f),
		new Vector3(-85.0f, 1.751f, 0.0f)};

	// Use this for initialization
	void Start () {
		//GameObject speaker = GameObject.Find ("Lost Woods Speaker");
		helpShad = false;

		int shadpos= Random.Range (0, 8);

		transform.position = positions [shadpos];
		//speaker.transform = vectorShad;
		if (shadpos < 3)
			transform.rotation = Quaternion.EulerAngles (0.0f, 0.0f, 0.0f);
		else if (shadpos == 3)
			transform.rotation = Quaternion.EulerAngles (0.0f, -90.0f, 0.0f);
		else if (shadpos < 7)
			transform.rotation = Quaternion.EulerAngles (0.0f, -180.0f, 0.0f);
		else
			transform.rotation = Quaternion.EulerAngles (0.0f, 90.0f, 0.0f);

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			helpShad = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
			helpShad = false;
	}

	// Update is called once per frame
	void Update () {
		if(helpShad){
			if (Input.GetKeyUp (KeyCode.F)) {
				helpShad = false;
				PlayerController.completedLevelOne = true;
				Application.LoadLevel ("Dream Jumper Scene");
			}
		}
	}
}

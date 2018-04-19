using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	GameObject playerObj;
	Vector3 cameraOffset;

	void Start () {
		playerObj = GameObject.Find ("Player"); //All the camera does is follow the player around by staying 1 unit y and 1 z behind the player at all times
		cameraOffset = new Vector3(0, 1, 1);
		transform.parent = playerObj.transform;
		transform.localPosition = cameraOffset;
	}
}

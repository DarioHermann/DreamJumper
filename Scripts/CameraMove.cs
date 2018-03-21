using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	GameObject playerObj;
	Vector3 cameraOffset;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 180.0f;
	private float pitch = 0.0f;


	float rotX, rotY;

	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find ("Player");
		cameraOffset = new Vector3(0, 0, 1);
		transform.parent = playerObj.transform;
		transform.localPosition = cameraOffset;
		transform.LookAt (playerObj.transform);

	}
	
	// Update is called once per frame
	/*void Update () {

		/*rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		rotY = Input.GetAxis ("Mouse Y") * 10 * Mathf.Deg2Rad;

		transform.RotateAround (Vector3.up, -rotX);
		transform.RotateAround (Vector3.right, rotY);*/

		/*yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");

		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);*/

		/*transform.position = playerObj.transform.position + cameraOffset;
		transform.LookAt (playerObj.transform);
	}*/
}

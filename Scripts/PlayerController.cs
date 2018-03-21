using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;

	private float z_move;

	float rotX;
	float rotY;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 180.0f;
	private float pitch = 0.0f;

	void Start(){
		;
	}

	void Update(){
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {

			/*rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
			rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;

			transform.RotateAround (Vector3.up, rotX);*/

			yaw += speedH * Input.GetAxis ("Mouse X");
			//pitch -= speedV * Input.GetAxis ("Mouse Y");

			transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);

			moveDirection = new Vector3 (-Input.GetAxis ("Horizontal"), 0, -Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	
	}
}

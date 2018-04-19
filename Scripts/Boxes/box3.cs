using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box3 : MonoBehaviour {

	public Rigidbody rb;
	box2hit1 hitOne;
	GameObject hOne;
	box2hit1 hitTwo;
	GameObject hTwo;
	box2hit1 hitThree;
	GameObject hThree;
	box2hit1 hitFour;
	GameObject hFour;

	private bool heyo = false;

	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		hOne = GameObject.Find ("woodBox 3 Hit 1");
		hitOne = hOne.GetComponent<box2hit1> ();
		hTwo = GameObject.Find ("woodBox 3 Hit 2");
		hitTwo = hTwo.GetComponent<box2hit1> ();
		hThree = GameObject.Find ("woodBox 3 Hit 3");
		hitThree = hThree.GetComponent<box2hit1> ();
		hFour = GameObject.Find ("woodBox 3 Hit 4");
		hitFour = hFour.GetComponent<box2hit1> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (rb.velocity.x != 0.0f || rb.velocity.y != 0.0f || rb.velocity != 0.0f )
			isMoving = true;
		else
			isMoving = false;*/
		if(heyo)
			rb.isKinematic = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "box") {
			//rb.isKinematic = true;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			StartCoroutine (waiter ());
		}
	}

	void FixedUpdate(){
		//if(!isMoving){
		if (hitOne.triggered) {
			Debug.Log ("one");
			if (Input.GetKeyUp (KeyCode.F)) {
				rb.AddForce (-0.5f, 0, 0, ForceMode.Impulse);
			}
		}
		else if (hitTwo.triggered) {
			Debug.Log ("Two");
			if (Input.GetKeyUp (KeyCode.F)) {
				rb.AddForce (0, 0, 0.5f, ForceMode.Impulse);
			}
		}
		else if (hitThree.triggered) {
			Debug.Log ("Three");
			if (Input.GetKeyUp (KeyCode.F)) {
				rb.AddForce (0.5f, 0, 0, ForceMode.Impulse);
			}
		}
		else if (hitFour.triggered) {
			Debug.Log ("Four");
			if (Input.GetKeyUp (KeyCode.F)) {
				rb.AddForce (0, 0, -0.5f, ForceMode.Impulse);
			}
		}
		
		//rb.isKinematic = true;
		//}
	}

	IEnumerator waiter(){
		yield return new WaitForSeconds (3);
		rb.isKinematic = false;

	}
}

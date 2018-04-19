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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;//I use this so the box doesn't fly off when hitting a wall
		hOne = GameObject.Find ("woodBox 2 Hit 1"); //Yes, for some reason, without that, the box just started flying away after hitting the wall
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
		if(heyo)
			rb.isKinematic = true; //this was a test, and now I'm scared to take it out and everything stops working
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "box") {
			rb.constraints = RigidbodyConstraints.FreezeAll;//want to make the boxes stop when hitting each other, but just can't
			StartCoroutine (waiter ()); //And that's the reason why the second time the player tries the second dream, it doesn't really work.
		}
	}

	void FixedUpdate(){ //I use this to make the boxes move, It's a if statement for each side of the cube (that the player can reach)
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
	}

	IEnumerator waiter(){ //Doesn't really work for what I wanted, so just ignore
		yield return new WaitForSeconds (3);
		rb.isKinematic = false;
	}
}

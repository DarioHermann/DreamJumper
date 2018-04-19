using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public Text _text;
	public Text _time;
	public Text _day;

	//Player stats
	public static int energy=0;
	public static int game_time = 0;
	public static int game_day = 1;
	public static bool completedLevelOne = false;
	public static bool completedLevelTwo = false;
	public static bool completedLevelThree = false;
	public static bool completedLevelFour = false;
	public static bool completedLevelFive = false;
	public static bool completedGame = false;

	//public static bool dreamOne, dreamTwo, dreamThree = false;
	public static int maximumEnergy;

	static bool reintroducePos = false;
	private static bool jumpedOutOfDream = false;

	public static bool insideDream= false;

	void Start(){

		if (completedLevelFive) {
			jumpedOutOfDream = false;
			insideDream = false;
			dreamFiveComplete ();
		}
		if (completedLevelFour) {
			jumpedOutOfDream = false;
			insideDream = false;
			dreamFourComplete ();
		}
		if (completedLevelThree) {
			jumpedOutOfDream = false;
			insideDream = false;
			dreamThreeComplete ();
		}
		if (completedLevelTwo) {
			jumpedOutOfDream = false;
			insideDream = false;
			dreamTwoComplete();
		}
		if (completedLevelOne) {
			jumpedOutOfDream = false;
			insideDream = false;
			dreamOneComplete ();
		}

		if (jumpedOutOfDream) {
			jumpedOutOfDream = false;
			if (!npcOneBed.shadMissionDone) {
				openDoors (1);
				transform.position = new Vector3 (24.34f, 10.4f, 37.02f);
			} else {
				openDoors (2);
				transform.position = new Vector3 (-13.66f, 10.4f, 35.25f);
			}
			
		}

	}

	void Update(){
		if (insideDream) {
			if (Input.GetKeyUp (KeyCode.Q)) {
				jumpedOutOfDream = true;
				Application.LoadLevel ("Dream Jumper Scene");
			}
		}

		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {

			yaw += speedH * Input.GetAxis ("Mouse X");

			transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);

			moveDirection = new Vector3 (-Input.GetAxis ("Horizontal"), 0, -Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	
		if (game_time > 24) {
			game_time %= 24;
			game_day++;
		}

		_text.text = "Energy: " + energy + "/3";
		if (game_time < 10)
			_time.text = "0";
		else
			_time.text = "";
		_time.text += (game_time + ":00");

		_day.text = "day " + game_day;

	}

	void dreamOneComplete(){
		if (!insideDream) {
			npcOneBed.shadMissionDone = true;
			transform.position = new Vector3 (24.34f, 10.4f, 37.02f);
			openDoors (1);
		}
	}

	void dreamTwoComplete(){
		if (!insideDream) {
			npcTwoBed.nessMissionDone = true;
			transform.position = new Vector3 (-13.66f, 10.4f, 35.25f);
			openDoors (2);
		}
	}

	void dreamThreeComplete(){
		npcOneBed.shadMissionDone = false;
		npcOneBed.jumpCounter = 1;
		npcTwoBed.nessMissionDone = false;
		npcTwoBed.jumpCounter = 1;
		npcThreeBed.kairiMissionDone = false;
		npcThreeBed.jumpCounter = 1;
		doorOpener.open = false;
		doorOpenerTwo.open = false;
		doorOpenerThree.open = false;
		doorOpenerFour.open = false;
		doorOpenerFive.open = false;
		doorOpenerSix.open = false;
		doorOpenerSeven.open = false;
		doorOpenerEight.open = false;
		doorOpenerNine.open = false;
		completedLevelThree = false;
	}

	void dreamFourComplete(){
		if (!insideDream) {
			npcOneBed.shadMissionDone = true;
			transform.position = new Vector3 (24.34f, 10.4f, 37.02f);
			openDoors (1);
		}
	}

	void dreamFiveComplete(){
		if (!insideDream) {
			npcTwoBed.nessMissionDone = true;
			transform.position = new Vector3 (-13.66f, 10.4f, 35.25f);
			openDoors (2);
		}
	}

	void openDoors (int section){
		if (section >= 1) {
			GameObject corridor1Door = GameObject.Find ("Corridor 1 door mover");
			Animator corridor1DoorAnimation = corridor1Door.GetComponent<Animator> ();
			corridor1DoorAnimation.SetBool ("open", true);
			GameObject room1Door = GameObject.Find ("Room 1 door mover");
			Animator room1DoorAnimation = room1Door.GetComponent<Animator> ();
			room1DoorAnimation.SetBool ("open", true);
			GameObject room2Door = GameObject.Find ("Room 2 door mover");
			Animator room2DoorAnimation = room2Door.GetComponent<Animator> ();
			room2DoorAnimation.SetBool ("open", true);
			GameObject room3Door1 = GameObject.Find ("Room 3 door Right mover");
			if (doorOpenerFour.open) {
				Animator room3Door1Animation = room3Door1.GetComponent<Animator> ();
				room3Door1Animation.SetBool ("open", true);
			}
			GameObject room3Door2 = GameObject.Find ("Room 3 door Left mover");
			if (doorOpenerFive.open) {
				Animator room3Door2Animation = room3Door2.GetComponent<Animator> ();
				room3Door2Animation.SetBool ("open", true);
			}
			completedLevelOne = false;
			completedLevelFour = false;
		}
		if (section >= 2) {
			GameObject corridor2Door = GameObject.Find ("Corridor 2 door mover");
			Animator corridor2DoorAnimation = corridor2Door.GetComponent<Animator> ();
			corridor2DoorAnimation.SetBool ("open", true);
			GameObject room5Door = GameObject.Find ("Room 5 door mover");
			Animator room5DoorAnimation = room5Door.GetComponent<Animator> ();
			room5DoorAnimation.SetBool ("open", true);
			GameObject room6Door1 = GameObject.Find ("Room 6 door Left mover");
			if (doorOpenerEight.open) {
				Animator room6Door1Animation = room6Door1.GetComponent<Animator> ();
				room6Door1Animation.SetBool ("open", true);
			}
			GameObject room6Door2 = GameObject.Find ("Room 6 door Right mover");
			if (doorOpenerNine.open) {
				Animator room6Door2Animation = room6Door2.GetComponent<Animator> ();
				room6Door2Animation.SetBool ("open", true);
			}
			completedLevelTwo = false;
			completedLevelFive = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speakerScript : MonoBehaviour { //This class works as the script for the Speakers inside the house

	bool canTurnOff = false;
	public static bool stoppedSong = false;
	public Text action_text;

	AudioSource _audio;

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource> ();
		if (stoppedSong)
			_audio.Stop ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			canTurnOff = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			canTurnOff = false;
			action_text.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if (canTurnOff) {
			action_text.text = "Press F to turn ";
			if (stoppedSong)
				action_text.text += "On";
			else
				action_text.text += "Off";
			if (Input.GetKeyUp (KeyCode.F)) { //If The player interacts with the speaker can start or stop the song
				if (stoppedSong)
					_audio.Play ();
				else
					_audio.Stop();
				stoppedSong = !stoppedSong;
			}
		}
	}
}

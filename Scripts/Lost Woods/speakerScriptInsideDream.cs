using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speakerScriptInsideDream : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource _audio = GetComponent<AudioSource> (); //This works as the speaker inside the first dream, it will play if the outside Speaker is on
		if (speakerScript.stoppedSong)
			_audio.Stop ();
		
	}
}

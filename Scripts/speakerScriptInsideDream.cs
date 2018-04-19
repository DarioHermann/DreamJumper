using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speakerScriptInsideDream : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource _audio = GetComponent<AudioSource> ();
		if (speakerScript.stoppedSong)
			_audio.Stop ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

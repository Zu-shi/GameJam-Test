﻿using UnityEngine;
using System.Collections;

public class AudioPersist : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectsWithTag("Audio").Length > 1){
			this.GetComponent<AudioSource>().Stop();
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.m)) {
			if (audio.mute)
				audio.mute = false;
			else
				audio.mute = true;
		}
		
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

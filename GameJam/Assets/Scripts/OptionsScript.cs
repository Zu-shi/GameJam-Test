﻿using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {



	private bool menuEnabled = false;

	public float speedAdjust = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//toggle menu on escape key up
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			menuEnabled = !menuEnabled;
		}



	}

	void OnGUI(){
		if (menuEnabled) {
			speedAdjust = GUI.HorizontalSlider( new Rect(Screen.width/2 - 50, Screen.height/2 - 5,
			                                             100, 30), speedAdjust, (float) 0.0, (float) 10.0);
			
			GUI.Label(new Rect(Screen.width/2 - 50 + 110, Screen.height/2 - 5, 100, 30),
			          "Game Speed: " + speedAdjust);
		}
	}

	void OpenOptions() {
		if (menuEnabled == false) {
			menuEnabled = true;
		} else {
			menuEnabled = false;
		}
	}
}
﻿using UnityEngine;
using System.Collections;
using System;

public class MenuKeys : MonoBehaviour {
	public KeyScript keyPrefab;
	public KeyCode newKeyCode;
	//public Vector3 keySize;
	private KeyScript newKey;
	private LevelPreviewScript spriteGetter;
	public LevelPreviewScript previewsPrefab;
	KeyCode[] inputKey = new KeyCode[7];
	string[] levelNames = new string[7];
	// For keeping track of whether or not the preview should be up
	int trackPresses;
	// Use this for initialization
	void Start () {
		newKey = GameObject.Instantiate(keyPrefab);
		newKey.setSprite(newKeyCode);
		newKey.keyCode = newKeyCode;
		newKey.timer = 2f;
		newKey.transform.localScale = new Vector3(50f, 50f, 1f);
		// 0 is skipped because tutorialScene wouldn't give a preview
		inputKey [1] = KeyCode.BackQuote;
		inputKey [2] = KeyCode.Alpha1;
		inputKey [3] = KeyCode.Alpha2;
		inputKey [4] = KeyCode.Alpha3;
		inputKey [5] = KeyCode.Alpha4;
		inputKey [6] = KeyCode.Alpha5;
		
		levelNames [1] = "TutorialScene";
		levelNames [2] = "Level1";
		levelNames [3] = "Level2";
		levelNames [4] = "Level3";
		levelNames [5] = "Level4";
		levelNames [6] = "Level5";
		
		
	}
	
	// Update is called once per frame
	void Update () {
		// Give each a specific key, connect new key to planet object using mask?
		GameObject thisPlanet = this.GetComponent <OrbitingScript> ().mask.gameObject;
		newKey.sourcePlanet = thisPlanet.GetComponent<_Mono> ();
		newKey.alpha = 1f;
		//Debug.Log (thisPlanet.GetComponent<Renderer>().bounds.size.x);
		Vector2 keyPosition = thisPlanet.GetComponent<_Mono>().xy + new Vector2 (thisPlanet.GetComponent<Renderer>().bounds.size.x/2, 0f) * 3f;
		newKey.xy = keyPosition;
		
		//float spriteHalfWidth = planetToKeysMap[potentialPlanet].spriteRenderer.bounds.extents.x;
		//Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * (new Vector2 (planets[i].GetComponent<Renderer>().bounds.extents.x, 0f) + new Vector2(spriteHalfWidth, 0f) * 1.5f);

		//Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * new Vector2 (planets[i].GetComponent<Renderer>().bounds.size.x/2, 0f) * 2f;
		//planetToKeysMap[potentialPlanet].xy = keyPosition;

		// For each array value, check to see if it was pressed
		for (int i = 0; i < inputKey.Length; i++)
		if (Input.GetKeyDown (inputKey [i])) {
			// Checks to see if the same button is being hit a second time
			if(trackPresses == i)
			{
				Application.LoadLevel (levelNames[i]);
				i = inputKey.Length;
			}else{
				if(trackPresses != i)
				{
					previewsPrefab.generatePreview(i);
				}
				trackPresses = i;
				
			}
		}
		/*switch(Input.GetKeyDown(newKeyCode)){
			case(KeyCode.Alpha0):
			Application.LoadLevel ("TutorialScene");
			break;
			case(KeyCode.Alpha1):
			Application.LoadLevel ("Level1");
			break;
			case(KeyCode.Alpha2):
			Application.LoadLevel ("Level2");
			break;
			case(KeyCode.Alpha3):
			Application.LoadLevel ("Level3");
			break;
			case(KeyCode.Alpha4):
			Application.LoadLevel ("Level4");
			break;
			case(KeyCode.Alpha5):
			Application.LoadLevel ("Level5");
			break;
		}*/
	}
}
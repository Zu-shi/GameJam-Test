using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManagerScript : MonoBehaviour {

	public static readonly float LOCKOUT_TIME = 0.5f;
	float[] lockOutP1 = new float[Globals.NUM_KEYS_PER_PLAYER];
	float[] lockOutP2 = new float[Globals.NUM_KEYS_PER_PLAYER];
	KeyUIScript[] keyUIP1 = new KeyUIScript[Globals.NUM_KEYS_PER_PLAYER];
	KeyUIScript[] keyUIP2 = new KeyUIScript[Globals.NUM_KEYS_PER_PLAYER];
	public _Mono p1EffectPrefab;
	public _Mono p2EffectPrefab;
	public KeyUIScript keyUIPrefab;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	AudioSource audioSource;
	public AudioClip p1Audio;
	public AudioClip p2Audio;
	private List<KeyScript> ksToClear; //Temporarily tracks the key scripts that need to be removed due to a transaction.

	public bool p1Active {get; set;}
	public bool p2Active {get; set;}

	void Start () {
		ksToClear = new List<KeyScript>();
		//listUIKeys = new List<KeyUIScript>();

		p1Active = true;
		p2Active = true;

		//player one = left keys
		p1Keys = new KeyCode[Globals.NUM_KEYS_PER_PLAYER];
		p1Keys [0] = KeyCode.BackQuote;
		p1Keys [1] = KeyCode.Alpha1;
		p1Keys [2] = KeyCode.Alpha2;
		p1Keys [3] = KeyCode.Alpha3;
		p1Keys [4] = KeyCode.Alpha4;
		
		//player two  = right keys
		p2Keys = new KeyCode[Globals.NUM_KEYS_PER_PLAYER];
		p2Keys [0] = KeyCode.Alpha6;
		p2Keys [1] = KeyCode.Alpha7;
		p2Keys [2] = KeyCode.Alpha8;
		p2Keys [3] = KeyCode.Alpha9;
		p2Keys [4] = KeyCode.Alpha0;

		//Code to place and scale the graphics for keys
		for(int i = 0; i < Globals.NUM_KEYS_PER_PLAYER; i++){
			KeyUIScript kui = Instantiate(keyUIPrefab);
			keyUIP1[i] = kui;
			kui.setSprite(p1Keys[i]);
			kui.x = -2450 + i % 5 * 200;
			kui.y = -1300;
		}
		
		for(int i = 0; i < Globals.NUM_KEYS_PER_PLAYER; i++){
			KeyUIScript kui = Instantiate(keyUIPrefab);
			keyUIP2[i] = kui;
			kui.setSprite(p2Keys[i]);
			kui.x = 1650 + i % 5 * 200;
			kui.y = -1300;
		}
	}

	void Update () {
		audioSource = GetComponent<AudioSource> ();
		if (p1Active && !Globals.gameOverManager.gameOver) {
			//Be careful modifying the code below, please ensure that you understand how it works.
			for (int i = 0; i < Globals.NUM_KEYS_PER_PLAYER; i++) {
				//Reduce key cooldown
				lockOutP1 [i] -= Time.deltaTime;

				//If a key is pressed for player 1
				if (Input.GetKeyDown (p1Keys [i])) {
					if (lockOutP1 [i] < 0) { //If not under cooldown
						KeyScript targetKs1 = null;
						foreach (KeyScript ks in StateManager.activeKeysList[1]) {
							if (ks.keyCode == p1Keys [i]) { //Try finding the key in the list of active keys
								Instantiate (p1EffectPrefab, ks.targetPlanet.xyz, Quaternion.identity);
								ks.targetPlanet.GetComponent<MaskScript> ().wearer.currentOwner = 1;
								if (!ks.targetPlanet.GetComponent<MaskScript> ().wearer.home) {
									audioSource.clip = p1Audio;
									audioSource.Play ();
									targetKs1 = ks;
								}
							}
						}

						if (targetKs1 != null) {
							//If found, clear all keyScripts currently associated with that planet (since the planet will convert)
							foreach (KeyScript ksTemp in StateManager.activeKeysList[1]) {
								if (ksTemp.targetPlanet.gameObject.Equals (targetKs1.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
								if (ksTemp.sourcePlanet.gameObject.Equals (targetKs1.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
							}
						
							foreach (KeyScript kstc in ksToClear) {
								//Make the key scripts invisible, reset other values
								StateManager.activeKeysList [1].Remove (kstc);
								kstc.alphaDim = -1;
								kstc.alpha = 0f;
								kstc.timer = 0f;
							}
							ksToClear.Clear ();

							//Same must be done for planet 2.
							foreach (KeyScript ksTemp in StateManager.activeKeysList[2]) {
								if (ksTemp.targetPlanet.gameObject.Equals (targetKs1.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
								if (ksTemp.sourcePlanet.gameObject.Equals (targetKs1.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
							}
						
							foreach (KeyScript kstc in ksToClear) {
								StateManager.activeKeysList [2].Remove (kstc);
								kstc.alphaDim = -1;
								kstc.alpha = 0f;
								kstc.timer = 0f;
							}
							ksToClear.Clear ();
						} else {
							//At least one key is wrong, set universal timeout
							//Set cooldown for all keys
							for (int j = 0; j < Globals.NUM_KEYS_PER_PLAYER; j++) {
								lockOutP1 [j] = LOCKOUT_TIME;
								keyUIP1 [j].SetCooldown ();
							}
						}
					}
				}
			}
		}

		if (p2Active && !Globals.gameOverManager.gameOver) {
			//This half is the same as first half, except for second player
			for (int i = 0; i < Globals.NUM_KEYS_PER_PLAYER; i++) {
				lockOutP2 [i] -= Time.deltaTime;
				if (Input.GetKeyDown (p2Keys [i])) {
					if (lockOutP2 [i] < 0) {
						KeyScript targetKs2 = null;
						foreach (KeyScript ks in StateManager.activeKeysList[2]) {
							if (ks.keyCode == p2Keys [i]) {
								Instantiate (p2EffectPrefab, ks.targetPlanet.xyz, Quaternion.identity);
								ks.targetPlanet.GetComponent<MaskScript> ().wearer.currentOwner = 2;
								if (!ks.targetPlanet.GetComponent<MaskScript> ().wearer.home) {
									targetKs2 = ks;
									audioSource.clip = p2Audio;
									audioSource.Play ();
								}
							}
						}

						if (targetKs2 != null) {
							foreach (KeyScript ksTemp in StateManager.activeKeysList[1]) {
								if (ksTemp.targetPlanet.gameObject.Equals (targetKs2.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
								if (ksTemp.sourcePlanet.gameObject.Equals (targetKs2.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
							}
						
							foreach (KeyScript kstc in ksToClear) {
								StateManager.activeKeysList [1].Remove (kstc);
								kstc.alphaDim = -1;
								kstc.alpha = 0f;
								kstc.timer = 0f;
							}
							ksToClear.Clear ();

						
							foreach (KeyScript ksTemp in StateManager.activeKeysList[2]) {
								if (ksTemp.targetPlanet.gameObject.Equals (targetKs2.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
								if (ksTemp.sourcePlanet.gameObject.Equals (targetKs2.targetPlanet.gameObject)) {
									ksToClear.Add (ksTemp);
								}
							}

							foreach (KeyScript kstc in ksToClear) {
								kstc.alphaDim = -1;
								kstc.alpha = 0f;
								kstc.timer = 0f;
								StateManager.activeKeysList [2].Remove (kstc);
							}
							ksToClear.Clear ();
						} else {	
							//At least one key is wrong, set universal timeout
							//Set cooldown for all keys
							for (int j = 0; j < Globals.NUM_KEYS_PER_PLAYER; j++) {
								lockOutP2 [j] = LOCKOUT_TIME;
								keyUIP2 [j].SetCooldown ();
							}
						}
					}
				}
			}
		}
	}
}

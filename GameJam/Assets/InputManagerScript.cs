using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManagerScript : MonoBehaviour {

	public static readonly float LOCKOUT_TIME = 1f;
	float[] lockOutP1 = new float[6];
	float[] lockOutP2 = new float[6];
	KeyUIScript[] keyUIP1 = new KeyUIScript[6];
	KeyUIScript[] keyUIP2 = new KeyUIScript[6];
	public _Mono p1EffectPrefab;
	public _Mono p2EffectPrefab;
	public KeyUIScript keyUIPrefab;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	//public AudioClip transformSound;
	public AudioSource audioSource;
	private List<MaskScript> planetsToClear;
	private List<KeyScript> ksToClear;

	//private List<KeyUIScript> listUIKeys;

	// Use this for initialization
	void Start () {
		planetsToClear = new List<MaskScript>();
		ksToClear = new List<KeyScript>();
		//listUIKeys = new List<KeyUIScript>();

		//player one = left keys
		p1Keys = new KeyCode[6];
		p1Keys [0] = KeyCode.Q;
		p1Keys [1] = KeyCode.W;
		p1Keys [2] = KeyCode.E;
		p1Keys [3] = KeyCode.A;
		p1Keys [4] = KeyCode.S;
		p1Keys [5] = KeyCode.D;
		
		//player one = right keys
		//p2Keys = new KeyCode[6];
		p2Keys = new KeyCode[6];
		p2Keys [0] = KeyCode.I;
		p2Keys [1] = KeyCode.O;
		p2Keys [2] = KeyCode.P;
		p2Keys [3] = KeyCode.J;
		p2Keys [4] = KeyCode.K;
		p2Keys [5] = KeyCode.L;
		
		for(int i = 0; i < 6; i++){
			KeyUIScript kui = Instantiate(keyUIPrefab);
			keyUIP1[i] = kui;
			kui.setSprite(p1Keys[i]);
			kui.x = -2450 + i % 3 * 200;
			kui.y = -1100 - i / 3 * 200;
		}
		
		for(int i = 0; i < 6; i++){
			KeyUIScript kui = Instantiate(keyUIPrefab);
			keyUIP2[i] = kui;
			kui.setSprite(p2Keys[i]);
			kui.x = 2050 + i % 3 * 200;
			kui.y = -1100 - i / 3 * 200;
		}
	}
	
	// Update is called once per frame
	void Update () {
		audioSource = GetComponent<AudioSource>();

		for(int i = 0; i < 6; i++){
			lockOutP1[i] -= Time.deltaTime;
			if(Input.GetKeyDown(p1Keys[i])){
				if(lockOutP1[i] < 0){
					KeyScript targetKs1 = null;
					foreach(KeyScript ks in StateManager.activeKeysDirectory[1] ){
						if(ks.keyCode == p1Keys[i]){
							targetKs1 = ks;
							Instantiate(p1EffectPrefab, ks.targetPlanet.xyz, Quaternion.identity);
							ks.targetPlanet.GetComponent<MaskScript>().wearer.owner = 1;
							audioSource.Play();
							planetsToClear.Add(ks.targetPlanet.GetComponent<MaskScript>());
						}
					}


					//bool deletedAll = false;
					
					foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[1]) {
						if(ksTemp.targetPlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
						if(ksTemp.sourcePlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
					}
					foreach(KeyScript kstc in ksToClear){
						StateManager.activeKeysDirectory[1].Remove(kstc);
						kstc.alphaDim = -1;
						kstc.alpha = 0f;
					}
					ksToClear.Clear();
					
					foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[2]) {
						if(ksTemp.targetPlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
						if(ksTemp.sourcePlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
					}
					foreach(KeyScript kstc in ksToClear){
						StateManager.activeKeysDirectory[2].Remove(kstc);
						kstc.alphaDim = -1;
						kstc.alpha = 0f;
					}
					ksToClear.Clear();
					/*
					if(targetKs1 != null){
						while(deletedAll == false){
							KeyCode deleteKc = targetKs1.keyCode;
							bool found = false;
							foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[1]) {
								if(ksTemp.keyCode == deleteKc){
									targetKs1 = ksTemp;
									found = true;
								}
							}
							if(found == true){
								StateManager.activeKeysDirectory[1].Remove(targetKs1);
								targetKs1.alpha = 0f;
								targetKs1.alphaDim = -1f;
							}else{
								deletedAll = true;
							}
						}
					}*/
					lockOutP1[i] = LOCKOUT_TIME;
					keyUIP1[i].SetCooldown();
				}
			}
		}

		for(int i = 0; i < 6; i++){
			lockOutP2[i] -= Time.deltaTime;
			if(Input.GetKeyDown(p2Keys[i])){
				if(lockOutP2[i] < 0){
					KeyScript targetKs2 = null;
					foreach(KeyScript ks in StateManager.activeKeysDirectory[2] ){
						if(ks.keyCode == p2Keys[i]){
							targetKs2 = ks;
							Instantiate(p2EffectPrefab, ks.targetPlanet.xyz, Quaternion.identity);
							ks.targetPlanet.GetComponent<MaskScript>().wearer.owner = 2;
							audioSource.Play();
						}
					}

					foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[1]) {
						if(ksTemp.targetPlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
						if(ksTemp.sourcePlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
					}
					foreach(KeyScript kstc in ksToClear){
						StateManager.activeKeysDirectory[1].Remove(kstc);
						kstc.alphaDim = -1;
						kstc.alpha = 0f;
					}
					ksToClear.Clear();
					
					foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[2]) {
						if(ksTemp.targetPlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
						if(ksTemp.sourcePlanet.gameObject.Equals(ksTemp.targetPlanet.gameObject) ){
							ksToClear.Add(ksTemp);
						}
					}
					foreach(KeyScript kstc in ksToClear){
						kstc.alphaDim = -1;
						kstc.alpha = 0f;
						StateManager.activeKeysDirectory[2].Remove(kstc);
					}
					ksToClear.Clear();

					//bool deletedAll = false;
					/*
					if(targetKs2 != null){						
						while(deletedAll == false){
							KeyCode deleteKc = targetKs2.keyCode;
							bool found = false;
							foreach(KeyScript ksTemp in StateManager.activeKeysDirectory[2]) {
								if(ksTemp.keyCode == deleteKc){
									targetKs2 = ksTemp;
									found = true;
								}
							}
							if(found == true){
								StateManager.activeKeysDirectory[2].Remove(targetKs2);
								targetKs2.alpha = 0f;
								targetKs2.alphaDim = -1f;
							}else{
								deletedAll = true;
							}
						}
					}
					*/
					lockOutP2[i] = LOCKOUT_TIME;
					keyUIP2[i].SetCooldown();
				}
			}
		}
	}
}

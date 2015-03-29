using UnityEngine;
using System.Collections;

public class InputManagerScript : MonoBehaviour {

	readonly float LOCKOUT_TIME = 1f;
	float[] lockOutP1 = new float[6];
	float[] lockOutP2 = new float[6];
	public _Mono p1EffectPrefab;
	public _Mono p2EffectPrefab;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	//public AudioClip transformSound;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
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
						}
					}
					if(targetKs1 != null){
						StateManager.activeKeysDirectory[1].Remove(targetKs1);
					}
					lockOutP1[i] = LOCKOUT_TIME;
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
					if(targetKs2 != null){
						StateManager.activeKeysDirectory[2].Remove(targetKs2);
					}
					lockOutP2[i] = LOCKOUT_TIME;
				}
			}
		}
	}
}

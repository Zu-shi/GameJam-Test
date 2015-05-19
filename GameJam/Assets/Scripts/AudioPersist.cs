using UnityEngine;
using System.Collections;

public class AudioPersist : MonoBehaviour {

	AudioPersist i;
	AudioSource audio;
	float combo1;
	float combo2;
	float combo3;
	float combo4;
	float combo5;
	float combo6;
	float combo7;
	float combo8;
	float combo9;
	public AudioClip mainClip;
	public AudioClip otherclip;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M))
		if (audio.mute)
			audio.mute = false;
		else
			audio.mute = true;

		if (Input.GetKeyDown (KeyCode.UpArrow))
			combo1 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.UpArrow) && (Time.time<combo1))
			combo2 = Time.time + 1;		
		if (Input.GetKeyDown (KeyCode.DownArrow) && (Time.time<combo2))
			combo3 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.DownArrow) && (Time.time<combo3))
			combo4 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.LeftArrow) && (Time.time<combo4))
			combo5 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.RightArrow) && (Time.time<combo5))
			combo6 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.LeftArrow) && (Time.time<combo6))
			combo7 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.RightArrow) && (Time.time<combo7))
			combo8 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.B) && (Time.time<combo8))
			combo9 = Time.time + 1;
		if (Input.GetKeyDown (KeyCode.A) && (Time.time<combo9)) {
			if (audio.clip=mainClip) {
				audio.clip = otherclip;
				audio.Play();
			}
			else {
				audio.clip = mainClip;
				audio.Play();
			}
		}
	}

	void Awake(){
		if(i==null) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}else 
			Destroy(this);
	}
}

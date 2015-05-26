using UnityEngine;
using System.Collections;

public class AudioPersist : MonoBehaviour {



	AudioPersist i;
	AudioSource myaudio;
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
	double otherplaytime;
	static bool created = false;

	// Use this for initialization
	void Start () {
		myaudio = GetComponent<AudioSource>();
		otherplaytime = 0.0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M))
			if (myaudio.mute)
				myaudio.mute = false;
			else
				myaudio.mute = true;

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
			myaudio.clip = otherclip;
			myaudio.Play();
			otherplaytime = Time.time + 210.0;

		}

		if (otherplaytime < Time.time && otherplaytime != 0.0) {
			myaudio.clip = mainClip;
			myaudio.Play ();
			otherplaytime = 0.0;

		}
	}

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (gameObject);
			created = true;
		} else {
			Destroy (gameObject);
		}
		//if(i==null) {
		//	i = this;
		//	DontDestroyOnLoad(gameObject);
		//}else 
		//	Destroy(gameObject);
	}

	void muteButton(){
		if (myaudio.mute)
			myaudio.mute = false;
		else
			myaudio.mute = true;
	}
}

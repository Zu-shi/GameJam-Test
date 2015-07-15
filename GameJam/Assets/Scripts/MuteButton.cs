using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

	public static MuteButton i;
	public Sprite square;
	public Sprite triangle;
	public bool condition;
	private AudioSource aus;
	//private AudioListener al;
	static bool created;


	private Button mybutton;

	// Use this for initialization
	void Start () {
		aus = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
		//al = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
		mybutton = GetComponent<Button> ();
		mybutton.image.overrideSprite = aus.mute? square : triangle;
	}

	void changeButton(){
		aus.mute = !aus.mute;
		mybutton.image.overrideSprite = aus.mute? square : triangle;
	}
}

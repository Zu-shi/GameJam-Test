using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

	public Sprite square;
	public Sprite triangle;
	public bool condition;
	private bool created;


	private Button mybutton;

	// Use this for initialization
	void Start () {
		mybutton = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeButton(){
		if (condition) {
			mybutton.image.overrideSprite = triangle;
			condition = !condition;
		}else{
			mybutton.image.overrideSprite = square;
			condition = !condition;
		}
	}

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (gameObject);
			created = true;
		} else {
			Destroy (gameObject);
		}
	}
}

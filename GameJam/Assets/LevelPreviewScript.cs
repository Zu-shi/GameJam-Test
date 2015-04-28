using UnityEngine;
using System.Collections;
using System;

public class LevelPreviewScript : MonoBehaviour {
	/*public Sprite levelPreviewSprite;
	private KeyScript inputKey;
	public KeyCode inputKeyCode;
	public Sprite key1;
	public Sprite key2;
	public Sprite key3;
	public Sprite key4;
	public Sprite key5;
	public Sprite key6;
	public Sprite key7;
	public Sprite key8;
	public Sprite key9;
	public Sprite key0;*/
		// Use 
	// Use this for initialization
	void Start () {
		/*
		inputKey.keyCode = inputKeyCode;
		inputKey.timer = 2f;
		switch(inputKeyCode)
		{
		case(KeyCode.Alpha0):
			SpriteRenderer.sprite = key0;
			break;
		case(KeyCode.Alpha1):
			SpriteRenderer.sprite = key1;
			break;
		case(KeyCode.Alpha2):
			SpriteRenderer.sprite = key2;
			break;
		case(KeyCode.Alpha3):
			SpriteRenderer.sprite = key3;
			break;
		case(KeyCode.Alpha4):
			SpriteRenderer.sprite = key4;
			break;
		case(KeyCode.Alpha5):
			SpriteRenderer.sprite = key5;
			break;
		}*/
		// Location of middle of the levelPreviewSprite
		Vector2 previewPosition = new Vector2(70,-20);

	}
	
	// Update is called once per frame
	void Update () {/*
		if(Input.GetKeyDown(inputKeyCode))
		   {
			// Make corresponding sprite
		}
		// How to connect button with sprite?
	/*if(* A different button was pushed*)
		{
		Destroy (levelPreviewSprite);
		}*/

		/*if(bool(levelPreviewSprite) && *button was pushed again*)
		{
		*go to specified scene*
		}*/
	}
}

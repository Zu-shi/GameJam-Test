using UnityEngine;
using System.Collections;
using System;

public class LevelPreviewScript : _Mono {
	public Sprite tutorialSprite;
	public Sprite level1Sprite;
	public Sprite level2Sprite;
	public Sprite level3Sprite;
	public Sprite level4Sprite;
	public Sprite level5Sprite;
	private GameObject levelPreview;
	//Sprite[] levelPreviews = new Sprite[6];
	//Vector3 previewPosition = new Vector3(-175,10,0);
	//Sprite[] levelPreviews = new Sprite[6];

	// Use this for initialization
	void Start () {


		//Vector2 previewPosition = new Vector2(70,-20);
/*
		levelPreviews [0] = tutorialSprite;
		levelPreviews [1] = level1Sprite;
		levelPreviews [2] = level2Sprite;
		levelPreviews [3] = level3Sprite;
		levelPreviews [4] = level4Sprite;
		levelPreviews [5] = level5Sprite;
        */

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void generatePreview(int currentIndex)
	{
		Debug.Log("Case 2");
	switch(currentIndex){
			case (0):
				spriteRenderer.sprite = tutorialSprite;
			break;
			case (1):	
				spriteRenderer.sprite = level1Sprite;
			break;
			case (2):
				spriteRenderer.sprite = level2Sprite;
			break;
			case (3):
				spriteRenderer.sprite = level3Sprite;
			break;
			case (4):
				spriteRenderer.sprite = level4Sprite;
			break;
			case (5):
				spriteRenderer.sprite = level5Sprite;
			break;





		}
	}
}
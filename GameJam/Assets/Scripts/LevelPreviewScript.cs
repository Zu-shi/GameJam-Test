using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LevelPreviewScript : _Mono {
	public Sprite tutorialSprite;
	public Sprite level1Sprite;
	public Sprite level2Sprite;
	public Sprite level3Sprite;
	public Sprite level4Sprite;
	public Sprite level5Sprite;
	private GameObject levelPreview;
	private Text previewText;
	private Image spriteRendererUI;
	//Sprite[] levelPreviews = new Sprite[6];
	//Vector3 previewPosition = new Vector3(-175,10,0);
	//Sprite[] levelPreviews = new Sprite[6];

	// Use this for initialization
	void Start () {
		previewText = GetComponentInChildren<Text> ();
		spriteRendererUI = GetComponentInChildren<Image> ();
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
//		Debug.Log("Case 2");
	switch(currentIndex){
			// Case 0 is ignored because of the initial value of i in MenuKeys
			case (1):
				spriteRendererUI.sprite = tutorialSprite;
				spriteRendererUI.color = Color.white;	
				previewText.text = "TUTORIAL" + System.Environment.NewLine + "Press {~} to continue";
			//Debug.Log(previewText.text);
			break;
			case (2):	
				spriteRendererUI.sprite = level1Sprite;
				spriteRendererUI.color = Color.white;
				previewText.text = "EYES" + System.Environment.NewLine + "Press {1} to continue";
			break;
			case (3):
				spriteRendererUI.sprite = level2Sprite;
				spriteRendererUI.color = Color.white;
			previewText.text = "PASTRY" + System.Environment.NewLine + "Press {2} to continue";
			break;
			case (4):
				spriteRendererUI.sprite = level3Sprite;
				spriteRendererUI.color = Color.white;
				previewText.text = "YOGA" + System.Environment.NewLine + "Press {3} to continue";
			break;
			case (5):
				spriteRendererUI.sprite = level4Sprite;
				spriteRendererUI.color = Color.white;
				previewText.text = "ORRERY" + System.Environment.NewLine + "Press {4} to continue";
			break;
			case (6):
				spriteRendererUI.sprite = level5Sprite;
				spriteRendererUI.color = Color.white;
				previewText.text = "NEUTRON" + System.Environment.NewLine + "Press {5} to continue";	
			break;





		}
	}
}
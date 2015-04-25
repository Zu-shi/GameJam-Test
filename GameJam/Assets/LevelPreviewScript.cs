using UnityEngine;
using System.Collections;

public class LevelPreviewScript : MonoBehaviour {
	public Sprite levelPreviewSprite;
	// Use this for initialization
	void Start () {
		// Location of middle of the levelPreviewSprite
		Vector2 previewPosition = new Vector2(70,-20);
	}
	
	// Update is called once per frame
	void Update () {
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

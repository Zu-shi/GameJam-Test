using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ColorizeSpriteScript : _Mono {

	//public string colorString = "";

	Image image;


	// Use this for initialization
	void Start () {

		image = GetComponent<Image> ();
		image.color = new Color (6/255f, 10/255f, 60/255f, 255/255f);


			/*switch (colorString) {

			case "":
				image.color = Color.white;
				break;

			case "neutral":
				image.color = Globals.PLAYER_NEUTRAL_COLOR;
				break;

			case "player1":
				image.color = Globals.PLAYER_ONE_COLOR;
				break;

			case "player2":
				image.color = Globals.PLAYER_TWO_COLOR;
				break;
			
			default:
				image.color = (Color)Enum.Parse(typeof(Color), colorString);
				break;

			}

		image.color = new Color (image.color.r, image.color.g, image.color.b, 1f);
		*/



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

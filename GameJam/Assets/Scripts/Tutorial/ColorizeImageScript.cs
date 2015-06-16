using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

// attach to a game object with an Image component to programmically change the image color
public class ColorizeImageScript : _Mono {

	public int r, g, b, a;

	//for player1, player2, or neutral color (this is checked first)
	public string colorString = "";
	Image image;


	// Use this for initialization
	void Start () {

		colorString.ToLower (); // make all chars lowercase

		image = GetComponent<Image> ();


			switch(colorString) {

				case "player1":
				image.color = Globals.PLAYER_ONE_COLOR;
				break;
			case "player2":
				image.color = Globals.PLAYER_TWO_COLOR;
				break;
			case "neutral":
				image.color = Globals.PLAYER_NEUTRAL_COLOR;
				break;
		case "green":
			image.color = Color.green;
			break;
			default:
				image.color = new Color (r / 255f, g / 255f, b / 255f, a / 255f);
				break;

			}
		// changes alpha is a > 0
		if (a > 0) {
			
			float r1 = image.color.r;
			float g1 = image.color.g;
			float b1 = image.color.b;
			
			image.color = new Color (r1, g1, b1, a/255f);
			
		}




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

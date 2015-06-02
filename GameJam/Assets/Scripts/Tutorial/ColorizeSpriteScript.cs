using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ColorizeSpriteScript : _Mono {

	public int r, g, b, a;
	
	//for player1, player2, or neutral color (this is checked first)
	public string colorString ="";

	// Use this for initialization
	void Start () {
		
		colorString.ToLower (); // make all chars lowercase	
		
		switch(colorString) {
			
		case "player1":
			spriteRenderer.color = Globals.PLAYER_ONE_COLOR;
			break;
		case "player2":
			spriteRenderer.color = Globals.PLAYER_TWO_COLOR;
			break;
		case "neutral":
			spriteRenderer.color = Globals.PLAYER_NEUTRAL_COLOR;
			break;
		default:
			spriteRenderer.color = new Color (r / 255f, g / 255f, b / 255f, a / 255f);
			break;
		}

		if (a > 0) {
			
			float r1 = spriteRenderer.color.r;
			float g1 = spriteRenderer.color.g;
			float b1 = spriteRenderer.color.b;
			
			spriteRenderer.color = new Color (r1, g1, b1, a/255f);
			
		}
			/*switch (colorString) {

			case "":
				spriteRenderer.color = Color.white;
				break;

			case "neutral":
				spriteRenderer.color = Globals.PLAYER_NEUTRAL_COLOR;
				break;

			case "player1":
				spriteRenderer.color = Globals.PLAYER_ONE_COLOR;
				break;

			case "player2":
				spriteRenderer.color = Globals.PLAYER_TWO_COLOR;
				break;
			
			default:
				spriteRenderer.color = (Color)Enum.Parse(typeof(Color), colorString);
				break;

			}

		spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
		*/



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

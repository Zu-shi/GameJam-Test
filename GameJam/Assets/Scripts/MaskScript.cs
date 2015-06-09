using UnityEngine;
using System.Collections;

public class MaskScript : _Mono {

	public OrbitingScript wearer{get; set;}

	// Use this for initialization
	void Start () {
		Color32 newColor = Color.white;
		switch(wearer.currentOwner){
		case 0: {
			newColor = Globals.PLAYER_NEUTRAL_COLOR;
			break;
		}
		case 1: {
			newColor = Globals.PLAYER_ONE_COLOR;
			break;
		}
		case 2: {
			newColor = Globals.PLAYER_TWO_COLOR;
			break;
		}
		}
		GetComponent<MeshRenderer>().material.color = newColor; 
		GetComponentInChildren<TrailRenderer>().material.SetColor("_TintColor", newColor);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Color32 newColor = Color.white;
		switch(wearer.currentOwner){
			case 0: {
				newColor = Globals.PLAYER_NEUTRAL_COLOR;
				break;
			}
			case 1: {
				newColor = Globals.PLAYER_ONE_COLOR;
				break;
			}
			case 2: {
				newColor = Globals.PLAYER_TWO_COLOR;
				break;
			}
		}
		GetComponent<MeshRenderer>().material.color = newColor; 
		GetComponentInChildren<TrailRenderer>().material.SetColor("_TintColor", newColor);
		*/
	}
}

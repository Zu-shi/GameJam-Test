using UnityEngine;
using System.Collections;

public class BacktoMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Globals.inGame = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			StateManager.ClearActiveKeys();
			//Globals.inGame = false;
			Application.LoadLevel("MainMenu");
		}
	}
}

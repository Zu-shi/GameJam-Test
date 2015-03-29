using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadLevel(){
		Application.LoadLevel ("Level1");
	}

	void Exit () {
		Application.Quit ();
	}
}

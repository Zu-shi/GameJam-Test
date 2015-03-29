using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadLevel1(){
		Application.LoadLevel ("Level1");
	}

	void loadLevel2(){
		Application.LoadLevel ("Level2");
	}

	void Exit () {
		Application.Quit ();
	}
}

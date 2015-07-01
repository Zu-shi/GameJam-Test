using UnityEngine;
using System.Collections;

public class CreditsButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevel( string name ){
		Application.LoadLevel (name);
	}
}

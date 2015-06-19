using UnityEngine;
using System.Collections;

public class ReturnToMain : MonoBehaviour {

//	private bool startedLoad = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButton(0) || Input.anyKeyDown) {
			Application.LoadLevel("MainMenu");
			//startedLoad = true;
		}
		
		
	}

}

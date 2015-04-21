using UnityEngine;
using System.Collections;

public class GameOverTest : MonoBehaviour {
	//private bool startedLoad = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButton(0)) {
			Application.LoadLevel("GameOver1");
			//startedLoad = true;
		}
	}
}

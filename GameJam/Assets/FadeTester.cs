using UnityEngine;
using System.Collections;

public class FadeTester : MonoBehaviour {

	public GameObject Fader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.DownArrow) ) {
			Fader.GetComponent<Fading>().BeginFade(1);
		}
		if( Input.GetKeyDown(KeyCode.UpArrow) ) {
			Fader.GetComponent<Fading>().BeginFade(-1);
		}
	}
}

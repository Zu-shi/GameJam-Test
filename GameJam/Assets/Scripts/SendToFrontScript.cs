using UnityEngine;
using System.Collections;

public class SendToFrontScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Send text to front layer
		GetComponent<Renderer> ().sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

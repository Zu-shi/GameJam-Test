using UnityEngine;
using System.Collections;
using System;

public class MenuKeys : MonoBehaviour {
	public KeyScript keyPrefab;
	public KeyCode newKeyCode;
	private KeyScript newKey;
	// Use this for initialization
	void Start () {
		newKey = GameObject.Instantiate(keyPrefab);
		newKey.setSprite(newKeyCode);
		newKey.keyCode = newKeyCode;
		newKey.timer = 98236507265f;
	}
	
	// Update is called once per frame
	void Update () {
		// Give each a specific key, connect new key to planet object using mask?
		GameObject thisPlanet = this.GetComponent <OrbitingScript> ().mask.gameObject;
		newKey.sourcePlanet = thisPlanet.GetComponent<_Mono> ();
		newKey.alpha = 1f;
		Vector2 keyPosition = gameObject.GetComponent<_Mono>().xy + (-1.5f) * -2f * new Vector2 (gameObject.GetComponent<Renderer>().bounds.size.x/2, 0f) * 2f;
		newKey.xy = keyPosition;
		}
}

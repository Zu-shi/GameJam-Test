using UnityEngine;
using System.Collections;

public class MaskScript : _Mono {

	public OrbitingScript wearer{get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Color32 newColor = Color.white;
		switch(wearer.currentOwner){
			case 0: {
				newColor = new Color32(200, 200, 200, 140);
				break;
			}
			case 2: {
				newColor = new Color32(255, 155, 0, 140);
				break;
			}
			case 1: {
				newColor = new Color32(13, 206, 255, 140); 
				break;
			}
		}
		GetComponent<MeshRenderer>().material.color = newColor; 
		GetComponentInChildren<TrailRenderer>().material.SetColor("_TintColor", newColor);
	}
}

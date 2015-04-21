using UnityEngine;
using System.Collections;

public class MaskScript : _Mono {

	public OrbitingScript wearer{get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(wearer.currentOwner){
		case 0: {GetComponent<MeshRenderer>().material.color = new Color32(200, 200, 200, 1); break;}
		case 2: {GetComponent<MeshRenderer>().material.color = new Color32(255, 155, 0, 1); break;}
		case 1: {GetComponent<MeshRenderer>().material.color = new Color32(13, 206, 255, 1); break;}//SetColor("_SpecColor", Color.red); Debug.Log("red"); break;}
		}
	}
}

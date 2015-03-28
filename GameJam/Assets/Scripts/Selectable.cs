using UnityEngine;
using System.Collections;

public class MenuButton1 : MonoBehaviour
{
	private bool startedLoad = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButton(0)) {
			Application.LoadLevel("Test");
			startedLoad = true;
		}

	}

	function OnMouseDown (){
		Application.LoadLevel ("Test");
	}



}


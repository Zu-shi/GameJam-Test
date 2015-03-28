using UnityEngine;
using System.Collections;

public class Selectable : _Mono
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

	public Clickable Click(float xpos, float ypos){
		Debug.Log("Click");
		Clickable clickObj = Scout(xpos, ypos);
		if(clickObj != null){
			Debug.Log("Clicked on "+ clickObj.name);
		}
		return clickObj;
	}
	
	public Clickable Scout(float xpos, float ypos){
		RaycastHit hitInfo;
		//Debug.Log(transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
		z = -10; //Changing position for Raycasting
		Physics.Raycast(transform.position, new Vector3(0,0,1), out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Clickable"));
		z = 0;
		if(hitInfo.collider == null){
			return null;
		}else{
			if(hitInfo.collider.GetComponent<Clickable>() == null){
				Debug.LogError("Collider did not have a clickable object");
			}
			return hitInfo.collider.GetComponent<Clickable>();
		}
		//(Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers);
	}
	
	
	
}


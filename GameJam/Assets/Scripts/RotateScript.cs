using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	float a = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		a += 2f;
		transform.Rotate(Vector3.right * Time.deltaTime * 30);
		//transform.rotation = Quaternion.Euler(Vector3(0, 0, a - 90));
	}
}

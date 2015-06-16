using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * 30);
		//transform.rotation = Quaternion.Euler(Vector3(0, 0, a - 90));
	}
}

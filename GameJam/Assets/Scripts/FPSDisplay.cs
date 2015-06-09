using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour {

	float timer = 1f;
	int lastFrameCount = 0;

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		int frameCount = Mathf.FloorToInt(1f / Time.deltaTime);
		//GetComponent<GUIText>().text = "FPS: " + frameCount;
		Debug.Log("FPS: " + frameCount);
		/*if(frameCount < lastFrameCount - 15 && timer < 0f){
			timer = 0.5f;
			//Debug.Break();
		}
		lastFrameCount = frameCount;
		*/
	}
}

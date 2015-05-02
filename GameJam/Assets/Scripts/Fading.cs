using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {
	
	public Texture2D fadeOutTexture;   // the texture that will overlay the screen.
	public float fadeSpeed = 0.8f;     // the fading speed
	
	private int drawDepth = -1000;     // the texture's order in the draw hierarchy
	private float alpha = 1.0f;        // the texture's alpha value between 0 and 1
	private int fadeDir = -1;		   // the direction to fade: in = -1 or out = 1
	
	void OnGUI () {
		//	fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//	force (clamp) the number between 0 and 1
		alpha = Mathf.Clamp01 (alpha);
		
		//set color of our Gui
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);	// set the alpha value
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);	//draw the textre to fit the entire screen
		
	}
	
	//	sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);		// return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
	}
	
	public float BeginFade () {
		fadeDir = -1;
		return (fadeSpeed);		// return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
	}
	
	//	OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade to certain scenes
	void OnLevelWasLoaded () {
		// alpha = 1;		// use this if the alpha is not set to 1 by default
		BeginFade (-1); 	// call the fade in function
	}
}	



using UnityEngine;
using System.Collections;

/* Date Modified: 04/27/2015
 * 
 * Description: Causes a gameobject to 'blink' at designated
 * intervals. To use: attach to gameobject, then in another script
 * get this script component from the object and set the public bool 
 * "show" = true to begin the animation.
 */
public class BlinkingAnimationScript : _Mono
{
	// show this game object?
	public bool show { set; get; }

	//float startWait = 0f; // time before blinking starts
	float blinkWait = 0.5f; // time b/t disappearing/reappearing

	// blinking animation started?
	bool started;

	// Use this for initialization
	void Start ()
	{
		started = false;
		show = false;

	}

	void Update ()
	{

		if (show && !started) {
			alpha = 1f;
			StartCoroutine (blinkAnimation ());
			started = true; // animation started
		} else if (!show) {
			StopAllCoroutines ();
			alpha = 0f;
			started = false; // animation stopped
		}
	}

	IEnumerator blinkAnimation ()
	{
		while (show) {
			yield return new WaitForSeconds (blinkWait);
			alpha = 1f;
			yield return new WaitForSeconds (blinkWait);
			alpha = 0f;
		}
	}
}

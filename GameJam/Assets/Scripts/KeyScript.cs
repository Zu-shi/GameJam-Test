using UnityEngine;
using System.Collections;

public class KeyScript : _Mono {
	
	public static readonly float TIMER_MAX = 1.5f; //Minimum time a planet may stay alive
	public Sprite key1;
	public Sprite key2;
	public Sprite key3;
	public Sprite key4;
	public Sprite key5;
	public Sprite key6;
	public Sprite key7;
	public Sprite key8;
	public Sprite key9;
	public Sprite key0;
	public _Mono targetPlanet{ get; set; } //
	public _Mono sourcePlanet{ get; set; } //
	public KeyCode keyCode{ get; set; }
	public float alphaDim; //Controls the dimming of the planet (will decrease to 0 and bring alpha along)
	public float timer = 0f; //stay-alive timer (when this is above one, the key will not fade out)

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(alphaDim > 0){
			//TODO: better fading system
			alpha -= 0.08f;
			alphaDim -= 0.08f;
		}
		z = -100; //required for camera projection
	}
	
	public void setSprite(KeyCode keyCode) {
		this.keyCode = keyCode;
		switch (keyCode) {
		case(KeyCode.BackQuote) :
			spriteRenderer.sprite = key1;
			break;
		case(KeyCode.Alpha1) :
			spriteRenderer.sprite = key2;
			break;
		case(KeyCode.Alpha2) :
			spriteRenderer.sprite = key3;
			break;
		case(KeyCode.Alpha3) :
			spriteRenderer.sprite = key4;
			break;
		case(KeyCode.Alpha4) :
			spriteRenderer.sprite = key5;
			break;
		case(KeyCode.Alpha6) :
			spriteRenderer.sprite = key6;
			break;
		case(KeyCode.Alpha7) :
			spriteRenderer.sprite = key7;
			break;
		case(KeyCode.Alpha8) :
			spriteRenderer.sprite = key8;
			break;
		case(KeyCode.Alpha9) :
			spriteRenderer.sprite = key9;
			break;
		case(KeyCode.Alpha0) :
			spriteRenderer.sprite = key0;
			break;
		}	
	}

}

using UnityEngine;
using System.Collections;

public class KeyUIScript : _Mono {

	//public Sprite dark;
	public float timer{get; set;}
	private _Mono shadow;
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
	public KeyCode keyCode;

	void Start(){
		shadow = gameObject.transform.GetChild(0).gameObject.GetComponent<_Mono>();
	}

	void Update(){
		shadow.alpha = 1f;
		timer -= Time.deltaTime;
		if(timer < 0f){timer = 0;}
		shadow.x = x;
		shadow.y = y - shadow.spriteRenderer.sprite.bounds.center.y * ys;
		shadow.ys = timer / InputManagerScript.LOCKOUT_TIME;
		//alpha = 3f;
		//Debug.Log(alpha);
	}

	public void SetCooldown(){
		timer = InputManagerScript.LOCKOUT_TIME;
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

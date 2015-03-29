using UnityEngine;
using System.Collections;

public class KeyUIScript : _Mono {

	//public Sprite dark;
	public float timer{get; set;}
	private _Mono shadow;
	public Sprite keyQ;
	public Sprite keyW;
	public Sprite keyE;
	public Sprite keyA;
	public Sprite keyS;
	public Sprite keyD;
	public Sprite keyI;
	public Sprite keyO;
	public Sprite keyP;
	public Sprite keyJ;
	public Sprite keyK;
	public Sprite keyL;
	public KeyCode keyCode;

	void Start(){
		shadow = gameObject.transform.GetChild(0).gameObject.GetComponent<_Mono>();
	}

	void Update(){
		shadow.alpha = 0.8f;
		timer -= Time.deltaTime;
		if(timer < 0f){timer = 0;}
		shadow.x = x;
		shadow.y = y - shadow.spriteRenderer.sprite.bounds.center.y * ys;
		shadow.ys = timer / InputManagerScript.LOCKOUT_TIME;
	}

	public void SetCooldown(){
		timer = InputManagerScript.LOCKOUT_TIME;
	}

	public void setSprite(KeyCode keyCode) {
		this.keyCode = keyCode;
		switch (keyCode) {
		case(KeyCode.Q) :
			spriteRenderer.sprite = keyQ;
			break;
		case(KeyCode.W) :
			spriteRenderer.sprite = keyW;
			break;
		case(KeyCode.E) :
			spriteRenderer.sprite = keyE;
			break;
		case(KeyCode.A) :
			spriteRenderer.sprite = keyA;
			break;
		case(KeyCode.S) :
			spriteRenderer.sprite = keyS;
			break;
		case(KeyCode.D) :
			spriteRenderer.sprite = keyD;
			break;
		case(KeyCode.I) :
			spriteRenderer.sprite = keyI;
			break;
		case(KeyCode.O) :
			spriteRenderer.sprite = keyO;
			break;
		case(KeyCode.P) :
			spriteRenderer.sprite = keyP;
			break;
		case(KeyCode.J) :
			spriteRenderer.sprite = keyJ;
			break;
		case(KeyCode.K) :
			spriteRenderer.sprite = keyK;
			break;
		case(KeyCode.L) :
			spriteRenderer.sprite = keyL;
			break;
		}	
	}
}

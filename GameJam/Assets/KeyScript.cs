using UnityEngine;
using System.Collections;

public class KeyScript : _Mono {

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
	public _Mono targetPlanet{ get; set; }
	public KeyCode keyCode{ get; set; }
	public float alphaDim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(alphaDim > 0){
			alpha -= 0.08f;
			alphaDim -= 0.08f;
		}
		z = -100;
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

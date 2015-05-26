using UnityEngine;
using System.Collections;

public class OrbitingScript : _Mono {

	public _Mono planetMask;
	OptionsScript persistentOptions;
	public int currentOwner = 0; //0 is neutral
	public bool home = false; //Is this a home planet?
	readonly int CIRCLE_SIZE = 125;
	float orbitRadius;
	float planetInitialScale;
	GameObject orbit;
	_Mono orbitMono;
	float t;
	float speedAdjust;
	public float period = 2f; //How long it takes for the planet to circle around
	//private float time;
	public _Mono mask { get; set; }
	_Mono keyObject;

	private int ownerOfHome;


	// Use this for initialization
	void Start () {
		if(home){
			ownerOfHome = currentOwner;
		}
		alpha = 0; //This object needs to be invisible.

		//While orbits are visible in the editor, as soon as the game starts we set them to be invisible for aesthetics purposes.
		orbit = gameObject.transform.parent.gameObject;
		orbitMono = orbit.AddComponent<_Mono>();
		orbitMono.alpha = 0f;

		//Creates the graphic representation of this object (this object is invisible, but a mask will be in the same position as this at all times)
		//This circumvents graphic distortion caused by local coordinates.
		mask = _Mono.Instantiate(planetMask);
		mask.GetComponent<MaskScript>().wearer = this;
		mask.tag = "Planet";

		//Time = period / 4f * 3f
		//Debug.Log (mask.GetComponent<TrailRenderer>().time);
		//mask.GetComponent<TrailRenderer>().time = (period / 4f) * 3f;
		//mask.GetComponentInChildren<TrailRenderer>().time = (period / 4f) * 3f;
		// Absolute value for planets going clockwise, that have negative periods............ 1 / game speed

		//keeps track of the default radius from observing where the planet is placed in relation to the orbit.
		orbitRadius = Mathf.Sqrt(Mathf.Pow(localX, 2f) + Mathf.Pow(localY, 2f));
		//Sets the starting t (time value for parametric function outputting position of planet at all frames
		t = Mathf.Atan2(localY, localX);

		//Options (ask Trevor)
		GameObject optionsObj = GameObject.Find ("Options");
		persistentOptions = optionsObj.GetComponent<OptionsScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		//If this is a home planet and it's ownership has changed
		if(currentOwner != ownerOfHome && home){
			if(currentOwner == 1){
				//Player 1 wins, we clear all keys currently used to prevent future bugs with keys
				StateManager.P1ActiveKeys.Clear();
				StateManager.P2ActiveKeys.Clear();
				if(!Globals.gameOverManager.gameOver){
					Globals.gameOverManager.GameOver (1);
				}
			}else{
				//Player 2 wins, we clear all keys currently used to prevent future bugs with keys
				StateManager.P1ActiveKeys.Clear();
				StateManager.P2ActiveKeys.Clear();
				if(!Globals.gameOverManager.gameOver){
					Globals.gameOverManager.GameOver (2);
				}
			}
		}

		float realPeriod = period * persistentOptions.speedAdjust;
		//mask.GetComponentInChildren<TrailRenderer>().time = (Mathf.Abs(realPeriod * 2) / 4f) * 3f;
		//This dynamically controls the size of the "mask", that is, the visual appearance of the object
		if(mask.GetComponent<SpriteRenderer>() != null){
			//2D image
			mask.xys = xys * (orbitMono.xs + orbitMono.ys) / 2f;
		}else{
			//3D image
			mask.xys = xys * (orbitMono.xs + orbitMono.ys) / 2f * CIRCLE_SIZE;
			mask.zs = mask.xs;
		}
		mask.xy = xy; //sets its position
		float frameRate = 1.0f / Time.deltaTime;
		if(Globals.Debug){Debug.Log (frameRate);}
		t += Mathf.PI * 2  / (realPeriod * frameRate) * Globals.GAME_SPEED;
		localY = Mathf.Sin (t) * orbitRadius;
		localX = Mathf.Cos (t) * orbitRadius;
	}
}

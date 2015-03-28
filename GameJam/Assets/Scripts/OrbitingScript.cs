using UnityEngine;
using System.Collections;

public class OrbitingScript : _Mono {

	//public GameObject orbitPrefab;
	public _Mono planetMask;
	//public float radiusOfPlan;

	float orbitRadius;
	float planetInitialScale;
	GameObject orbit;
	_Mono orbitMono;
	float t;
	public float period = 2f;
	_Mono mask;

	// Use this for initialization
	void Start () {
		alpha = 0;
		orbit = gameObject.transform.parent.gameObject;
		orbitMono = orbit.AddComponent<_Mono>();

		mask = _Mono.Instantiate(planetMask);
		mask.tag = "Planet";
		//keeps track of the default readius
		orbitRadius = Mathf.Sqrt(Mathf.Pow(localX, 2f) + Mathf.Pow(localY, 2f));
		t = Mathf.Atan2(localY, localX);

		/*
		//Keeps track of the default scale of the orbit radius
		ORBIT_INITIAL_SCALE = orbitPrefab.transform.localScale.x;
		xscale = orbitMono.xs / ORBIT_INITIAL_SCALE;
		yscale = orbitMono.ys / ORBIT_INITIAL_SCALE;
		*/

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("x" + x + ", y" + y);
		//Debug.Log(angle);
		//angle = 180f - orbitMono.angle;
		mask.xys = xys * (orbitMono.xs + orbitMono.ys) / 2f;
		mask.xy = xy;
		float frameRate = 1.0f / Time.deltaTime;
		t += Mathf.PI * 2  / (period * frameRate) * Globals.GAME_SPEED;
		localY = Mathf.Sin (t) * orbitRadius;
		localX = Mathf.Cos (t) * orbitRadius;
	}
}

using UnityEngine;
using System.Collections;

public class QteScript : _Mono {
	
	public _Mono keyObject;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	
	// Use this for initialization
	void Start () {
		
		//player one = left keys
		p1Keys = new KeyCode[6];
		p1Keys [0] = KeyCode.Q;
		p1Keys [1] = KeyCode.W;
		p1Keys [2] = KeyCode.E;
		p1Keys [3] = KeyCode.A;
		p1Keys [4] = KeyCode.S;
		p1Keys [5] = KeyCode.D;
		
		//player one = right keys
		//p2Keys = new KeyCode[6];
		p2Keys = new KeyCode[6];
		p2Keys [0] = KeyCode.I;
		p2Keys [1] = KeyCode.O;
		p2Keys [2] = KeyCode.P;
		p2Keys [3] = KeyCode.J;
		p2Keys [4] = KeyCode.K;
		p2Keys [5] = KeyCode.L;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject[] planets =  GameObject.FindGameObjectsWithTag ("Planet");
		
		for (int i = 0; i < planets.Length; i++) {
			Vector2 otherPosition = new Vector2 (planets[i].transform.position.x, planets[i].transform.position.y);
			float distance = Utils.PointDistance(xy,otherPosition);
			
			if(distance <= 100 && distance > 0 && !planets[i].gameObject.Equals (this.GetComponent<OrbitingScript>().mask.gameObject))
			{
				// make button picture on right side of the planet
				Vector2 keyPosition = otherPosition + new Vector2 (planets[i].GetComponent<Renderer>().bounds.size.x/2, 0f);
				OrbitingScript os = GetComponent<OrbitingScript>();
				os.showKey(keyObject, keyPosition, KeyCode.Q);
					
			}
			
		}
		
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QteScript : _Mono {

	public KeyScript keyPrefab;
	_Mono keyObject;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	public int owner { get; set; }
	List<GameObject> activePlanets;
	Dictionary<GameObject, KeyScript> planetToKeysMap;
	bool generatedList = false;

	// Use this for initialization
	void Start () {
		activePlanets = new List<GameObject> ();
		planetToKeysMap = new Dictionary<GameObject, KeyScript> ();

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
		if (!generatedList) {	
			foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
				if(!planet.Equals(this.GetComponent<OrbitingScript>().mask.gameObject)){
					KeyScript newKey = GameObject.Instantiate(keyPrefab);
					newKey.alpha = 0f;
					planetToKeysMap.Add(planet, newKey);
					newKey.targetPlanet = planet.GetComponent<_Mono>();
					Debug.Log("gen");
				}
			}
			generatedList = true;
		}

		GameObject[] planets =  GameObject.FindGameObjectsWithTag ("Planet");
		 
		for (int i = 0; i < planets.Length; i++) {
			Vector2 otherPosition = planets[i].GetComponent<_Mono>().xy;//new Vector2 (planets[i].transform.position.x, planets[i].transform.position.y);
			float distance = Utils.PointDistance(xy,otherPosition);
			GameObject thisMaskGo = this.GetComponent<OrbitingScript>().mask.gameObject;
			GameObject foundGo = planets[i];

			if(!foundGo.Equals (thisMaskGo)){
				if(distance <= 100 && distance > 0)
				{  
					//TODO: Friendliness check
					//CHECK for key clashes

					bool alreadyInList = false;
					foreach(KeyScript ks in StateManager.P1ActiveKeys){
						if(ks.Equals(planetToKeysMap[foundGo])){
							alreadyInList = true;
							break;
						}
					}

					if(!alreadyInList){
						KeyCode kc = generateNonClashingKey();
						Debug.Log("starting keycode " + kc);
						// make button picture on right side of the planet
						KeyScript newKey = planetToKeysMap[foundGo];
						newKey.alpha = 1;
						newKey.setSprite(kc);
						StateManager.P1ActiveKeys.Add (newKey);
						//activePlanets.Add (maskGo);
					}

					Debug.Log("moving");
					Vector2 keyPosition = otherPosition + new Vector2 (planets[i].GetComponent<Renderer>().bounds.size.x/2, 0f);
					planetToKeysMap[foundGo].xy = keyPosition;
					
					//OrbitingScript os = GetComponent<OrbitingScript>();
					//os.showKey(keyPosition, KeyCode.Q);
				}else{
					bool alreadyInList = false;
					foreach(KeyScript ks in StateManager.P1ActiveKeys){
						if(ks.Equals(planetToKeysMap[foundGo])){
							alreadyInList = true;
							ks.alpha = 0;
							break;
						}
					}

					if(alreadyInList){
						StateManager.P1ActiveKeys.Remove(planetToKeysMap[planets[i]]);
					}
				}
			}	
		}
		
	}

	KeyCode generateNonClashingKey(){
		//TODO: modify for 2 players
		if (StateManager.P1ActiveKeys.Count >= 6) {
			return Utils.RandomFromArray<KeyCode> (p1Keys);
		} else {
			KeyCode keyCode = KeyCode.Space;
			bool unusedKey = false;
			//int i = 0;
			while(unusedKey == false){
				//i++;
				unusedKey = true;
				keyCode = Utils.RandomFromArray<KeyCode>(p1Keys);
				foreach(KeyScript ks in StateManager.P1ActiveKeys){
					if(keyCode == ks.keyCode){
						unusedKey = false;
						break;
					}
				}
				Debug.Log (keyCode);
			}
			return keyCode;
		}
	}
}
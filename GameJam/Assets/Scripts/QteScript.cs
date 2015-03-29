using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QteScript : _Mono {

	public KeyScript keyPrefab;
	_Mono keyObject;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	public List<KeyCode[]> keys;
	public int owner { get; set; } //0 = neutral, 1 = player 1, 2 = player 2;
	List<GameObject> activePlanets;
	Dictionary<GameObject, KeyScript> planetToKeysMap;
	bool generatedList = false;
	private readonly float MAX_DISTANCE_FOR_DETECTION = 450f; 

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

		keys = new List<KeyCode[]>();
//		keys.Add();
		keys.Add(p1Keys);
		keys.Add(p2Keys);
		//Debug.Log ("L1" + keys[1].Length);
		//Debug.Log ("L2" + keys[2].Length);
		//keys[0] = null;
		//keys[1] = p1Keys;
		//keys[2] = p2Keys;
		
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
//					Debug.Log("gen");
				}
			}
			generatedList = true;
		}

		GameObject[] planets =  GameObject.FindGameObjectsWithTag ("Planet");
		//Debug.Log(planets.Length);
		for (int i = 0; i < planets.Length; i++) {
			Vector2 otherPosition = planets[i].GetComponent<_Mono>().xy;//new Vector2 (planets[i].transform.position.x, planets[i].transform.position.y);
			float distance = Utils.PointDistance(xy,otherPosition);
			GameObject thisMaskGo = this.GetComponent<OrbitingScript>().mask.gameObject;
			GameObject foundGo = planets[i];
			int otherOwner = planets[i].GetComponent<MaskScript>().wearer.owner;
			int thisOwner = gameObject.GetComponent<OrbitingScript>().owner;
			if(!foundGo.Equals (thisMaskGo) && 
			   thisOwner != otherOwner && thisOwner != 0){
				if(distance <= MAX_DISTANCE_FOR_DETECTION && distance > 0)
				{  
					//CHECK for key clashes

					bool alreadyInList = false;
					foreach(KeyScript ks in StateManager.activeKeysDirectory[thisOwner]){
						if(ks.Equals(planetToKeysMap[foundGo])){
							alreadyInList = true;
							break;
						}
					}

					if(!alreadyInList){
						KeyCode kc = generateNonClashingKey(thisOwner);
						Debug.Log("starting keycode " + kc);
						// make button picture on right side of the planet
						KeyScript newKey = planetToKeysMap[foundGo];
						newKey.alpha = 1;
						newKey.alphaDim = -1f;
						newKey.setSprite(kc);
						StateManager.activeKeysDirectory[thisOwner].Add (newKey);
						//activePlanets.Add (maskGo);
					}

					Debug.Log("moving");
					Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * new Vector2 (planets[i].GetComponent<Renderer>().bounds.size.x/2, 0f) * 2f;
					planetToKeysMap[foundGo].xy = keyPosition;
					
					//OrbitingScript os = GetComponent<OrbitingScript>();
					//os.showKey(keyPosition, KeyCode.Q);
				}else{
					bool alreadyInList = false;
					foreach(KeyScript ks in StateManager.activeKeysDirectory[thisOwner]){
						if(ks.Equals(planetToKeysMap[foundGo])){
							alreadyInList = true;
							ks.alphaDim = 1f;
							break;
						}
					}

					if(alreadyInList){
						StateManager.activeKeysDirectory[thisOwner].Remove(planetToKeysMap[planets[i]]);
					}
				}
			}	
		}
		
	}

	KeyCode generateNonClashingKey(int owner){
		//TODO: modify for 2 players
		Debug.Log (owner);
		if (StateManager.activeKeysDirectory[owner].Count >= 6) {
			return Utils.RandomFromArray<KeyCode> (keys[owner - 1]);
		} else {
			KeyCode keyCode = KeyCode.Space;
			bool unusedKey = false;
			//int i = 0;
			while(unusedKey == false){
			//i++;
			unusedKey = true;
				keyCode = Utils.RandomFromArray<KeyCode>(keys[owner - 1]);
			foreach(KeyScript ks in StateManager.activeKeysDirectory[owner]){
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
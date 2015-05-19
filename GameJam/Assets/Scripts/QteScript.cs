using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QteScript : _Mono {
	/// <summary>
	/// This script is attached each planet and stores a key to each other 
	/// planet that becomes visible only when the distance between it and
	/// another planet is less than the specified distance.
	/// </summary>

	public KeyScript keyPrefab;
	KeyCode[] p1Keys;
	KeyCode[] p2Keys;
	public int owner { get; set; } //0 = neutral, 1 = player 1, 2 = player 2;
	public List<KeyCode[]> keys; //A list that contalys p1keys and p2keys. Allows the referencing of the keycodes by player id. 
	Dictionary<GameObject, KeyScript> planetToKeysMap; //Maps each planet to it's usually invisble key.
	bool generateKeyMap = true; //Flag to delay the generation of a list of keys until after all planets called Start()
	public bool customDistance = false; //To be checked to allow detection for custom distances.
	public float MAX_DISTANCE_FOR_DETECTION = 575f; 

	// Use this for initialization
	void Start () {
		if(!customDistance){
			MAX_DISTANCE_FOR_DETECTION = Globals.MAX_DISTANCE_FOR_DETECTION;
		}

		planetToKeysMap = new Dictionary<GameObject, KeyScript> ();
		
		//player one = left keys
		p1Keys = new KeyCode[5];
		p1Keys [0] = KeyCode.BackQuote;
		p1Keys [1] = KeyCode.Alpha1;
		p1Keys [2] = KeyCode.Alpha2;
		p1Keys [3] = KeyCode.Alpha3;
		p1Keys [4] = KeyCode.Alpha4;
		
		//player one = right keys
		p2Keys = new KeyCode[5];
		p2Keys [0] = KeyCode.Alpha6;
		p2Keys [1] = KeyCode.Alpha7;
		p2Keys [2] = KeyCode.Alpha8;
		p2Keys [3] = KeyCode.Alpha9;
		p2Keys [4] = KeyCode.Alpha0;

		keys = new List<KeyCode[]>();
		keys.Add(p1Keys);
		keys.Add(p2Keys);
		//Debug.Log ("L1" + keys[1].Length);
		//Debug.Log ("L2" + keys[2].Length);
	}
	
	// Update is called once per frame
	void Update () {
		//Gets the mask of this orbiting planet
		GameObject thisPlanet = this.GetComponent<OrbitingScript>().mask.gameObject;

		if (generateKeyMap) {
			foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
				if(!planet.Equals(this.GetComponent<OrbitingScript>().mask.gameObject)){
					//Sets each key to be invisible initially
					KeyScript newKey = GameObject.Instantiate(keyPrefab);
					newKey.alpha = 0f;
					//keyPrefab.GetComponent<KeyScript>().spriteScale = new Vector3(30f, 30f, 1f);
					planetToKeysMap.Add(planet, newKey);
					newKey.sourcePlanet = thisPlanet.GetComponent<_Mono>();
					newKey.targetPlanet = planet.GetComponent<_Mono>();
				}
			}
			generateKeyMap = false;
		}

		GameObject[] planets =  GameObject.FindGameObjectsWithTag ("Planet");
		//Debug.Log(planets.Length);
		for (int i = 0; i < planets.Length; i++) {
			Vector2 otherPosition = planets[i].GetComponent<_Mono>().xy;
			float distance = Utils.PointDistance(xy,otherPosition);
			GameObject potentialPlanet = planets[i];
			int otherOwner = planets[i].GetComponent<MaskScript>().wearer.currentOwner;
			int thisOwner = gameObject.GetComponent<OrbitingScript>().currentOwner;

			//Checks to make sure that the two planets we arre interested in have different owners
			if(!potentialPlanet.Equals (thisPlanet) && 
			   thisOwner != otherOwner && thisOwner != 0){
				bool alreadyShowingKey = false;

				//Search the active keys (visible keys) for one that points to this
				foreach(KeyScript ks in StateManager.activeKeysList[thisOwner]){
					//The second condition checks to ensure that this planet does not have another planet influencing it
					//if there is, we don't have to manage the distance of the planet, the other one can
					if(ks.targetPlanet.gameObject.Equals(potentialPlanet) && !ks.sourcePlanet.gameObject.Equals(thisPlanet)){
						alreadyShowingKey = true;
					}
				}
				
				//TODO: logic here may be convoluted
				if(!alreadyShowingKey){
					if(distance <= MAX_DISTANCE_FOR_DETECTION && distance > 0)
					{  
						bool alreadyInList = false;

						//Same as above foreach loop check, except this time we just want to get the keyscript out
						foreach(KeyScript ks in StateManager.activeKeysList[thisOwner]){
							if(ks.Equals(planetToKeysMap[potentialPlanet])){
								alreadyInList = true;
								break;
							}
						}

						if(!alreadyInList){
							//If the keyScript is not showing yet, we generate a keyCode that has not be used and assign it to the keyscript
							KeyCode kc = generateNonClashingKey(thisOwner);
							Debug.Log("starting keycode " + kc);
							KeyScript newKey = planetToKeysMap[potentialPlanet];
							//Make keyscript visible and set it's timer so that it does not fade immediately
							newKey.alpha = 1;
							newKey.timer = KeyScript.TIMER_MAX;
							newKey.alphaDim = -1f;
							newKey.setSprite(kc);
							StateManager.activeKeysList[thisOwner].Add (newKey);
						}

						//TODO
						// make button picture on right side of the planet (this code should be dependent on the size of planet but is possibly not
						//Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * new Vector2 (planets[i].GetComponent<Renderer>().bounds.extents.x, 0f) * 2f;
						float spriteHalfWidth = planetToKeysMap[potentialPlanet].spriteRenderer.bounds.extents.x;
						Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * (new Vector2 (planets[i].GetComponent<Renderer>().bounds.extents.x, 0f) + new Vector2(spriteHalfWidth, 0f) * 1.5f);
						planetToKeysMap[potentialPlanet].xy = keyPosition;
					}else{
						bool canRemoveKey = false;
						foreach(KeyScript ks in StateManager.activeKeysList[thisOwner]){
							if(ks.Equals(planetToKeysMap[potentialPlanet])){
								if(ks.timer <= 0f){
									//If the keyscript is still active but has outlived it's minimal lifetime, we let it start fading by setting alphaDim = 1;
									canRemoveKey = true;
									ks.alphaDim = 1f;
									break;
								}
							}
						}

						if(canRemoveKey){
							//Remove it from the list of keys that are currently visible
							StateManager.activeKeysList[thisOwner].Remove(planetToKeysMap[planets[i]]);
						}else{
							//If the keyScript is not ready to be removed yet, update it's position as usual.
							float spriteHalfWidth = planetToKeysMap[potentialPlanet].spriteRenderer.bounds.extents.x;
							//Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * new Vector2 (planets[i].GetComponent<Renderer>().bounds.size.x/2, 0f) * 2f;
							Vector2 keyPosition = otherPosition + (thisOwner - 1.5f) * -2f * (new Vector2 (planets[i].GetComponent<Renderer>().bounds.extents.x, 0f) + new Vector2(spriteHalfWidth, 0f) * 1.5f);
							planetToKeysMap[potentialPlanet].xy = keyPosition;
						}
					}
				}
			}	
		}
		
	}

	KeyCode generateNonClashingKey(int owner){
		if (StateManager.activeKeysList[owner].Count >= Globals.NUM_KEYS_PER_PLAYER) {
			//If all keys are taken, return a random one
			return Utils.RandomFromArray<KeyCode> (keys[owner - 1]);
		} else {
			KeyCode keyCode = KeyCode.Space; //We will never use Space, but initialization is required to satisfy the compiler
			bool foundUnusedKey = false;
			while(foundUnusedKey == false){
				//This while look uses a brute-force approach to find a key that has not been used yet... can be improved.
				//Note: working with this code can lead to infinitely loops. Make sure you understand what it's trying to do.
				foundUnusedKey = true;
				keyCode = Utils.RandomFromArray<KeyCode>(keys[owner - 1]);
				foreach(KeyScript ks in StateManager.activeKeysList[owner]){
					if(keyCode == ks.keyCode){
						foundUnusedKey = false;
						break;
					}
				}
				//Debug.Log (keyCode);
			}
			return keyCode;
		}
	}

}
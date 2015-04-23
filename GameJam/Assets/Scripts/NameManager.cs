using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Description: This script takes a name from an array of names and
 * assigns the name to a planet mask. However, if the name of the planet's wearer has been 
 * manually changed, that name is kept instead.
 * In order to manually change planet name:
 * 1. Drag "Orbit" prefab onto hierarchy (or use one already in hierarchy)
 * 2. Click on the "Planet" child of the "Orbit"
 * 3. Change name of "Planet" object
 * And now you manually changed the planet name yay!
 */
public class NameManager : MonoBehaviour {

	public GameObject connector;
	public _Mono homeConnectorP1prefab;
	public _Mono homeConnectorP2prefab;
	private _Mono homeConnectorP1;
	private _Mono homeConnectorP2;
	string[] planetNames;
	Dictionary<GameObject, GameObject> planetToName;
	Vector3[] positions;
	bool generatedList = false;
	bool generatedPosition = false;
	int planetCount;

	void Start ()
	{
		// used to get total # of planets
		planetCount = 0;

		// relates a planet object to a name connector object
		planetToName = new Dictionary<GameObject, GameObject> ();

		// array of possible planet names
	 	planetNames = new string[37];

		planetNames [0] = "Hermes";
		planetNames [1] = "Condon";
		planetNames [2] = "Helen";
		planetNames [3] = "Kepler-20a";
		planetNames [4] = "Kepler-20b";
		planetNames [5] = "Ocampa";
		planetNames [6] = "Minerva";
		planetNames [8] = "Wilkening";
		planetNames [7] = "Zoom";
		planetNames [9] = "Scilla";
		planetNames [10] = "Ceres";
		planetNames [11] = "Haumea";
		planetNames [12] = "Eris";
		planetNames [13] = "Makemake";
		planetNames [14] = "Planet";
		planetNames [15] = "Farm";
		planetNames [16] = "Emerion";
		planetNames [17] = "Andromeda";
		planetNames [18] = "Vega";
		planetNames [19] = "Ire";
		planetNames [20] = "Sarina";
		planetNames [21] = "Lewis";
		planetNames [22] = "Zarathustra";
		planetNames [23] = "Onyx";
		planetNames [24] = "Gilgamesh";
		planetNames [25] = "Darwin";
		planetNames [26] = "Media";
		planetNames [27] = "Dune";
		planetNames [28] = "Cookie";
		planetNames [29] = "Polyphemus";
		planetNames [30] = "Best Planet";
		planetNames [31] = "Discworld";
		planetNames [32] = "Arda";
		planetNames [33] = "Luna";
		planetNames [34] = "Tattooine";
		planetNames [35] = "Krypton";
		planetNames [36] = "Qo'noS";
	}

	void Update() {
		// update name text color based on planet owner
		// *Feel free to make colors more visually appealling*
		if (generatedList) {

			foreach (KeyValuePair<GameObject, GameObject> obj in planetToName) {

				OrbitingScript wearer = obj.Key.GetComponent<MaskScript> ().wearer;
				TextMesh textMesh = obj.Value.GetComponentInChildren<TextMesh> ();
				
				if (wearer.currentOwner == 1) {
					textMesh.color = Color.blue; // player 1 color
				} else if (wearer.currentOwner == 2) {
					textMesh.color = Color.yellow; // player 2 color
				} else {
					textMesh.color = Color.gray; // neutral color
				}

			}
		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		// fills planetToName dictionary and assigns name connectors' textfields
		if (!generatedList) {	

			int i = 0;
			foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
				planetCount++;
				GameObject obj = Instantiate(connector, planet.transform.position, Quaternion.identity) as GameObject;
				obj.transform.GetChild(0).GetComponent<_Mono>().alpha = 0.8f;

				// Changes name of planet mask to a name in theif wearer name has not been manually changed
				// If it has been changed, then planet name is set to wearer name 
				OrbitingScript wearer = planet.GetComponent<MaskScript>().wearer;
				if (wearer.name == "Planet") {
					planet.name = planetNames[i];
					i++; // to get next name in array
				} else {
					// assign wearer name to planet if it has been manually changed
					planet.name = wearer.name;
				}

				// relate planet to name label object and set name label text
				planetToName.Add(planet, obj); 
				TextMesh textMesh = planetToName[planet].GetComponentInChildren<TextMesh>();
				textMesh.text = planet.name; // set text of name label to current planet name

				textMesh.color = Color.blue;
			}

			// create positions array to hold offsets for each name label  
			positions = new Vector3[planetCount];
			generatedList = true;

			// (Ask Zuoming) but it does instantiate homeConnector prefabs =D
			homeConnectorP1 = Instantiate(homeConnectorP1prefab);
			homeConnectorP2 = Instantiate(homeConnectorP2prefab);
		}

		// used in generating positions[] values
		int j = 0;

		//keeps name label a constant distance from planet
		foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {

			// get the name label associated with current planet
			GameObject textObj = planetToName[planet];

			// (read comments of getUpperRight)
			Vector3 offset = getUpperRight(planet);

			// check if all positions[] have been set
			if (j == planetCount && !generatedPosition) {
				generatedPosition = true;
			}

			// generate values for positions[] array 
			// if all positions haven't been generated
			if (!generatedPosition) {
				positions[j] = offset;
			}

			// used to check if planet is home & currentOwner
			MaskScript ms = planet.GetComponent<MaskScript>();
			OrbitingScript os = ms.wearer;

			// set position of name label in respect to current planet position
			textObj.transform.position = planet.transform.position + new Vector3(40f, 0f, 0f) + positions[j];

			// if home planet, also set position of home label
			if(os.home && os.currentOwner == 1) {
				homeConnectorP1.xyz = planet.transform.position + new Vector3(-30f, 0f, 0f) + positions[j];
			} else if(os.home && os.currentOwner == 2) {
				homeConnectorP2.xyz = planet.transform.position + new Vector3(-30f, 0f, 0f) + positions[j];
			}

			// get next position to generate (doesn't matter after positions[] are generated)
			j++;
		}
	}

	// returns vector3 which gives the approximate vector which when
	// added to the location vector3 of the GameObject parameter
	// gives the vector3 corresponding to the location of the GameObj
	Vector3 getUpperRight(GameObject obj) {
		Bounds bnd = obj.GetComponent<Renderer> ().bounds;
		return (new Vector3 (bnd.size.x/2, bnd.size.y/2, 0));
	}
}


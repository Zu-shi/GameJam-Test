using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NameManager : MonoBehaviour {

	public GameObject connector;
	string[] planetNames;
	Dictionary<GameObject, GameObject> planetToName;
	Vector3[] positions;
	bool generatedList = false;
	bool generatedPosition = false;
	int planetCount;
	// Use this for initialization
	void Start ()
	{
		planetCount = 0;
		planetToName = new Dictionary<GameObject, GameObject> ();
	 	planetNames = new string[17];

		planetNames [0] = "Home";
		planetNames [1] = "Earth";
		planetNames [2] = "Saturn";
		planetNames [3] = "Mercury";
		planetNames [4] = "Venus";
		planetNames [5] = "Uranus";
		planetNames [6] = "Neptune";
		planetNames [7] = "Mars";
		planetNames [8] = "Jupiter";
		planetNames [9] = "Pluto";
		planetNames [10] = "Ceres";
		planetNames [11] = "Haumea";
		planetNames [12] = "Eris";
		planetNames [13] = "Makemake";
		planetNames [14] = "Planet";
		planetNames [15] = "Farm";
		planetNames [16] = "Emerion";

		int i = 1;
		// assign a name to each planet
		// make a GUI text and sprite for each on right

	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (!generatedList) {	
			int i = 1;
			foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
					planetCount++;
					GameObject obj = Instantiate(connector, planet.transform.position, Quaternion.identity) as GameObject;
					obj.transform.GetChild(0).GetComponent<_Mono>().alpha = 0.8f;
					planet.name = planetNames[i];
					planetToName.Add(planet, obj);
					TextMesh textMesh = planetToName[planet].GetComponentInChildren<TextMesh>();
					textMesh.text = planetNames[i];
					i++;
			}
			positions = new Vector3[planetCount];
			generatedList = true;
		}

		/*if (!generatedPosition) {	
			foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
				Vector3 offset = getUpperRight (planet);
				planetToPosition.Add (planet, offset);
				
			}
			//generatedPosition = true;
		//}*/

		int j = 0;
		//keeps name a constant distance from planet
		foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
			GameObject textObj = planetToName[planet];
			Vector3 offset = getUpperRight(planet);
			if (j == planetCount)
				generatedPosition = true;
			if (!generatedPosition && j < planetCount) {
				positions[j] = offset;
			}
			textObj.transform.position = planet.transform.position + new Vector3(30f, 0f, 0f) + positions[j];
		}
	}

	Vector3 getUpperRight(GameObject obj) {
		Bounds bnd = obj.GetComponent<Renderer> ().bounds;
		//return (new Vector3 (2*bnd.extents.x/3 - bnd.size.x/7, 2*bnd.extents.y/3 - bnd.size.y/7, 0));
		return (new Vector3 (bnd.size.x/2, bnd.size.y/2, 0));
	}
}


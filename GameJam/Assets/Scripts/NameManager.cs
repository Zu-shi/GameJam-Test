using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	// Use this for initialization
	void Start ()
	{
		planetCount = 0;
		planetToName = new Dictionary<GameObject, GameObject> ();

	 	planetNames = new string[37];

		planetNames [0] = "Hermes";
		planetNames [1] = "Condon";
		planetNames [2] = "Helen";
		planetNames [3] = "Kepler-20a";
		planetNames [4] = "Kepler-20b";
		planetNames [5] = "Ocampa";
		planetNames [6] = "Minerva";
		planetNames [8] = "Wilkening";
		planetNames [7] = "Zuos";
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
			homeConnectorP1 = Instantiate(homeConnectorP1prefab);
			homeConnectorP2 = Instantiate(homeConnectorP2prefab);
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
			textObj.transform.position = planet.transform.position + new Vector3(40f, 0f, 0f) + positions[j];
			if(planet.GetComponent<MaskScript>().wearer.home && planet.GetComponent<MaskScript>().wearer.owner == 1){
				homeConnectorP1.xyz = planet.transform.position + new Vector3(-30f, 0f, 0f) + positions[j];
			}else if(planet.GetComponent<MaskScript>().wearer.home && planet.GetComponent<MaskScript>().wearer.owner == 2){
				homeConnectorP2.xyz = planet.transform.position + new Vector3(-30f, 0f, 0f) + positions[j];
			}
		}
	}

	Vector3 getUpperRight(GameObject obj) {
		Bounds bnd = obj.GetComponent<Renderer> ().bounds;
		//return (new Vector3 (2*bnd.extents.x/3 - bnd.size.x/7, 2*bnd.extents.y/3 - bnd.size.y/7, 0));
		return (new Vector3 (bnd.size.x/2, bnd.size.y/2, 0));
	}
}


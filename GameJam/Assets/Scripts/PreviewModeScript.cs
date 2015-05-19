using UnityEngine;
using System.Collections;

public class PreviewModeScript : MonoBehaviour {
	static bool previewMode;
	public Camera mainCam;
	// Use this for initialization
	void Start () {
		previewMode = true;
		if (previewMode) {
			SpriteRenderer[] rendererComponents = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
			for(int i = 0; i < rendererComponents.Length; i++)
			{
				rendererComponents[i].enabled = false;
			}

			ParticleSystem[] particleComponents = FindObjectsOfType(typeof(ParticleSystem)) as ParticleSystem[];
			for(int i = 0; i < particleComponents.Length; i++)
			{
				particleComponents[i].enableEmission = false;
			}

			Light[] lightComponents = FindObjectsOfType(typeof(Light)) as Light[];
			for(int i = 0; i < lightComponents.Length; i++)
			{
				lightComponents[i].enabled = false;
			}
			NameManager[] nameLabels = FindObjectsOfType(typeof(NameManager)) as NameManager[];
			for(int i = 0; i < nameLabels.Length; i++)
			{
				nameLabels[i].enabled = false;
			}

			//mainCam = GetComponent<Camera>();
			mainCam.backgroundColor = Color.black;
			//main.backgroundColor = Color.black;
			//Camera mainCamera = GetComponent<Camera>();
			//mainCamera.backgroundColor = Color.black;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

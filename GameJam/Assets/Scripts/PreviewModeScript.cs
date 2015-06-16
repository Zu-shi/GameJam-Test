using UnityEngine;
using System.Collections;

public class PreviewModeScript : MonoBehaviour {
	static bool previewMode;
	public Camera mainCam;
	//public float setTrailTime;
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
			InputManagerScript[] inputs = FindObjectsOfType(typeof(InputManagerScript)) as InputManagerScript[];
			for(int i = 0; i < inputs.Length; i++)
			{
				inputs[i].enabled = false;
			}
			QteScript[] keyDisabling = FindObjectsOfType(typeof(QteScript)) as QteScript[];
			for(int i = 0; i < keyDisabling.Length; i++)
			{
				keyDisabling[i].enabled = false;
			}
			//Debug.Log(keyDisabling.Length);
			//mainCam = GetComponent<Camera>();
			mainCam.backgroundColor = new Color(0.02f, 0, 0.02f, 1);

			/*TrailRenderer[] trails = FindObjectsOfType(typeof(TrailRenderer)) as TrailRenderer[];
			for(int i = 0; i < trails.Length; i++)
			{
			trails[i].time = setTrailTime;
			}
			*/
			//InputManagerScript inputScript = GetComponent<InputManagerScript>();
			//inputScript.enabled = false;



			/*
			InputManagerScript[] inputTracker = FindObjectsOfType(typeof(InputManagerScript)) as InputManagerScript;
			for(int i = 0; i < inputTracker.Length; i++)
			{
				inputScript = GetComponent(InputManagerScript);
				inputTracker[i].enabled = false;
			}
			*/
			//main.backgroundColor = Color.black;
			//Camera mainCamera = GetComponent<Camera>();
			//mainCamera.backgroundColor = Color.black;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

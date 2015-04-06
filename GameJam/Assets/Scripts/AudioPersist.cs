using UnityEngine;
using System.Collections;

public class AudioPersist : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectsWithTag("Audio").Length > 1){
			this.GetComponent<AudioSource>().Stop();
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsScript : MonoBehaviour {


	public static OptionsScript i;
	private bool menuEnabled = false;

	public float speedAdjust = 1;

	// Use this for initialization
	void Start () {
		StateManager.P1ActiveKeys.Clear();
		StateManager.P2ActiveKeys.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		//toggle menu on escape key up
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			menuEnabled = !menuEnabled;
		}



	}

	void OnGUI(){
		if (menuEnabled) {
			speedAdjust = GUI.HorizontalSlider( new Rect(Screen.width/2 - 50, Screen.height/2 - 5,
			                                             100, 30), speedAdjust, (float) 0.1, (float) 10.0);
			
			GUI.Label(new Rect(Screen.width/2 - 50 + 110, Screen.height/2 - 5, 100, 30),
			          "Game Speed: " + speedAdjust);
		}
	}

	void OpenOptions() {
		if (menuEnabled == false) {
			menuEnabled = true;
		} else {
			menuEnabled = false;
		}
	}

	void Awake(){
		if(i==null) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}else 
			Destroy(this);
	}

	public void loadLevel( string name ){
		Application.LoadLevel (name);
	}

	public void OpenCredits() {
		print ("come on");
		Debug.Log ("before load");
		Application.LoadLevel ("Credits");
		Debug.Log ("after load");
	}
}

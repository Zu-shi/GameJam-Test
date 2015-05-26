using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Date Modified: 05/02/2015
 * 
 * Description: Manages the Text component on object it is attached to.
 * Also resizes the gameobject in respect to its parent. If the parent
 * changes, so does this object. (Designed for the parent object to be
 * the background image of the text object).
 */
public class TutorialGUITextScript : _Mono
{

	public bool intro { get; set; }

	// hold string reps of HTML form hexidecimal color
	// form: #XXXXXX
	string p1HexColor, p2HexColor, titleHexColor;

	// the text component of this object
	public Text theText { get; private set; }

	// holds this recttransform and parent's recttransform
	RectTransform thisRect;

	//RectTransform parentRect;

	// keep track of screen resize
	float screenW, screenH;

	void Awake ()
	{

		// Get the #hexcode form of each players' color
		p1HexColor = "#" + colorToHex (Globals.PLAYER_ONE_COLOR);
		p2HexColor = "#" + colorToHex (Globals.PLAYER_TWO_COLOR);

		// Get title's #hexcode right now it is just neutral color  T^T
		// feel free to make a global variable for title color and change this
		titleHexColor = "#" + colorToHex (Globals.PLAYER_NEUTRAL_COLOR);

		thisRect = GetComponent<RectTransform> ();
		//parentRect = GetComponentInParent<RectTransform> ();
		theText = GetComponent<Text> ();

	}
	// Use this for initialization
	void Start ()
	{
		// check if this object is the tutorial intro text object
		if (gameObject.name.Equals ("IntroText")) {
			intro = true;
		} else
			intro = false;
	}

	// Update is called once per frame
	void Update ()
	{

		// check if intro and if screen width or height change then scale text accordingly
		if (intro && (screenW != Screen.width || screenH != Screen.height)) {
			
			screenW = Screen.width;
			screenH = Screen.height;
			resize ();
			
		}
		
	}

	// shows text object and parent (which is the background)
	public void activate ()
	{
		
		gameObject.SetActive (true);
		gameObject.transform.parent.gameObject.SetActive (true);
	}

	// hides text object and parent/BG
	public void deactivate ()
	{
		
		gameObject.SetActive (false);
		gameObject.transform.parent.gameObject.SetActive (false);
	}
	

	// sets current text to string parameter; rich text and best fit auto-enabled
	// "Player 1" and "Player 2" are automatically color-coded :)
	public void setText (string txt)
	{

		if (txt.Contains ("Player 1")) {
			string replacement = "<color=" + p1HexColor + ">Player 1</color>";
			txt = txt.Replace ("Player 1", replacement);
		}

		if (txt.Contains ("Player 2")) {
			string replacement = "<color=" + p2HexColor + ">Player 2</color>";
			txt = txt.Replace ("Player 2", replacement);
		}

		/*
		if (txt.ToUpper ().Contains ("STELLAR LEAP")) {
			string replacement = "<color=" + titleHexColor + ">STELLAR LEAP</color>";
			txt = txt.ToUpper ().Replace ("STELLAR LEAP", replacement);
		}
		*/

		if (txt.Contains ("P1")) {
			string replacement = "<color=" + p1HexColor + ">P1</color>";
			txt = txt.Replace ("P1", replacement);
		}
		if (txt.Contains ("P2")) {
			string replacement = "<color=" + p2HexColor + ">P2</color>";
			txt = txt.Replace ("P2", replacement);
		}


		theText.text = txt;

		theText.supportRichText = true;
		theText.resizeTextForBestFit = true;
		
	}

	// resize intro text based on screen size & parent panel scale
	void resize ()
	{
		//Vector2 parentSize = parentRect.rect.size;

		// this can definitely be improved (somehow)...
		float aspectRatio = screenH / screenW; // width * ratio = height
		float w = screenW * 0.7f;
		thisRect.sizeDelta = new Vector2 (w, w * aspectRatio);
			
	}

	// Takes in a color parameter and returns a string representation of the color in XXXXXX form
	// Color32 is used instead of Color because a Color.r returns a float rather than a byte,
	// which can't be converted into a hexidecimal string
	public string colorToHex (Color32 color)
	{
		// the "X2" parameter converts the given number to a two digit hexidecimal string
		string hex = color.r.ToString ("X2") + color.g.ToString ("X2") + color.b.ToString ("X2");
		return hex;
	}

	// converts keycode to string and handles special cases
	// feel free to add more special cases
	public string keycodeToString(KeyCode keyCode) {

		string str = keyCode.ToString();
		
		// handle weirdly named keycodes
		if (str.Contains ("Alpha"))
			str = str [5].ToString ();
		
		if (str.Equals ("BackQuote"))
			str = "~";

		return str;
	}
}

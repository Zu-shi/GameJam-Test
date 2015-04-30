using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Date Modified: 04/27/2015
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
	RectTransform parentRect, thisRect;

	// keep track of screen resize
	float screenW, screenH;

	void Awake ()
	{

		// Get the #hexcode form of each players' color
		p1HexColor = "#" + colorToHex (Color.blue);
		p2HexColor = "#" + colorToHex (Color.yellow);

		// Get title's #hexcode
		Color orange = new Color (255.0f / 255, 140.0f / 255, 0f / 255);
		titleHexColor = "#" + colorToHex (orange);

		thisRect = GetComponent<RectTransform> ();
		parentRect = GetComponentInParent<RectTransform> ();
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

		if (txt.ToUpper ().Contains ("STELLAR LEAP")) {
			string replacement = "<color=" + titleHexColor + ">STELLAR LEAP</color>";
			txt = txt.ToUpper ().Replace ("STELLAR LEAP", replacement);
		}


		theText.text = txt;

		theText.supportRichText = true;
		theText.resizeTextForBestFit = true;
		
	}

	// resize intro text based on screen size & parent panel scale
	void resize ()
	{
		
		RectTransform thisRect = gameObject.GetComponent<RectTransform> ();
		RectTransform parentRect = gameObject.GetComponentInParent<RectTransform> ();
		Vector2 parentSize = parentRect.rect.size;

		// this can definitely be improved (somehow)...
		float aspectRatio = screenH / screenW; // width * ratio = height
		float w = screenW * 0.68f;
		thisRect.sizeDelta = new Vector2 (w, w * aspectRatio);
			
	}

	// Takes in a color parameter and returns a string representation of the color in XXXXXX form
	// Color32 is used instead of Color because a Color.r returns a float rather than a byte,
	// which can't be converted into a hexidecimal string
	string colorToHex (Color32 color)
	{
		// the "X2" parameter converts the given number to a two digit hexidecimal string
		string hex = color.r.ToString ("X2") + color.g.ToString ("X2") + color.b.ToString ("X2");
		return hex;
	}
}

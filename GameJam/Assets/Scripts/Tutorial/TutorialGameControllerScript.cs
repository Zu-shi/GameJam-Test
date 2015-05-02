using UnityEngine;
using System.Collections;

/* Date Modified: 04/27/2015
 * 
 * Description: This script initially pauses the TutorialScene so
 * that initial instructions can be shown. On pressing a button ("1" 
 * for now), the game starts up and is then controlled by
 * TutorialPlanetScript. This script also contains public functions
 * to pause and start the game.
 * 
 * It also does more stuff that I don't feel like typing out right
 * now. . .
 */
public class TutorialGameControllerScript : _Mono
{

	// find (GUI Text) gameobjects to access text component
	public GameObject p1Instruct, p2Instruct, introObj;
	GameObject p1Arrow, p2Arrow, introPanel;
	TutorialGUITextScript p1Text, p2Text, introText;
	
	// tracks whether the instructions for each player
	// has been shown and completed
	bool p1Complete, p2Complete;
	
	// all needed to access certain variables
	OrbitingScript orbScript;
	OptionsScript os;
	InputManagerScript im;

	// speeds to pause/start the game
	float pauseSpeed = 1000;
	float startSpeed = Globals.GAME_SPEED;

	// keep track of if game is paused
	public bool paused { get; set; } 

	// keeps track of which tutorial scenes have been completed
	public bool[] sceneComplete { get; set; }

	// if panel is scaled
	bool scaled;

	void Awake ()
	{

		// initialize sceneComplete array
		// 0 = opening screen
		// 1 = introduce the keys for each player
		// 2 = player 1 instruction
		// 3 = player 2 instruction
		sceneComplete = new bool[4];

		// since nothing has been completed
		for (int i = 0; i < sceneComplete.Length; i ++)
			sceneComplete [i] = false;
	}

	// Use this for initialization
	void Start ()
	{
		// initially hide player instructions
		p1Text = p1Instruct.GetComponent<TutorialGUITextScript> ();
		p1Text.deactivate ();
		p2Text = p2Instruct.GetComponent<TutorialGUITextScript> ();
		p2Text.deactivate ();

		introPanel = GameObject.Find ("IntroPanel");

		// get references of arrows that point to buttons on screen
		p1Arrow = GameObject.Find ("p1Arrow");
		p2Arrow = GameObject.Find ("p2Arrow");

		// get necessary components
		orbScript = GetComponent<OrbitingScript> ();
		os = GameObject.Find ("Options").GetComponent<OptionsScript> ();
		im = GameObject.Find ("InputManager").GetComponent<InputManagerScript> ();

		// pause game until player clicks enter button to start
		pauseGame ();

		// show tutorial intro
		introText = introObj.GetComponent<TutorialGUITextScript> ();

		scaled = false;

	}
	
	// Update is called once per frame
	void Update ()
	{

		// change startSpeed depending of if player changes speed manually
		if (os.speedAdjust < pauseSpeed && os.speedAdjust != startSpeed) {
			startSpeed = os.speedAdjust;
			Debug.Log ("Start Speed Changed = " +startSpeed);
		}
	
		// start game on "1" press
		if (!sceneComplete [0]) {
			// don't allow player to manually change game speed until after game starts
			// can't do this^ yet because menuEnabled is private in OptionsScript but one day...
			firstInstruct ();

		} else {
			if (!sceneComplete [1]) {

				secondInstruct ();
			}
		}

		// When home-planet 1 gets close enough to planet pause
		// game then have UI box appear with instructions
		if (sceneComplete [1]) {
			if (!sceneComplete [2]) {
				//im.p2Active = false; //disable p2 input
				p1 ();

				// if player 2's button appears first then show this message
				/*if (StateManager.P2ActiveKeys.Count > 0) {
					p2Text.activate ();
					p2Text.setText ("Player 2, you have to wait :( it's Player 1's turn first (just for the tutorial)!");
				}*/
			}

			if (!sceneComplete [3]) {
				//im.p1Active = false; //disable p1 input
				p2 ();
			
			}
		}
	}

	public void pauseGame ()
	{
		paused = true;
		Debug.Log ("game paused");
		os.speedAdjust = pauseSpeed;
	}

	public void startGame ()
	{
		paused = false;
		Debug.Log ("game started, game speed = "+startSpeed);
		os.speedAdjust = startSpeed;

	}

	void firstInstruct ()
	{

		if (!scaled) {

			RectTransform introRect = introPanel.GetComponent<RectTransform> ();
			introRect.localScale = new Vector3 (0.7f, 0.8f, 0);

			// get a bigger font for the title and smaller font for less important things
			int bigFontSize = (int)(introText.theText.fontSize * 1.4);
			int smallFontSize = (int)(introText.theText.fontSize * 0.7);

			// scary but just a bunch of text formatted via rich text (HTML-like styling) - not all HTML styles permitted
			introText.setText ("<size=" + bigFontSize + "><color=green>WELCOME TO</color> STELLAR LEAP</size>\n"
				+ "This is a 2-player game.  Player 1 and Player 2.\n"
				+ "<size=" + smallFontSize + ">(i.e. You should <color=red>have a friend</color> to play this with)</size>\n\n"
				+ "When the planets get close together, <color=red>a key will appear</color>.\n"
				+ "<color=red>Press that key</color> (if it's in your color) to capture the planet.\n\n"
				+ "<color=green>To win:</color> <color=red>Capture</color> your opponent's <color=red>home planet</color>\n"
				+ "<size=" + smallFontSize + ">(and protect your own)</size>\n\n"
				+ "<color=grey><size=" + smallFontSize + ">press any key to continue</size></color>");
			scaled = true;
		}

		if (Input.anyKeyDown) {
			scaled = false;
			sceneComplete [0] = true;
		}

	}

	void secondInstruct ()
	{

		if (!scaled) {
			
			int bigFontSize = (int)(introText.theText.fontSize * 1.4);

			RectTransform introRect = introPanel.GetComponent<RectTransform> ();
			introRect.localScale = introRect.localScale * 0.7f;
		
			TutorialGUITextScript textScript = introPanel.transform.GetChild (0).GetComponent<TutorialGUITextScript> ();
			textScript.setText ("Each player has their own set of keys. The keys that appear on the screen "
				+ "to capture a planet are randomly generated from your set so make sure to press the correct one!\n\n"
				+ "If you don't, you'll have to wait a while before you can click another key.\n\n"
				+ "<size=" + bigFontSize + "><color=red>READY?!</color></size>\n\n"
				+ "Press 'B' to go back to the previous instruction or\nPress any other key to begin!");
			// start blinking arrows
			showArrows (true);
			scaled = true;
		}

		if (Input.anyKeyDown) {

			// stop blinking arrows
			showArrows (false);

			// go back if 'b' else start game
			if (Input.GetKey (KeyCode.B)) {
				Debug.Log ("B pressed");
				scaled = false;
				sceneComplete [0] = false;
				
			} else {

				startGame ();
				introText.deactivate ();
				sceneComplete [1] = true;
				

			}
		}
	}

	void p1 ()
	{
		if (StateManager.P1ActiveKeys.Count > 0) {
			
			if (!paused) {

				pauseGame ();
			}
			
			p1Text.activate ();
			// get whichever key is showing and convert to string
			string str = StateManager.P1ActiveKeys [0].keyCode.ToString ();
			
			// handle weirdly named keycodes
			if (str.Contains ("Alpha"))
				str = str [5].ToString ();
			
			if (str.Equals ("BackQuote"))
				str = "~";
			
			// tell player 1 which button to press to capture planet
			p1Text.setText ("Player 1, press the \"" + str + "\" key to capture the planet!");
				
		}
		
		if (StateManager.P1ActiveKeys.Count == 0 && p1Instruct.activeSelf) {
			p1Text.deactivate ();
			p2Text.deactivate ();
			startGame (); 
			
			sceneComplete [2] = true;
			
			// reactivate p2 input
			im.p2Active = true;

		}
		
	}
	
	void p2 ()
	{
		if (StateManager.P2ActiveKeys.Count > 0) {
			
			if (!paused) {
				pauseGame ();
			}
			
			p2Text.activate ();
			// get whichever key is showing and convert to string
			string str = StateManager.P2ActiveKeys [0].keyCode.ToString ();
			
			// handle weirdly named keycodes
			if (str.Contains ("Alpha"))
				str = str [5].ToString ();
			
			if (str.Equals ("BackQuote"))
				str = "~";
			
			// tell player 1 which button to press to capture planet
			p2Text.setText ("Player 2, press the \"" + str + "\" key to capture the planet!");
			
			
		}
		
		if (StateManager.P2ActiveKeys.Count == 0 && p2Instruct.activeSelf) {
			p2Text.deactivate ();

			startGame (); 
			
			sceneComplete [3] = true;
			
			// reactivate p1 input
			im.p1Active = true;

			
		}
	}

	void showArrows (bool show)
	{
		p1Arrow.GetComponent<BlinkingAnimationScript> ().show = show;
		p2Arrow.GetComponent<BlinkingAnimationScript> ().show = show;

	}
}

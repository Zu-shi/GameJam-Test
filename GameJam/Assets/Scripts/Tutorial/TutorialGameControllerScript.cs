﻿using UnityEngine;
using System.Collections;

/* Date Modified: 05/8/2015
 * 
 * Description: This script initially pauses the TutorialScene so
 * that initial instructions can be shown. On pressing any button
 * other than "b", the game starts up and is then controlled by
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
	OptionsScript os;
	InputManagerScript im;
	BacktoMain btm;

	// speeds to pause/start the game
	float pauseSpeed = 1000;
	float startSpeed;

	// keep track of if game is paused
	public bool paused { get; set; } 

	// keeps track of which tutorial scenes have been completed
	public bool[] sceneComplete { get; set; }

	// if panel is scaled
	bool scaled;

	// if p1 or p2 press first during battleeelelelelel
	bool p1Pressed, p2Pressed;
	// keycodes for the battleeellelelellele
	KeyCode p1Code, p2Code;

	float timer = 3f;

	void Awake ()
	{
		
		// initialize sceneComplete array
		// 0 = opening screen
		// 1 = introduce the keys for each player
		// 2 = player 1 instruction
		// 3 = player 2 instruction
		// 4 = battle :O!!!!
		// 5 = end battle text
		sceneComplete = new bool[6];

		// since nothing has been completed
		for (int i = 0; i < sceneComplete.Length; i ++)
			sceneComplete [i] = false;
	}

	// Use this for initialization
	void Start ()
	{
		p1Code = new KeyCode ();
		p2Code = new KeyCode ();
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
		im = GameObject.Find ("InputManager").GetComponent<InputManagerScript> ();
		btm = GameObject.Find ("GameOverManager").GetComponent<BacktoMain> ();

		// disable pressing 'enter' to go to main menu for opening screen
		btm.enabled = false;

		startSpeed = Globals.speedAdjust;

		if (startSpeed >= pauseSpeed)
			startSpeed = 1;

		// pause game until player clicks enter button to start
		pauseGame ();

		// show tutorial intro
		introText = introObj.GetComponent<TutorialGUITextScript> ();

		scaled = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		if (Globals.menuEnabled)
			Globals.menuEnabled = false;
		*/
		if (btm.enabled && Input.GetKeyDown (KeyCode.Return)) {

			Globals.speedAdjust = startSpeed;

		}

		// change startSpeed depending of if player changes speed manually
		if (Globals.speedAdjust < pauseSpeed && Globals.speedAdjust != startSpeed) {
			startSpeed = Globals.speedAdjust;
			Debug.Log ("Start Speed Changed = " +startSpeed);
		}
	
		if (!sceneComplete [0]) {
			firstInstruct ();

		} else {
			if (!sceneComplete [1]) {

				secondInstruct ();
			}
		}

		// When home-planet 1 gets close enough to planet pause
		// game then have UI box appear with instructions
		if (sceneComplete [1]) {

			if (!btm.enabled)
				btm.enabled = true;

			if (!sceneComplete [2]) {
				p1 (); //p1 instruction
			}

			if (!sceneComplete [3]) {
				p2 (); //p2 instruction
			
			}

			if (sceneComplete[2] && sceneComplete[3] && !sceneComplete[4]) {
				battle(); //when p1 and p2 have to fight for a planet
			} else if (!sceneComplete[5]) {
				setEndBattleText(); //set text of thing under certain conditions
			}
		}
	}

	public void pauseGame ()
	{
		paused = true;
		Debug.Log ("game paused");
		Globals.speedAdjust = pauseSpeed;
	}

	public void startGame ()
	{
		paused = false;
		Debug.Log ("game started, game speed = "+startSpeed);
		Globals.speedAdjust = startSpeed;

	}

	void firstInstruct ()
	{

		if (!scaled) {

			RectTransform introRect = introPanel.GetComponent<RectTransform> ();
			introRect.localScale = new Vector3 (0.7f, 0.8f, 0);

			// get a bigger font for the title and smaller font for less important things
			int bigFontSize = (int)(introText.theText.fontSize * 1.5 - 1f);
			int smallFontSize = (int)(introText.theText.fontSize * 0.7);

			// scary but just a bunch of text formatted via rich text (HTML-like styling) - not all HTML styles permitted
			introText.setText ("<size=" + bigFontSize + ">WELCOME TO STELLAR LEAP</size>\n"
				+ "This is a 2 player game. Player 1 and Player 2.\n"
				+ "<size=" + smallFontSize + ">(so play this with a friend!)</size>\n\n"
			    + "Each player has a home planet. From that planet, you capture other planets, "
			    + "with the goal of capturing your opponent's home planet.\n\n"
				+ "When an occupied planet approaches another planet, <color=red>a key will appear</color>."
				+ "The key will be next to the planet you are <color=green>going</color> to capture.\n\n"
			    + "If the key is in your color (P1 or P2), press it on the keyboard!\n\n"
				+ "<color=green>To win:</color> <color=red>Capture</color> your opponent's <color=red>home planet</color>\n"
				+ "while protecting your own.\n\n"
				+ "<color=grey><size=" + smallFontSize + ">press any key to continue</size></color>");
			scaled = true;
		}

		//check for input of any keyboard key
		if (Input.anyKeyDown 
		    && !Input.GetKeyDown(KeyCode.Mouse0)
		    && !Input.GetKeyDown(KeyCode.Mouse1)
		    && !Input.GetKeyDown(KeyCode.Mouse2)
		    && !Input.GetKeyDown(KeyCode.Mouse3)
		    && !Input.GetKeyDown(KeyCode.Mouse4)
		    && !Input.GetKeyDown(KeyCode.Mouse5)
		    && !Input.GetKeyDown(KeyCode.Mouse6)) {

			scaled = false;
			sceneComplete [0] = true;
		}

	}

	void secondInstruct ()
	{

		if (!scaled) {
			
			int bigFontSize = (int)(introText.theText.fontSize * 1.4f - 1f);
			int smallFontSize = (int)(introText.theText.fontSize * 0.8f - 1f);

			RectTransform introRect = introPanel.GetComponent<RectTransform> ();
			introRect.localScale = introRect.localScale * 0.7f;
		
			TutorialGUITextScript textScript = introPanel.transform.GetChild (0).GetComponent<TutorialGUITextScript> ();
			textScript.setText ("Each player has their own set of keys. The keys that appear on the screen "
				+ "to capture a planet are randomly generated from your set so make sure to press the correct one!\n\n"
				+ "If you don't, you'll have to wait a while before you can press another key.\n\n"
				+ "<size=" + bigFontSize + "><color=red>READY?!</color></size>\n\n"
				+ "<size=" + smallFontSize + ">Press 'B' to go back to the previous instruction\n"
			    + "Press 'Enter' at any time to return to the main menu</size>\n"
			    + "<color=red>Press any other key to begin!</color>");
			// start blinking arrows
			showArrows (true);
			scaled = true;
		}

		// check for input of any keyboard key
		if (Input.anyKeyDown 
		    && !Input.GetKeyDown(KeyCode.Mouse0)
		    && !Input.GetKeyDown(KeyCode.Mouse1)
		    && !Input.GetKeyDown(KeyCode.Mouse2)
		    && !Input.GetKeyDown(KeyCode.Mouse3)
		    && !Input.GetKeyDown(KeyCode.Mouse4)
		    && !Input.GetKeyDown(KeyCode.Mouse5)
		    && !Input.GetKeyDown(KeyCode.Mouse6)) {

			// stop blinking arrows
			showArrows (false);

			// go back if 'b' else start game
			if (Input.GetKey (KeyCode.B)) {

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
			string str = p1Text.keycodeToString(StateManager.P1ActiveKeys [0].keyCode);
			
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
			string str = p2Text.keycodeToString(StateManager.P2ActiveKeys[0].keyCode);
			
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

	void battle() {

		if (StateManager.P2ActiveKeys.Count > 0 && StateManager.P1ActiveKeys.Count > 0) {

			// using p1 text obj instead of making new game object because I can
			p1Text.activate ();
			p1Text.setText ("<color=green>Both</color> players can capture a planet"
			                +"\n<color=red>Do it as fast as you can!</color>");

			if (!paused) {
				
				pauseGame ();
			}
			
			p1Code = StateManager.P1ActiveKeys [0].keyCode; 
			p2Code = StateManager.P2ActiveKeys [0].keyCode; 

			Debug.Log (p1Code + "   " + p2Code);

		} else {
			
			p1Pressed = Input.GetKeyDown (p1Code);
			p2Pressed = Input.GetKeyDown (p2Code);
			
			Debug.Log(p1Pressed + "   " +p2Pressed);
		
		}


		if (p1Pressed || p2Pressed) { 

			StartCoroutine(p1DisappearAfterX());
			sceneComplete[4] = true;
		
		}
	}

	void setEndBattleText() {


		int countDown = (int)Mathf.Floor (timer + 0.5f) + 1;

		if (p1Pressed || p2Pressed) timer -= Time.deltaTime;
		
		if (p1Pressed) {
			
			p1Text.setText ("P1 captured the planet!\n P2, protect your home!\n<color=red>"+countDown+"</color>");
			
		}
		
		else if (p2Pressed) {
			
			p1Text.setText ("P2 captured the planet!\n P1, protect your home!\n<color=red>"+countDown+"</color>");
			
		}


		if (countDown == 0)
			sceneComplete[5] = true;

	}

	void showArrows (bool show)
	{
		p1Arrow.GetComponent<BlinkingAnimationScript> ().show = show;
		p2Arrow.GetComponent<BlinkingAnimationScript> ().show = show;

	}

	// used only for p1Text or p2Text
	public IEnumerator p1DisappearAfterX() {
		yield return new WaitForSeconds (timer);
		p1Text.deactivate ();
		startGame ();
		StopCoroutine (p1DisappearAfterX ());


	}

	public IEnumerator p2DisappearAfterX() {
		yield return new WaitForSeconds (timer);
		p2Text.deactivate ();
		startGame ();
		StopCoroutine (p2DisappearAfterX ());
	}
}

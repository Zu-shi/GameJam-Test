using UnityEngine;
using System.Collections;
using System;

public class Globals {
	public static readonly float GAME_SPEED = 0.5f;
	public static float MAX_DISTANCE_FOR_DETECTION = 575f;
	public static int NUM_KEYS_PER_PLAYER = 5;
	public static readonly Color PLAYER_ONE_COLOR = new Color32(13, 206, 255, 140);
	public static readonly Color PLAYER_TWO_COLOR = new Color32(255, 155, 0, 140);
	public static readonly Color PLAYER_ONE_ARROW_COLOR = new Color32(0, 251, 251, 140);
	public static readonly Color PLAYER_TWO_ARROW_COLOR = new Color32(215, 217, 2, 140);
	public static readonly Color PLAYER_NEUTRAL_COLOR = new Color32(200, 200, 200, 140);
	public static readonly Color PLAYER_NEUTRAL_NAME_COLOR = new Color32(41, 144, 49, 140);
	public static GameOverManager gameOverManager{get{return GameObject.Find ("GameOverManager").GetComponent<GameOverManager>();}}
	public static NameManager nameManager{get{return GameObject.Find ("NameManager").GetComponent<NameManager>();}}
	public static Boolean inGame{get{return !Application.loadedLevelName.Contains("MainMenu");}}
	public static string PLAYER_ONE_HOME_NAME;
	public static string PLAYER_TWO_HOME_NAME;
	public static float speedAdjust = 1f;
	public static bool Debug = false;
}
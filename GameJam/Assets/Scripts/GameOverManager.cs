using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class GameOverManager : _Mono {

	public GameObject gameOverGuiPrefab;
	private GameObject gui;
	private Image menu;
	private Text text;
	private bool _gameOver = false;
	public bool gameOver{
		get{return _gameOver;}
		//set{_gameOver = value;}
	}

	public void GameOver(int winner){
		_gameOver = true;
		gui = Instantiate (gameOverGuiPrefab); 
		menu = gui.transform.GetChild(0).GetComponent<Image>();
		text = menu.transform.GetChild(0).GetComponent<Text>();
		
		menu.color = new Color(1f, 1f, 1f, 0f);
		Color c = new Color(1f, 1f, 1f, 0.7f);
		menu.DOColor(c, 3f);
		
		text.color = new Color(1f, 1f, 1f, 0f);
		Color textc = new Color(1f, 1f, 1f, 1f);
		text.DOColor(textc, 3f);

		text.text = "Player " + winner + " wins! Press SPACE to return to main menu";
	}

	void Start() {
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if(!_gameOver)
				GameOver (1);
			else
				Application.LoadLevel("MainMenu");
		}
	}
}

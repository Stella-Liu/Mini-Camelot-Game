using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool isWhiteTurn;
	public Board game;
	public BoardState state;

	string sceneName = null;

	// Use this for initialization
	void Start () {
		//sceneName = mainMenu;
		sceneName = SceneManager.GetActiveScene().name;
	}

	// Update is called once per frame
	void Update () {
		if (sceneName != SceneManager.GetActiveScene ().name) {
			game = (Board)FindObjectOfType(typeof(Board));
			state = (BoardState)FindObjectOfType(typeof(BoardState));
			state.board = game.board;
			sceneName = SceneManager.GetActiveScene().name;
		}

		if (sceneName == "Game") {
			if (state == null) {
				state = new BoardState ();
			}
			if (!isWhiteTurn) {
				//state.AlphaBeta (state);
			}
		}
	}

	public void WinByCapture()	{
		//if one side has 0 pieces left && the other side has more than 2 pieces left
		int aliveBlack = game.blackPiece.Count;//6
		int aliveWhite = game.whitePiece.Count;//6

		for (int i = 0; i < game.blackPiece.Count; i++) {
			if (game.blackPiece [i].isKilled == true) {
				aliveBlack--;
			}
		}
		for (int i = 0; i < game.whitePiece.Count; i++) {
			if (game.whitePiece [i].isKilled == true) {
				aliveWhite--;
			}
		}

		if (aliveBlack == 0 && aliveWhite > 2) {
			Debug.Log ("You Win");
		} else if (aliveWhite == 0 && aliveBlack > 2) {
			Debug.Log ("Computer Win");
		} else if (aliveWhite == 1 && aliveBlack == 1) {
			Debug.Log ("Draw");
		}
	}

	public void WinByCastle(){
		//if both squares of the opponent's castle is filled, we have a winner
		if (state.board [0, 3] == 1 && state.board [0, 4] == 1) {
			Debug.Log ("You Win");
		} else if (state.board [13, 3] == 2 && state.board [13, 4] == 2) {
			Debug.Log ("Computer Win");
		}
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

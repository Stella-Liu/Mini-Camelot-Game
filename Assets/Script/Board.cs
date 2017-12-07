using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState{
	bool isWhiteTurn;
	int[,] board;
	float valueNode;
	public BoardState parent;
	public BoardState[] children;
}

public class Board : MonoBehaviour {
	public Piece whitePrefab;
	public Piece blackPrefab;
	public Tile tilePrefab;
	int[,] board;

	public bool isWhiteTurn;
	//isWhiteTurn = true (Human Plays)
	//isWhiteTurn = false (Computer Plays)

	void Start(){
		//forcedPieces = new List<Piece> ();
		GenerateBoard();
	}

	void Update(){
		
	}

	void GenerateBoard(){
		//Generate white pieces
		Instantiate(whitePrefab, new Vector3(0.8f, -2.4f, 0.1f), Quaternion.identity);
		Instantiate(whitePrefab, new Vector3(-0.8f, -2.4f, 0.1f), Quaternion.identity);
		Instantiate(whitePrefab, new Vector3(2.4f, -4.0f, 0.1f), Quaternion.identity);
		Instantiate(whitePrefab, new Vector3(0.8f, -4.0f, 0.1f), Quaternion.identity);
		Instantiate(whitePrefab, new Vector3(-0.8f, -4.0f, 0.1f), Quaternion.identity);
		Instantiate(whitePrefab, new Vector3(-2.4f, -4.0f, 0.1f), Quaternion.identity);

		//Generate black pieces
		Instantiate(blackPrefab, new Vector3(0.8f, 2.4f, 0.1f), Quaternion.identity);
		Instantiate(blackPrefab, new Vector3(-0.8f, 2.4f, 0.1f), Quaternion.identity);
		Instantiate(blackPrefab, new Vector3(2.4f, 4.0f, 0.1f), Quaternion.identity);
		Instantiate(blackPrefab, new Vector3(0.8f, 4.0f, 0.1f), Quaternion.identity);
		Instantiate(blackPrefab, new Vector3(-0.8f, 4.0f, 0.1f), Quaternion.identity);
		Instantiate(blackPrefab, new Vector3(-2.4f, 4.0f, 1.0f), Quaternion.identity);

		//Generate tiles for the board
		for (int j = 1; j < 8; j+=2) {
			for (int i = 1; i < 8; i+=2) {
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);
				Instantiate (tilePrefab, qua1, Quaternion.identity);
				Instantiate (tilePrefab, qua2, Quaternion.identity);
				Instantiate (tilePrefab, qua3, Quaternion.identity);
				Instantiate (tilePrefab, qua4, Quaternion.identity);
			}
		}
		for (int i = 5; i > 0; i=i-2) {
			for(int j = 9; j < 10; j+=2){
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);
				Instantiate (tilePrefab, qua1, Quaternion.identity);
				Instantiate (tilePrefab, qua2, Quaternion.identity);
				Instantiate (tilePrefab, qua3, Quaternion.identity);
				Instantiate (tilePrefab, qua4, Quaternion.identity);
			}
		}
		for (int i = 3; i > 0; i=i-2) {
			for(int j = 11; j < 12; j+=2){
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);
				Instantiate (tilePrefab, qua1, Quaternion.identity);
				Instantiate (tilePrefab, qua2, Quaternion.identity);
				Instantiate (tilePrefab, qua3, Quaternion.identity);
				Instantiate (tilePrefab, qua4, Quaternion.identity);
			}
		}
		for (int i = 1; i > 0; i=i-2) {
			for(int j = 13; j < 14; j+=2){
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);
				Instantiate (tilePrefab, qua1, Quaternion.identity); //white castle
				Instantiate (tilePrefab, qua2, Quaternion.identity); //white castle
				Instantiate (tilePrefab, qua3, Quaternion.identity); //black castle
				Instantiate (tilePrefab, qua4, Quaternion.identity); //black castle
			}
		}
	}

	void ValidMove(){ 
		//Pieces are allowed to move one square in all directions on the board as long as the spot is empty

		//Jump over one enemy to capture
		
	}

	void Capture(){ //Jump Move Obligated whenever possible
		//find out which specific piece it is that has been captured
		//piece.killed();

		//check if win by capture if the person capturing 
		//has more than 2 pieces alive
		//WinByCapture();

		//check if both players have only 1 piece left
		//Draw();
	}

	void WinByCapture()	{
		//if one side has 0 pieces left && the other side has more than 2 pieces left
		//we have a winner
		//display winner
	}

	void WinByCastle(){
		//if both squares of the opponent's castle is filled, we have a winner
		//display winner
	}

}

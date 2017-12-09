using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	public Piece whitePrefab;
	public Piece blackPrefab;
	public Tile tilePrefab;

	public int[,] board;
	List<Tile> tiles;
	List<Piece> whitePiece;
	List<Piece> blackPiece;

	void Start(){
		board = new int[14,8];
		tiles = new List<Tile>();
		whitePiece = new List<Piece>();
		blackPiece = new List<Piece>();
		GenerateBoard();
		fillBoardArray ();
	}

	void Update(){

	}

	void GenerateBoard(){
		//Generate white pieces
		Piece wPiece1 = Instantiate(whitePrefab, new Vector3(0.8f, -2.4f, 0.1f), Quaternion.identity);
		Piece wPiece2 = Instantiate(whitePrefab, new Vector3(-0.8f, -2.4f, 0.1f), Quaternion.identity);
		Piece wPiece3 = Instantiate(whitePrefab, new Vector3(2.4f, -4.0f, 0.1f), Quaternion.identity);
		Piece wPiece4 = Instantiate(whitePrefab, new Vector3(0.8f, -4.0f, 0.1f), Quaternion.identity);
		Piece wPiece5 = Instantiate(whitePrefab, new Vector3(-0.8f, -4.0f, 0.1f), Quaternion.identity);
		Piece wPiece6 = Instantiate(whitePrefab, new Vector3(-2.4f, -4.0f, 0.1f), Quaternion.identity);
		whitePiece.Add (wPiece1);
		whitePiece.Add (wPiece2);
		whitePiece.Add (wPiece3);
		whitePiece.Add (wPiece4);
		whitePiece.Add (wPiece5);
		whitePiece.Add (wPiece6);

		//Generate black pieces
		Piece bPiece1 = Instantiate(blackPrefab, new Vector3(0.8f, 2.4f, 0.1f), Quaternion.identity);
		Piece bPiece2 = Instantiate(blackPrefab, new Vector3(-0.8f, 2.4f, 0.1f), Quaternion.identity);
		Piece bPiece3 = Instantiate(blackPrefab, new Vector3(2.4f, 4.0f, 0.1f), Quaternion.identity);
		Piece bPiece4 = Instantiate(blackPrefab, new Vector3(0.8f, 4.0f, 0.1f), Quaternion.identity);
		Piece bPiece5 = Instantiate(blackPrefab, new Vector3(-0.8f, 4.0f, 0.1f), Quaternion.identity);
		Piece bPiece6 = Instantiate(blackPrefab, new Vector3(-2.4f, 4.0f, 1.0f), Quaternion.identity);
		blackPiece.Add (bPiece1);
		blackPiece.Add (bPiece2);
		blackPiece.Add (bPiece3);
		blackPiece.Add (bPiece4);
		blackPiece.Add (bPiece5);
		blackPiece.Add (bPiece6);

		//Generate tiles for the board
		for (int j = 1; j < 8; j+=2) {
			for (int i = 1; i < 8; i+=2) {
				//Location of tiles
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);

				//Create tiles at location
				Tile temp1 = Instantiate (tilePrefab, qua1, Quaternion.identity);
				Tile temp2 = Instantiate (tilePrefab, qua2, Quaternion.identity);
				Tile temp3 = Instantiate (tilePrefab, qua3, Quaternion.identity);
				Tile temp4 = Instantiate (tilePrefab, qua4, Quaternion.identity);

				//Add tiles to list
				tiles.Add (temp1);
				tiles.Add (temp2);
				tiles.Add (temp3);
				tiles.Add (temp4);
			}
		}
		for (int i = 5; i > 0; i=i-2) {
			for(int j = 9; j < 10; j+=2){
				//Location of tiles
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);

				//Create tiles at location
				Tile temp1 = Instantiate (tilePrefab, qua1, Quaternion.identity);
				Tile temp2 = Instantiate (tilePrefab, qua2, Quaternion.identity);
				Tile temp3 = Instantiate (tilePrefab, qua3, Quaternion.identity);
				Tile temp4 = Instantiate (tilePrefab, qua4, Quaternion.identity);

				//Add tiles to list
				tiles.Add (temp1);
				tiles.Add (temp2);
				tiles.Add (temp3);
				tiles.Add (temp4);
			}
		}
		for (int i = 3; i > 0; i=i-2) {
			for(int j = 11; j < 12; j+=2){
				//Location of tiles
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);

				//Create tiles at location
				Tile temp1 = Instantiate (tilePrefab, qua1, Quaternion.identity);
				Tile temp2 = Instantiate (tilePrefab, qua2, Quaternion.identity);
				Tile temp3 = Instantiate (tilePrefab, qua3, Quaternion.identity);
				Tile temp4 = Instantiate (tilePrefab, qua4, Quaternion.identity);

				//Add tiles to list
				tiles.Add (temp1);
				tiles.Add (temp2);
				tiles.Add (temp3);
				tiles.Add (temp4);
			}
		}
		for (int i = 1; i > 0; i=i-2) {
			for(int j = 13; j < 14; j+=2){
				//Location of tiles
				Vector3 qua1 = new Vector3(i*0.8f, j*0.8f, 0.0f);
				Vector3 qua2 = new Vector3(i*-0.8f, j*0.8f, 0.0f);
				Vector3 qua3 = new Vector3(i*-0.8f, j*-0.8f, 0.0f);
				Vector3 qua4 = new Vector3(i*0.8f, j*-0.8f, 0.0f);

				//Create tiles at location
				Tile temp1 = Instantiate (tilePrefab, qua1, Quaternion.identity); //white castle
				Tile temp2 = Instantiate (tilePrefab, qua2, Quaternion.identity); //white castle
				Tile temp3 = Instantiate (tilePrefab, qua3, Quaternion.identity); //black castle
				Tile temp4 = Instantiate (tilePrefab, qua4, Quaternion.identity); //black castle

				//Add tiles to list
				tiles.Add (temp1);
				tiles.Add (temp2);
				tiles.Add (temp3);
				tiles.Add (temp4);
			}
		}
	}

	void fillBoardArray(){
		if (tiles != null) {
			for (int i = 0; i < 88; i++) {
				//get tiles position x
				double posX = (double)(tiles [i].transform.position.x);
				//get tiles position y
				double posY = (double)(tiles [i].transform.position.y);
				//change tiles position to 2d array 
				int arrX = (int)(0.5 * (posX/0.8) + 3.5);
				int arrY = (int)(-0.5 * (posY/0.8) + 6.5);
				//all tiles value are zero to represent they are empty
				board [arrY, arrX] = 0;
			}

			for (int i = 0; i < 6; i++) {
				double posX = (double)(whitePiece [i].transform.position.x);
				double posY = (double)(whitePiece [i].transform.position.y);
				//change tiles position to 2d array 
				int arrX = (int)(0.5 * (posX/0.8) + 3.5);
				int arrY = (int)(-0.5 * (posY/0.8) + 6.5);
				//human piece is represented by 1
				board [arrY, arrX] = 1;
			}

			for (int i = 0; i < 6; i++) {
				double posX = (double)(blackPiece [i].transform.position.x);
				double posY = (double)(blackPiece [i].transform.position.y);
				//change tiles position to 2d array 
				int arrX = (int)(0.5 * (posX/0.8) + 3.5);
				int arrY = (int)(-0.5 * (posY/0.8) + 6.5);
				//computer piece is represented by 2
				board [arrY, arrX] = 2;
			}

			board [0, 0] = -1;
			board [0, 1] = -1;
			board [0, 2] = -1;
			board [0, 5] = -1;
			board [0, 6] = -1;
			board [0, 7] = -1;
			board [1, 0] = -1;
			board [1, 1] = -1;
			board [1, 6] = -1;
			board [1, 7] = -1;
			board [2, 0] = -1;
			board [2, 7] = -1;
			board [11, 0] = -1;
			board [11, 7] = -1;
			board [12, 0] = -1;
			board [12, 1] = -1;
			board [12, 6] = -1;
			board [12, 7] = -1;
			board [13, 0] = -1;
			board [13, 1] = -1;
			board [13, 2] = -1;
			board [13, 5] = -1;
			board [13, 6] = -1;
			board [13, 7] = -1;
		}

		for (int i = 0; i < 14; i++) {
			for(int j = 0; j < 8; j++){
				//Should debug six 1's, six 2's, eighty eight 0's, twenty four -1's
				Debug.Log (i + "," + j + "=" + board[i,j]);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	GameObject dragObj = null;
	Vector2 startPos;
	Vector2 endPos;

	public BoardState tileState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		mousePos.z = 17;//without this, pieceHit would return null
		if (Input.GetMouseButtonDown (0)) { //when left click mouse is held
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (mousePos);
			Collider2D pieceHit = Physics2D.OverlapPoint(mousePosition);
			if (pieceHit) {
				dragObj = pieceHit.gameObject;
				startPos = new Vector2 (dragObj.transform.position.x, dragObj.transform.position.y);
				Debug.Log ("Start:" + startPos.x + ", " + startPos.y); 
			}
		}
		if (dragObj) {
			dragObj.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
		}
		if (Input.GetMouseButtonUp (0)) { //when left click mouse is released
			//snap into center of tile
			if (dragObj) {
				endPos = new Vector2 (dragObj.transform.position.x, dragObj.transform.position.y);
				float tempX = 0;
				float tempY = 0;

				//snap into center of tile
				if (endPos.x > startPos.x + 0.8f) {
					tempX = startPos.x + 1.6f;

				} else if (endPos.x < startPos.x - 0.8f) {
					tempX = startPos.x - 1.6f;
				} else {
					tempX = startPos.x;
				}

				if (endPos.x > startPos.y + 0.8f) {
					tempY = startPos.y + 1.6f;
				} else if (endPos.y < startPos.y - 0.8f) {
					tempY = startPos.y - 1.6f;
				} else {
					tempY = startPos.y;
				}

				endPos = new Vector2 (tempX, tempY);
				Debug.Log("End:" + tempX + ", " + tempY);

				//check if move valid
				ValidMove ();

				dragObj = null;
			}
		}
	}

	void ValidMove(){ 
		//Check if tile state
		//get tiles position x
		double posX = (double)(endPos.x);
		//get tiles position y
		double posY = (double)(endPos.y);
		//change tiles position to 2d array 
		int arrX = (int)(0.5 * (posX/0.8) + 3.5);
		int arrY = (int)(-0.5 * (posY/0.8) + 6.5);
		//check tile value
		/* Object reference not set to an instance of an object
		int tileStatus = tileState.board[arrY, arrX];
		if (tileStatus == 0) {
			//tile empty
			Debug.Log (0);
		} else if (tileStatus == 1) {
			//computer
			Debug.Log (1);
		} else if (tileStatus == 2) {
			//human
			Debug.Log (2);
		} else {
			//not part of board
			Debug.Log (-1);
		}
		
		*/
		//Pieces are allowed to move one square in all directions on the board as long as the spot is empty
		float diffXSq = Mathf.Pow ((endPos.x - startPos.x), 2);
		float diffYSq = Mathf.Pow ((endPos.y - startPos.y), 2);
		float dist = Mathf.Sqrt (diffXSq + diffYSq);
		Debug.Log ("Distance: " + dist);
		/*
		if(dist >= 1.5 && dist < 3){
			MovePiece();
		}

		//Jump over one enemy to capture
		if(dist >= 3 && dist < 4){
			Capture();
		}
		*/
	}

	void MovePiece(){
		if (dragObj != null) {
			Debug.Log ("Move 1 Square");
		}
	}

	void Capture(){ //Jump Move Obligated whenever possible
		Debug.Log ("Move 2 Squares");
		//find out which specific piece it is that has been captured
		Vector2 midpoint = new Vector2 (((endPos.x + startPos.x)/2), ((endPos.y+startPos.y)/2));
		//if there is an opponent piece there
		//tile at location is empty
		//int arrX = (int)(0.5 * (piece.transform.position.x/0.8) + 3.5);
		//int arrY = (int)(-0.5 * (piece.transform.position.y/0.8) + 6.5);
		//piece.killed();
		//board[arrY, arrX] = 0;


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
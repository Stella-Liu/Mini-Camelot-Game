using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	Piece dragObj;
	Vector2 startPos;
	Vector2 endPos;
	GameManager manager;

	// Use this for initialization
	void Start () {
		manager = (GameManager)FindObjectOfType(typeof(GameManager));
		dragObj = null;
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		mousePos.z = 17;//without this, pieceHit would return null
		if (Input.GetMouseButtonDown (0)) { //when left click mouse is held
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (mousePos);
			//if mouse collides with an object
			Collider2D pieceHit = Physics2D.OverlapPoint(mousePosition); 
			if (pieceHit) {
				if (pieceHit.gameObject == this.gameObject && pieceHit.gameObject.GetComponent<Piece> ()) {
					//if (pieceHit.gameObject.GetComponent<Piece> ().isWhite == true) {
						dragObj = pieceHit.gameObject.GetComponent<Piece> ();
						startPos = new Vector2 (dragObj.transform.position.x, dragObj.transform.position.y);
					//}
				}
			}
		}
		if (dragObj) {
			if (manager.isWhiteTurn) {
				//only move white piece if white turn
				if (dragObj.isWhite) {
					//object is equal to mouse position
					dragObj.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
				}
			} else {
				//only move black piece if black turn
				if (!(dragObj.isWhite)) {
					//object is equal to mouse position
					dragObj.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
				}
			}
		}
		if (Input.GetMouseButtonUp (0)) { //when left click mouse is released
			//snap into center of tile
			if (dragObj) {
				endPos = new Vector2 (dragObj.transform.position.x, dragObj.transform.position.y);
				//check if move valid
				ValidMove ();
				dragObj = null;
			}
		}
	}

	void ValidMove(){		
		//Pieces are allowed to move one square in all directions on the board as long as the spot is empty
		float diffXSq = Mathf.Pow ((endPos.x - startPos.x), 2);
		float diffYSq = Mathf.Pow ((endPos.y - startPos.y), 2);
		float dist = Mathf.Sqrt (diffXSq + diffYSq);
		//Stay in the same box if it has moved off the start square
		if (dist > 0 && dist < 1) {
			dragObj.transform.position = new Vector3 (startPos.x, startPos.y, 0.1f);
		}
		//Move one square
		if(dist >= 1 && dist < 3){
			MovePiece();
		}
		//Jump over one enemy to capture
		if(dist >= 3 && dist < 4.8){
			Capture();
		}
	}

	void MovePiece(){
		if (dragObj != null) {
			float tempX = 0;
			float tempY = 0;
			//snap into center of tile
			if (endPos.x > startPos.x + 0.8f && endPos.x < startPos.x + 2.4f) {
				tempX = Mathf.Round((startPos.x + 1.6f)*10)/10;
			} else if (endPos.x < startPos.x - 0.8f && endPos.x > startPos.x - 2.4f) {
				tempX = Mathf.Round((startPos.x - 1.6f)*10)/10;
			} else {
				tempX = startPos.x;
			}
			if (endPos.y > startPos.y + 0.8f && endPos.y < startPos.y + 2.4f) {
				tempY = Mathf.Round((startPos.y + 1.6f)*10)/10;
			} else if (endPos.y < startPos.y - 0.8f && endPos.y > startPos.y - 2.4f) {
				tempY = Mathf.Round((startPos.y - 1.6f)*10)/10;
			} else {
				tempY = startPos.y;
			}
			endPos = new Vector2 (tempX, tempY);
			//if no piece forced to jump and tile is empty
			if(forcedJump() == false && FindTileState (endPos.x, endPos.y) == 0){
				Debug.Log (forcedJump ());
				//starting position is empty
				manager.state.board [arrayY (startPos.y), arrayX (startPos.x)] = 0;
				//update boardstate of moved piece
				dragObj.transform.position = new Vector3 (endPos.x, endPos.y, 0.1f);				 
				if (manager.isWhiteTurn) {
					manager.state.board [arrayY (endPos.y), arrayX (endPos.x)] = 1;
					manager.isWhiteTurn = false;
				} else {
					manager.state.board [arrayY (endPos.y), arrayX (endPos.x)] = 2;
					manager.isWhiteTurn = true;
				}
				//check for win
				manager.WinByCapture();
				manager.WinByCastle ();
			} else {// if tile not empty
				//go back to starting position
				dragObj.transform.position = new Vector3 (startPos.x, startPos.y, 0.1f);
				//display text "you have a piece that can jump"
				Debug.Log("Have to jump");
			}
		}
	}

	void Capture(){ //Jump Move Obligated whenever possible
		if (dragObj != null) {
			float tempX = 0;
			float tempY = 0;

			//snap into center of tile
			if (endPos.x > startPos.x + 2.4f && endPos.x < startPos.x + 4.0f) {
				tempX = Mathf.Round((startPos.x + 3.2f)*10)/10;
			} else if (endPos.x < startPos.x - 2.4f && endPos.x > startPos.x - 4.0f) {
				tempX = Mathf.Round((startPos.x - 3.2f)*10)/10;
			} else {
				tempX = startPos.x;
			}
			if (endPos.y > startPos.y + 2.4f && endPos.y < startPos.y + 4.0f) {
				tempY = Mathf.Round((startPos.y + 3.2f)*10)/10;
			} else if (endPos.y < startPos.y - 2.4f && endPos.y > startPos.y - 4.0f) {
				tempY = Mathf.Round((startPos.y - 3.2f)*10)/10;
			} else {
				tempY = startPos.y;
			}
			endPos = new Vector2 (tempX, tempY);
			//tile is empty
			if (FindTileState (endPos.x, endPos.y) == 0) {
				//find out midpoint to find tile/piece jumped
				Vector2 midpoint = new Vector2 (((Mathf.Round(((endPos.x + startPos.x)/2)*10))/10), ((Mathf.Round(((endPos.y + startPos.y)/2)*10))/10));

				if (manager.isWhiteTurn) { //if human turn
					if (FindTileState (midpoint.x, midpoint.y) == 2) {//if tile has computer piece
						//find piece at location
						for(int i = 0; i < manager.game.blackPiece.Count; i++){
							if (manager.game.blackPiece [i].transform.position.x == midpoint.x &&
							   	manager.game.blackPiece [i].transform.position.y == midpoint.y) {
								Debug.Log (manager.game.blackPiece [i].transform.position.x + ", " + manager.game.blackPiece [i].transform.position.y);
								//Disable render of piece
								manager.game.blackPiece [i].Killed();
							}
						}
						//tile is empty
						manager.state.board [arrayY (midpoint.y), arrayX (midpoint.x)] = 0;
						//update move
						manager.state.board [arrayY (startPos.y), arrayX (startPos.x)] = 0;
						manager.state.board [arrayY (endPos.y), arrayX (endPos.x)] = 1;
						//move piece
						dragObj.transform.position = new Vector3 (endPos.x, endPos.y, 0.1f);
						manager.isWhiteTurn = false;
					} else {
						dragObj.transform.position = new Vector3 (startPos.x, startPos.y, 0.1f);
					}
				} else{
					if (FindTileState (midpoint.x, midpoint.y) == 1) {//if tile has human piece
						//find piece at location
						for(int i = 0; i < manager.game.whitePiece.Count; i++){
							if (manager.game.whitePiece [i].transform.position.x == midpoint.x &&
								manager.game.whitePiece [i].transform.position.y == midpoint.y) {
								Debug.Log (manager.game.whitePiece [i].transform.position.x + ", " + manager.game.whitePiece [i].transform.position.y);
								//Disable render of piece
								manager.game.whitePiece [i].Killed();
							}
						}
						//tile is empty
						manager.state.board [arrayY (midpoint.y), arrayX (midpoint.x)] = 0;
						//update move
						manager.state.board [arrayY (startPos.y), arrayX (startPos.x)] = 0;
						manager.state.board [arrayY (endPos.y), arrayX (endPos.x)] = 2;
						//move piece
						dragObj.transform.position = new Vector3 (endPos.x, endPos.y, 0.1f);
						manager.isWhiteTurn = true;
					} else {
						dragObj.transform.position = new Vector3 (startPos.x, startPos.y, 0.1f);
					}
				}
				//check for win
				manager.WinByCapture();
				manager.WinByCastle ();
			}
		}
	}
		
	int FindTileState(float x, float y){ //Check if tile state
		//check tile value
		int tileStatus = -1;
		tileStatus = manager.state.board[arrayY(y), arrayX(x)];
		if (tileStatus == 0) {
			//tile empty
			return 0;
		} else if (tileStatus == 1) {
			//computer
			return 1;
		} else if (tileStatus == 2) {
			//human
			return 2;
		} else {
			//not part of board
			return -1;
		}
	}

	int arrayX(float x){
		//change tiles position to 2d array 
		return (int)(Mathf.Round((0.5f * (x/0.8f) + 3.5f)*10.0f)/10.0f);
	}

	int arrayY(float y){
		//change tiles position to 2d array 
		return (int)(Mathf.Round((-0.5f * (y/0.8f) + 6.5f)*10.0f)/10.0f);
	}
	public bool forcedJump(){
		//check all directions one square away if opponent piece nearby and check if able to land if jump
		if (manager.isWhiteTurn) {
			for (int i = 0; i < manager.game.whitePiece.Count; i++) {
				if (manager.game.whitePiece [i].isKilled == false) {
					float x = manager.game.whitePiece [i].transform.position.x;
					float y = manager.game.whitePiece [i].transform.position.y;
					if (FindTileState (x, y + 1) == 2 && FindTileState (x, y + 2) == 0) {
						return true;
					} else if (FindTileState (x, y - 1) == 2 && FindTileState (x, y - 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y) == 2 && FindTileState (x + 2, y) == 0) {
						return true;
					} else if (FindTileState (x - 1, y) == 2 && FindTileState (x - 2, y) == 0) {
						return true;
					} else if (FindTileState (x - 1, y - 1) == 2 && FindTileState (x - 2, y - 2) == 0) {
						return true;
					} else if (FindTileState (x - 1, y + 1) == 2 && FindTileState (x - 2, y + 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y + 1) == 2 && FindTileState (x + 2, y + 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y - 1) == 2 && FindTileState (x + 2, y - 2) == 0) {
						return true;
					}
				}
			}
		} else {
			for (int i = 0; i < manager.game.blackPiece.Count; i++) {
				if (manager.game.blackPiece [i].isKilled == false) {
					float x = manager.game.blackPiece [i].transform.position.x;
					float y = manager.game.blackPiece [i].transform.position.y;
					if (FindTileState (x, y + 1) == 1 && FindTileState (x, y + 2) == 0) {
						return true;
					} else if (FindTileState (x, y - 1) == 1 && FindTileState (x, y - 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y) == 1 && FindTileState (x + 2, y) == 0) {
						return true;
					} else if (FindTileState (x - 1, y) == 1 && FindTileState (x - 2, y) == 0) {
						return true;
					} else if (FindTileState (x - 1, y - 1) == 1 && FindTileState (x - 2, y - 2) == 0) {
						return true;
					} else if (FindTileState (x - 1, y + 1) == 1 && FindTileState (x - 2, y + 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y + 1) == 1 && FindTileState (x + 2, y + 2) == 0) {
						return true;
					} else if (FindTileState (x + 1, y - 1) == 1 && FindTileState (x + 2, y - 2) == 0) {
						return true;
					}
				}
			}
		}
		return false;
	}
}
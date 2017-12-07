using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	GameObject dragObj = null;
	Vector2 startPos;
	Vector2 endPos;

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
			}
		}
		if (dragObj) {
			dragObj.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
		}
		if (Input.GetMouseButtonUp (0)) { //when left click mouse is released
			endPos = new Vector2 (dragObj.transform.position.x, dragObj.transform.position.y);
			dragObj = null;
			//check if move valid
			ValidMove ();
		}
	}

	void ValidMove(){ 
		//Pieces are allowed to move one square in all directions on the board as long as the spot is empty
		//if(distance is one){
			//MovePiece();
		//}

		//Jump over one enemy to capture
		//if(distance is two or more){
			//Capture();
		//}

	}

	void MovePiece(){
		if (dragObj != null) {

		}
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
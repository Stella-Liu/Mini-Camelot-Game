using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour {

	bool isWhiteTurn;
	public Board b; 
	public int[,] board;
	float valueNode;
	int depth;
	BoardState parent;
	public BoardState[] children;

	void Start(){
		board = new int[14,8];
		board = b.board;
	}
}

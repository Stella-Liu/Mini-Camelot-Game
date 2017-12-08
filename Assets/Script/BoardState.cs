using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour {

	bool isWhiteTurn;
	int[,] board;
	float valueNode;
	int depth;
	public BoardState parent;
	public BoardState[] children;

	void Start(){
		board = GetComponent<Board> ().board;
	}
}

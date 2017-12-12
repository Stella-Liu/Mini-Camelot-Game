using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour {

	GameManager manager;
	bool isWhiteTurn;
	public Board b; 
	public int[,] board;
	float valueNode;
	public int depth;
	BoardState parent;
	List<BoardState> children;

	private int maxDepth;
	private int nodeGen;
	private int numPruningMax;
	private int numPruningMin;
	public int depthLimit;
	//max = computer - black
	//min = human - white

	void Start(){
		manager = (GameManager)FindObjectOfType(typeof(GameManager));
		depth = 0;
		nodeGen = 1;
		depthLimit = 1;
	}

	void Update(){
		this.board = manager.game.board;
	}

	/*
	public void AlphaBeta(BoardState node){
		createTree ();

		if (node.children.Count == 0) {
			Eval (node);
		}

		float bestValue = MaxValue (node, -1000, 1000);
		//return actions
	}

	public float MaxValue(BoardState node, float alpha, float beta){
		if (node.children.Count == 0) {
			Eval (node);
		}
		if (CutOff(node)) return Eval (node);
		float bestValue = Mathf.NegativeInfinity;
		for (int i = 0; i < node.children.Count; i++) {
			bestValue = Mathf.Max(bestValue, MinValue(node.children[i], alpha, beta));				
			alpha = Mathf.Max(alpha, bestValue);
			if (beta <= alpha) {
				break;
			}
		}
		return bestValue;
	}

	public float MinValue(BoardState node, float alpha, float beta){
		if (node.children.Count == 0) {
			Eval (node);
		}
		if (CutOff(node)) return Eval (node);
		float bestValue = Mathf.Infinity;
		for(int i = 0; i < node.children.Count; i++){
			bestValue = Mathf.Min(bestValue, MaxValue(node.children[i], alpha, beta));
			beta = Mathf.Min(beta, bestValue);
			if(beta <= alpha){
				break;
			}
		}
		return bestValue;
	}

	public bool CutOff(BoardState state){
		if (state.depth == depthLimit) {
			return true;
		} else {
			return false;
		}
	}

	//evaluation function return value range [-1000,+1000] depending on how 
	//favorable the board position is to the Max Player or Min player
	public float Eval(BoardState node){
		int blackCount = 0;
		int whiteCount = 0;
		//plus value to computer when has more pieces than human and closer to the castle vise versa except value is negative
		for (int i = 0; i < manager.game.blackPiece.Count; i++) {
			if (manager.game.blackPiece [i].isKilled == false) {
				blackCount ++;
			}
		}
		for (int i = 0; i < manager.game.whitePiece.Count; i++) {
			if (manager.game.whitePiece [i].isKilled == false) {
				whiteCount ++;
			}
		}
		int value = (blackCount - whiteCount) * 166; //positive if favorable to black; negative if favorable to white

		for (int i = 0; i < 14; i++) {
			for (int j = 0; j < 8; j++) {
				if (i == 0 && node.board [i, j] == 1) {
					value = value - 175;
				} else if ((i <= 6) && node.board [i, j] == 1) {
					value = value - 165;
				}
				if (i == 13 && node.board [i, j] == 2) {
					value = value + 175;
				} else if (i >= 6 && node.board [i, j] == 2) {
					value = value + 165;
				}
			}
		}
		return value;
	}

	void addChildren(int depth){
		BoardState temp = new BoardState();
		temp.board = board;
		for (int i = 0; i < 14; i++) {
			for (int j = 0; j < 8; j++) {
				if (board [i, j] == 2) {
					if (board [i + 1, j] == 0 && board [i + 2, j] == 0) {
						temp.board [i, j] = 0;
						temp.board [i + 1, j] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i - 1, j] == 0 && board [i - 2, j] == 0){
						temp.board [i, j] = 0;
						temp.board [i - 1, j] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i, j + 1] == 0 && board [i, j + 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i, j + 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i, j - 1] == 0 && board [i, j - 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i, j - 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i + 1, j + 1] == 0 && board [i + 2, j + 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i + 1, j + 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i + 1, j - 1] == 0 && board [i + 2, j - 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i + 1, j - 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i - 1, j + 1] == 0 && board [i - 2, j + 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i - 1, j + 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
					if (board [i - 1, j - 1] == 0 && board [i - 2, j - 2] == 0) {
						temp.board [i, j] = 0;
						temp.board [i - 1, j - 1] = 2;
						temp.depth = depth;
						parent = this.gameObject.GetComponent<BoardState>();
						children.Add (temp);
						nodeGen++;
					}
				}
			}
		}
	}

	void createTree(){
		for (int i = 0; i < depthLimit; i++) {
			addChildren (i+1);
		}
	}*/
}

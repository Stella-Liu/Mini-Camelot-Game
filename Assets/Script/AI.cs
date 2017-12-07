using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	//public DateTime algStartTime;
	private int maxDepth;
	private int nodeGen;
	private int numPruningMax;
	private int numPruningMin;

	public int depth;
	public float alpha;//if (comp) max player win
	public float beta;//if (human) min player win
	public bool isWhiteTurn;
	public int drawValue; //if draw
	//max = computer - black
	//min = human - white

	//AI should check in the order of Capture then Plain move.

	public float AlphaBeta(BoardState node, int depth, float alpha, float beta, bool isWhiteTurn){
		if(depth == 0){ //or node terminal node
			//return heuristic value of node;
		}

		if (!isWhiteTurn) {
			float bestValue = Mathf.NegativeInfinity;
			for(int i = 0; i < node.children.Length; i++){
				//bestValue = Mathf.Max(bestValue, AlphaBeta(node.children[i], depth - 1, alpha, beta, FALSE));
				alpha = Mathf.Max(alpha, bestValue);
				if(beta <= alpha){
					break;
				}
			}
			return bestValue;
		}else{
			float bestValue = Mathf.Infinity;
			for(int i = 0; i < node.children.Length; i++){
				//bestValue = Mathf.Min(bestValue, AlphaBeta(node.children[i], depth - 1, alpha, beta, TRUE));
				beta = Mathf.Min(beta, bestValue);
				if(beta <= alpha){
					break;
				}
			}
			return bestValue;
		}
	}

	//evaluation function return value range [-1000,+1000] depending on how 
	//favorable the board position is to the Max Player or Min player
	public void Eval(){
		//plus value to computer when has more pieces than human and closer to the castle vise versa except value is negative
	}

}

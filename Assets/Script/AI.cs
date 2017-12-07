using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	//public DateTime algStartTime;
	private int maxDepth;
	private int nodeGen;
	private int numPruningMax;
	private int numPruningMin;

	public int depthLimit;
	public float alpha;//if (comp) max player win
	public float beta;//if (human) min player win
	public bool isWhiteTurn;
	public int drawValue; //if draw
	//max = computer - black
	//min = human - white

	//AI should check in the order of Capture then Plain move.

	public void AlphaBeta(BoardState node){
		if (node.children.Length == 0) {
			//return heuristic value of node;
		}
		float bestValue = MaxValue (node, -1000, 1000);
		//return actions
	}

	public float MaxValue(BoardState node, float alpha, float beta){
		if (node.children.Length == 0) {
			//return heuristic value of node;
		}
		if (CutOff(node)) return Eval (node);
		float bestValue = Mathf.NegativeInfinity;
		for (int i = 0; i < node.children.Length; i++) {
			bestValue = Mathf.Max(bestValue, MinValue(Result(node.children[i], alpha), alpha, beta));				
			alpha = Mathf.Max(alpha, bestValue);
			if (beta <= alpha) {
				break;
			}
		}
		return bestValue;
	}

	public float MinValue(BoardState node, float alpha, float beta){
		if (node.children.Length == 0) {
			//return heuristic value of node;
		}
		if (CutOff(node)) return Eval (node);
		float bestValue = Mathf.Infinity;
		for(int i = 0; i < node.children.Length; i++){
			bestValue = Mathf.Min(bestValue, MinValue(Result(node.children[i], alpha), alpha, beta));
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
	public void Eval(BoardState state){
		//plus value to computer when has more pieces than human and closer to the castle vise versa except value is negative
	}

	public float Result(BoardState state, float alpha){

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool isWhiteTurn;
	BoardState state;
	AI comp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWhiteTurn) {
			comp.AlphaBeta (state);
		}
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
	public bool isWhite;
	public bool hasKilled;

	void Killed(){
		hasKilled = true;
		gameObject.GetComponent<Renderer>().enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
	public bool isWhite;
	public bool isKilled = false;

	public void Killed(){
		isKilled = true;
		this.gameObject.GetComponent<Renderer>().enabled = false;
	}
}
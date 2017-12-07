using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	GameObject dragObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		mousePos.z = 17;//without this, i pieceHit would return null
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (mousePos);
			Collider2D pieceHit = Physics2D.OverlapPoint(mousePosition);
			Debug.Log (mousePosition.x + ", " + mousePosition.y);
			if (pieceHit) {
				dragObj = pieceHit.gameObject;
			} else{
				Debug.Log ("pieceHit null");
			}
		}
		if (dragObj) {
			//how to change transform.position.z for dragObj to a higher z because it is disappearing
			dragObj.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
		}
		if (Input.GetMouseButtonUp (0)) {
			dragObj = null;
		}
	}
}
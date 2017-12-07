using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameManager manager;

	public Button button1;
	public Button button2;

	void Start(){
		manager.isWhiteTurn = false;
		button1.onClick.AddListener (FirstTurn);
		button2.onClick.AddListener (LoadScene);
	}

	void FirstTurn (){
		manager.isWhiteTurn = true;
		LoadScene ();
	}

	void LoadScene(){
		SceneManager.LoadScene ("Game");
	}
}
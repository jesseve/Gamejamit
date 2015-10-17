using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<King> gameOverKings;

	void Start() {
		DontDestroyOnLoad(gameObject);
	}

	public void StartGame() {
		Application.LoadLevel("_Main 1");
	}
	public void GameOver(List<King> kings) {
		gameOverKings = kings;

		Application.LoadLevel("GameOver");
	}
}

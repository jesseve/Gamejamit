using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Button restartButton;
	public Text firstKing;
	public Text secondKing;
	public Text thirdKing;
	private List<King> kings;
	private GameManager manager;

	void Start() {
		manager = GameObject.FindObjectOfType<GameManager>();
		kings = manager.gameOverKings;
		restartButton.onClick.AddListener(() => manager.StartGame());
		UpdateValues();
	}

	public void UpdateValues() {
		if(kings[0] > kings[1] && kings[0] > kings[2])
		{	
			firstKing.text = kings[0].name;
			if(kings[1] > kings[2]) {
				secondKing.text = kings[1].name;
				thirdKing.text = kings[2].name;
			}else {
				secondKing.text = kings[2].name;
				thirdKing.text = kings[1].name;
			}
		} else if(kings[1] > kings[0] && kings[1] > kings[2])
		{	
			firstKing.text = kings[1].name;
			if(kings[0] > kings[2]) {
				secondKing.text = kings[0].name;
				thirdKing.text = kings[2].name;
			}else {
				secondKing.text = kings[2].name;
				thirdKing.text = kings[0].name;
			}
		}
		else {
			firstKing.text = kings[2].name;
			if(kings[0] > kings[1]) {
				secondKing.text = kings[0].name;
				thirdKing.text = kings[1].name;
			}else {
				secondKing.text = kings[1].name;
				thirdKing.text = kings[0].name;
			}
		}
	}
}

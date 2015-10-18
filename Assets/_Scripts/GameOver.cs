using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Sprite defeat;
	public Sprite victory;

	public Image background;
	public Image winning;
	public Button restartButton;
	public Text winner;
	private List<King> kings;
	private GameManager manager;

	void Start() {
		manager = GameObject.FindObjectOfType<GameManager>();
		restartButton.onClick.AddListener(() => manager.StartGame());
		for(int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	public void UpdateValues() {
		StartCoroutine(ShowGameOver());
		kings = manager.gameOverKings;
		if(kings[0] > kings[1] && kings[0] > kings[2])
		{	
			winner.text = kings[0].name;
			winning.sprite = victory;
		}
		else if(kings[1] > kings[0] && kings[1] > kings[2]) {
			winner.text = kings[1].name;
			winning.sprite = defeat;
		}
		else if(kings[2] > kings[0] && kings[2] > kings[1]) {
			winner.text = kings[2].name;
			winning.sprite = defeat;
		}
	}
	private IEnumerator ShowGameOver() {
		for(int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(true);
		}
		restartButton.interactable = true;
		Color c = background.color;
		c.a = 0;
		background.color = c;
		float f = 220.0f/255;
		while(c.a < f) {
			c.a += 0.02f;
			background.color = c;
			yield return new WaitForSeconds(0.02f);
		}


	}
}

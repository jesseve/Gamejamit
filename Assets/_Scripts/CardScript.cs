using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardScript : MonoBehaviour {

	public Image cardImage;
	public Image stat1, stat2, stat3;

	public Card card;
	// Use this for initialization
	void Start () {
		stat1.fillAmount = card.raha;
		stat2.fillAmount = card.suosio;
		stat3.fillAmount = card.rauha;
	}

	public void ChangeCard(Card card) {
		this.card = card;

		cardImage.sprite = card.sprite;
		stat1.fillAmount = card.raha;
		stat2.fillAmount = card.suosio;
		stat3.fillAmount = card.rauha;
	}
}

[System.Serializable]
public class Card {
	public Sprite sprite;

	[Range(-1,1)] public float raha;
	[Range(-1,1)] public float rauha;
	[Range(-1,1)] public float suosio;

}

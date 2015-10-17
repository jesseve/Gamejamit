using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardScript : MonoBehaviour {

	//public Text nameText;
	public Image cardImage;
	public Text stat1, stat2, stat3;

	public Card card;

	public void ChangeCard(Card card) {
		this.card = card;

		//nameText.text = card.name;
		cardImage.sprite = card.sprite;
		stat1.text = card.raha.ToString();
		stat2.text = card.suosio.ToString();
		stat3.text = card.rauha.ToString();

		if(card.raha > 0) 
			stat1.color = Color.green;		
		else if(card.raha < 0) 
			stat1.color = Color.red;
		else
			stat1.color = Color.black;

		if(card.suosio > 0) 
			stat2.color = Color.green;		
		else if(card.suosio < 0) 
			stat2.color = Color.red;
		else
			stat2.color = Color.black;

		if(card.rauha > 0) 
			stat3.color = Color.green;		
		else if(card.rauha < 0) 
			stat3.color = Color.red;
		else
			stat3.color = Color.black;
	}
}

[System.Serializable]
public class Card {
	public string name = "Not Set";
	public Sprite sprite;

	[Range(-10,10)] public int raha;
	[Range(-10,10)] public int rauha;
	[Range(-10,10)] public int suosio;

}

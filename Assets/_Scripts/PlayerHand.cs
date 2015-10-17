using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHand : MonoBehaviour {

	public GameObject cardPrefab;
	public Transform cardHolder; 
	private GridLayoutGroup grid;
	private List<CardScript> cards;


	void Start() {
		cards = new List<CardScript>();
	}

	public void AddCard(Card card) {
		GameObject go = Instantiate(cardPrefab) as GameObject;
		go.transform.SetParent(cardHolder);
		go.transform.localScale = Vector3.one;
		CardScript cs = go.GetComponent<CardScript>();
		Button b = go.GetComponent<Button>();
		b.interactable = false;
		b.onClick.AddListener(() => Eliminate (cs));
		cards.Add(cs);
		cs.ChangeCard(card);
	}
	public void Eliminate(CardScript cs) {

	}
}

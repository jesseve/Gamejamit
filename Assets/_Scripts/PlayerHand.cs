using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHand : MonoBehaviour {

	public GameObject cardPrefab;
	public Transform cardHolder; 
	private GridLayoutGroup grid;
	private List<CardScript> cards;
	private List<Button> buttons;
	private TurnController tc;

	void Start() {
		cards = new List<CardScript>();
		buttons = new List<Button>();
		tc = GameObject.FindObjectOfType<TurnController>();
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
		buttons.Add(b);
		cs.ChangeCard(card);
	}
	public void Eliminate(CardScript cs) {
		tc.kings[0].Eliminate(cs.card);
		cards.Remove(cs);
		buttons.Remove(cs.GetComponent<Button>());
		foreach(Button b in buttons) {
			b.interactable = false;
		}
		Destroy(cs.gameObject);
		GameManager.PlayScream();
		tc.EndTurn();
	}
	public void EliminationRound() {
		foreach(Button b in buttons) {
			if(b == null)
				buttons.Remove(b);
			else
				b.interactable = true;
		}
	}
}

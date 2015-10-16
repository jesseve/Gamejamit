using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {

	public List<Card> possibleCards;

	public int playerCount = 3;

	public List<King> kings;

	public RectTransform[] cardPositions;

	private List<CardScript> cardsOnTable;

	void Start() {
		kings = new List<King>();
		for(int i = 0; i < playerCount; i++) {
			kings.Add(new King());
		}

		cardsOnTable = new List<CardScript>();
		cardsOnTable.Add(new CardScript());
		cardsOnTable.Add(new CardScript());
		cardsOnTable.Add(new CardScript());

		cardsOnTable[0].transform.SetParent(cardPositions[0]);
		cardsOnTable[1].transform.SetParent(cardPositions[1]);
		cardsOnTable[2].transform.SetParent(cardPositions[2]);

		StartTurn();
	}

	public void StartTurn() {
		NewCards ();
		foreach(King k in kings){
			k.Upkeep();
		}
	}

	public void EndTurn() {
		StartTurn();
	}
	public void ClickCard(CardScript card) {
		kings[0].DrawCard(card.card);
		int id = cardsOnTable.IndexOf(card);
		switch(id)
		{
		case 0:
			kings[1].DrawCard(cardsOnTable[1].card);
			kings[2].DrawCard(cardsOnTable[2].card);
			break;
		case 1:
			kings[0].DrawCard(cardsOnTable[0].card);
			kings[2].DrawCard(cardsOnTable[2].card);
			break;
		case 2:
			kings[0].DrawCard(cardsOnTable[0].card);
			kings[1].DrawCard(cardsOnTable[1].card);
			break;
		}
		EndTurn ();
	}

	private void NewCards() {
		for(int i = 0; i < 3; i++) {
			Card c = possibleCards[Random.Range (0, possibleCards.Count)];
			cardsOnTable[i].card = c;
		}
	}
}

[System.Serializable]
public class King {
	public float raha;
	public float suosio;
	public float rauha;
	public List<Card> cards;

	public King() {
		cards = new List<Card>();
	}

	public void Upkeep(){
		foreach(Card cs in cards) {
			raha += cs.raha;
			rauha += cs.rauha;
			suosio += cs.suosio;
		}
	}
	public void DrawCard(Card card) {
		cards.Add(card);
	}
}
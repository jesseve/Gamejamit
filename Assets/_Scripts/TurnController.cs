using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {

	public List<Card> possibleCards;

	public int playerCount = 3;

	public List<King> kings;
	
	public List<CardScript> cardsOnTable;

	void Start() {
		kings = new List<King>();
		for(int i = 0; i < playerCount; i++) {
			kings.Add(new King());
		}

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
		int id = cardsOnTable.IndexOf(card);
		Debug.Log ("ID: " + id);
		switch(id)
		{
		case 0:
			kings[0].DrawCard(cardsOnTable[0].card);
			kings[1].DrawCard(cardsOnTable[1].card);
			kings[2].DrawCard(cardsOnTable[2].card);
			break;
		case 1:
			kings[0].DrawCard(cardsOnTable[1].card);
			kings[1].DrawCard(cardsOnTable[0].card);
			kings[2].DrawCard(cardsOnTable[2].card);
			break;
		case 2:
			kings[0].DrawCard(cardsOnTable[2].card);
			kings[1].DrawCard(cardsOnTable[0].card);
			kings[2].DrawCard(cardsOnTable[1].card);
			break;
		}
		EndTurn ();
	}

	private void NewCards() {
		for(int i = 0; i < 3; i++) {
			Card c = possibleCards[Random.Range (0, possibleCards.Count)];
			cardsOnTable[i].ChangeCard(c);
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
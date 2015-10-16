using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {

	public List<CardScript> possibleCards;

	public int playerCount = 3;

	public List<King> kings;

	private List<CardScript> cardsOnTable;

	void Start() {
		kings = new List<King>();
		for(int i = 0; i < playerCount; i++) {
			kings.Add(new King());
		}

		cardsOnTable = new List<CardScript>();
		cardsOnTable.Add(possibleCards[0]);
		cardsOnTable.Add(possibleCards[0]);
		cardsOnTable.Add(possibleCards[0]);
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
		kings[0].DrawCard(card);
		int id = cardsOnTable.IndexOf(card);
		switch(id)
		{
		case 0:
			kings[1].DrawCard(cardsOnTable[1]);
			kings[2].DrawCard(cardsOnTable[2]);
			break;
		case 1:
			kings[0].DrawCard(cardsOnTable[0]);
			kings[2].DrawCard(cardsOnTable[2]);
			break;
		case 2:
			kings[0].DrawCard(cardsOnTable[0]);
			kings[1].DrawCard(cardsOnTable[1]);
			break;
		}
		EndTurn ();
	}

	private void NewCards() {
		for(int i = 0; i < 3; i++) {
			CardScript c = possibleCards[Random.Range (0, possibleCards.Count)];
			cardsOnTable[i] = c;
		}
	}
}

[System.Serializable]
public class King {
	public float raha;
	public float suosio;
	public float rauha;
	public List<CardScript> cards;

	public King() {
		cards = new List<CardScript>();
	}

	public void Upkeep(){
		foreach(CardScript cs in cards) {
			raha += cs.raha;
			rauha += cs.rauha;
			suosio += cs.suosio;
		}
	}
	public void DrawCard(CardScript card) {
		cards.Add(card);
	}
}
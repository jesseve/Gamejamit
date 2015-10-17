using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {


	public int turnTime = 10;
	public int maxTurns = 99;
	public UnityEngine.UI.Image timerImage;
	public List<Card> possibleCards;

	public int playerCount = 3;

	public List<King> kings;
	
	public List<CardScript> cardsOnTable;

	private int turn;
	private PlayerHand playerHand;
	private PlayerStatus playerStatus;
	private UpdateStatus updateStatus;
	private bool gameOver;

	void Awake() {
		kings = new List<King>();
		for(int i = 0; i < playerCount; i++) {
			kings.Add(new King("Player" + i.ToString()));
		}
		playerStatus = GameObject.FindObjectOfType<PlayerStatus>();
		playerHand = GameObject.FindObjectOfType<PlayerHand>();
		updateStatus = GameObject.FindObjectOfType<UpdateStatus>();

		StartTurn();
	}

	public void StartTurn() {
		turn++;
		NewCards ();
		foreach(King k in kings){
			if(k.lostGame == false)
				k.Upkeep();
		}
		updateStatus.UpdateValues(kings);
		StartCoroutine(TurnTimer());
	}

	public void EndTurn() {
		playerStatus.EndOfTurn();
		if(turn >= maxTurns) {
			EndGame();
		}
		else {
			foreach(King k in kings) {
				if(k.raha <= 0 || k.rauha <= 0 || k.suosio <= 0)
					k.LoseGame();
			}
			if(kings[0].lostGame == true || (kings[1].lostGame && kings[2].lostGame))
				EndGame();
			else
				StartTurn();
		}
	}

	public void ClickCard(CardScript card) {
		int id = cardsOnTable.IndexOf(card);
		playerHand.AddCard(card.card);
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

	private void EndGame() {
		gameOver = true;
	}
	private void NewCards() {
		for(int i = 0; i < 3; i++) {
			Card c = possibleCards[Random.Range (0, possibleCards.Count)];
			cardsOnTable[i].ChangeCard(c);
		}
	}

	private IEnumerator TurnTimer() {
		int t = turn;
		float f = turnTime;

		while(f > 0 && turn == t && gameOver == false) {
			f -= 0.1f;
			timerImage.fillAmount = (1 - (f/turnTime));
			yield return new WaitForSeconds(0.1f);
		}

		if(turn == t) {
			//Player did not act in time
			ClickCard(cardsOnTable[Random.Range(0,3)]);
		}
	}
}

[System.Serializable]
public class King {
	public string name;
	public float raha = 20;
	public float suosio = 20;
	public float rauha = 20;
	public List<Card> cards;
	public bool lostGame = false;
	public float Values {
		get { return (raha + suosio + rauha); }
	}

	public King(string name) {
		cards = new List<Card>();
		this.name = name;
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
	public void LoseGame() {
		lostGame = true;
	}
}
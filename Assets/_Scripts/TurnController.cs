using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {

	public Text hintText;

	public int turnTime = 10;
	public int maxTurns = 99;
	public UnityEngine.UI.Image timerImage;
	public List<Card> possibleCards;

	public int playerCount = 3;

	public List<King> kings;
	
	public List<CardScript> cardsOnTable;

	private GameManager gameManger;
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
		gameManger = GameObject.FindObjectOfType<GameManager>();

		NewCards();
		foreach(CardScript cs in cardsOnTable) {
			cs.GetComponent<Button>().interactable = false;
			cs.gameObject.SetActive(false);
		}
		updateStatus.UpdateValues(kings);
		playerStatus.EndOfTurn();
		Invoke ("StartGame", 2);
	}

	private void StartGame() {
		foreach(CardScript cs in cardsOnTable) {
			cs.GetComponent<Button>().interactable = true;
			cs.gameObject.SetActive(true);
		}
		StartTurn();
	}

	public void StartTurn() 
	{
		if(gameOver == true) return;
		turn++;
		NewCards ();
		hintText.text = "Choose a card";

		if(turn % 5 == 0) {
			EliminationRound();
		}
		else 
			StartCoroutine(TurnTimer());
	}

	public void EndTurn() {
		if(turn >= maxTurns) {
			StartCoroutine(EndGame());
		}
		cardsOnTable[0].transform.parent.gameObject.SetActive(true);
		if(gameOver == true) return;
		else {

			foreach(King k in kings){
				if(k.lostGame == false)
					k.Upkeep();

				if(k.raha <= 0 || k.rauha <= 0 || k.suosio <= 0) {
					k.LoseGame();
					playerCount --;
				}
				if(playerCount <= 1)
					StartCoroutine(EndGame());
			}

			foreach(CardScript cs in cardsOnTable) {
				cs.GetComponent<Button>().interactable = true;
			}

			if(kings[0].lostGame == true || (kings[1].lostGame && kings[2].lostGame))
				StartCoroutine(EndGame());
			else
				StartTurn();
		}
		updateStatus.UpdateValues(kings);
		playerStatus.EndOfTurn();
	}

	public void ClickCard(CardScript card) {
		if(gameOver == true) return;
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

	private IEnumerator EndGame() {
		if(gameOver == false) {
			gameOver = true;
			foreach(CardScript cs in cardsOnTable) {
				cs.GetComponent<Button>().interactable = false;
			}
			updateStatus.UpdateValues(kings);
			yield return new WaitForSeconds(2f);
			gameManger.GameOver(kings);
		}
	}

	private void EliminationRound() {
		if(gameOver == true) return;
		cardsOnTable[0].transform.parent.gameObject.SetActive(false);
		StartCoroutine(TurnTimer(true));
		hintText.text = "Behead a citizen!";
		foreach(CardScript cs in cardsOnTable) {
			cs.GetComponent<Button>().interactable = false;
		}
		playerHand.EliminationRound();
	}

	private void NewCards() {
		if(gameOver == true) return;
		for(int i = 0; i < 3; i++) {
			Card c = possibleCards[Random.Range (0, possibleCards.Count)];
			cardsOnTable[i].ChangeCard(c);
		}
	}

	private IEnumerator TurnTimer(bool elimination = false) {
		int t = turn;
		float f = turnTime;

		while(f > 0 && turn == t && gameOver == false) {
			f -= 0.1f;
			timerImage.fillAmount = (1 - (f/turnTime));
			yield return new WaitForSeconds(0.1f);
		}

		if(turn == t && gameOver == false) {
			//Player did not act in time
			if(elimination == false)
				ClickCard(cardsOnTable[Random.Range(0,3)]);
			else
				playerHand.EliminateRandom();
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

	public float ukRaha;
	public float ukSuosio;
	public float ukRauha;

	public float Values {
		get { return (raha + suosio + rauha); }
	}

	public King(string name) {
		cards = new List<Card>();
		this.name = name;

		ukRaha = ukRauha = ukSuosio = 0;
	}
	public void Eliminate(Card card) {
		cards.Remove (card);
		ukRaha -= card.raha;
		ukRauha -= card.rauha;
		ukSuosio -= card.suosio;
	}

	public void Upkeep(){
		foreach(Card cs in cards) {
			raha += cs.raha;
			rauha += cs.rauha;
			suosio += cs.suosio;
		}
	}
	public void DrawCard(Card card) {
		if(lostGame == true) return;
		cards.Add(card);
		ukRaha += card.raha;
		ukRauha += card.rauha;
		ukSuosio += card.suosio;
	}
	public void LoseGame() {
		lostGame = true;
	}

	public static bool operator < (King k1, King k2) {
		if(k1.raha > 0 && k1.suosio > 0 && k1.rauha > 0){
			if(k2.raha <= 0 || k2.rauha <= 0 || k2.suosio <= 0)
				return false;
			else
			{
				float f1 = k1.raha + k1.rauha + k1.suosio;
				float f2 = k2.raha + k2.rauha + k2.suosio;
				if(f1 < f2)
					return true;
				else 
					return false;
			}
		}
		else {
			if(k2.raha > 0 || k2.rauha > 0 || k2.suosio > 0) {
				return true;
			}
			else
			{
				float f1 = k1.raha + k1.rauha + k1.suosio;
				float f2 = k2.raha + k2.rauha + k2.suosio;
				if(f1 < f2)
					return true;
				else 
					return false;
			}
		}
	}
	public static bool operator > (King k1, King k2) {
		if(k1.raha > 0 && k1.suosio > 0 && k1.rauha > 0){
			if(k2.raha <= 0 || k2.rauha <= 0 || k2.suosio <= 0)
				return true;
			else
			{
				float f1 = k1.raha + k1.rauha + k1.suosio;
				float f2 = k2.raha + k2.rauha + k2.suosio;
				if(f1 < f2)
					return false;
				else 
					return true;
			}
		}
		else {
			if(k2.raha > 0 || k2.rauha > 0 || k2.suosio > 0) {
				return false;
			}
			else
			{
				float f1 = k1.raha + k1.rauha + k1.suosio;
				float f2 = k2.raha + k2.rauha + k2.suosio;
				if(f1 < f2)
					return false;
				else 
					return true;
			}
		}
	}
}
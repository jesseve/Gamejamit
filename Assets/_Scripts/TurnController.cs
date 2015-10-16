using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnController : MonoBehaviour {

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
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpdateStatus : MonoBehaviour {

	public Text[] firstStats;
	public Text[] secondStats;
	public Text[] thirdStats;
	public Text firstKing;
	public Text secondKing;
	public Text thirdKing;

	public void UpdateValues(List<King> kings) {
		float k1total = kings[0].Values;
		float k2total = kings[1].Values;
		float k3total = kings[2].Values;
		if(k1total >= k2total && k1total >= k3total){
			SetStatus(kings[0], 1);
			if(k2total > k3total) {
				SetStatus(kings[1], 2);
				SetStatus(kings[2], 3);
			}
			else {
				SetStatus(kings[2], 2);
				SetStatus(kings[1], 3);
			}
		} else if(k2total >= k3total && k2total >= k1total) {
			SetStatus(kings[1], 1);
			if(k1total > k3total) {
				SetStatus(kings[0], 2);
				SetStatus(kings[2], 3);
			}
			else{
				SetStatus(kings[2], 2);
				SetStatus(kings[0], 3);
			}
		} else if(k3total >= k1total && k3total >= k2total) {
			SetStatus(kings[2], 1);
			if(k1total > k2total) {
				SetStatus(kings[0], 2);
				SetStatus(kings[1], 3);
			}
			else{
				SetStatus(kings[1], 2);
				SetStatus(kings[0], 3);
			}
		}
	}
	public void SetStatus(King k, int place) {
		switch(place)
		{
		case 1:
			firstKing.text = k.name;
			firstStats[0].text = k.raha.ToString();
			firstStats[1].text = k.suosio.ToString();
			firstStats[2].text = k.rauha.ToString();
			break;
		case 2:
			secondKing.text = k.name;
			secondStats[0].text = k.raha.ToString();
			secondStats[1].text = k.suosio.ToString();
			secondStats[2].text = k.rauha.ToString();
			break;
		case 3:
			thirdKing.text = k.name;
			thirdStats[0].text = k.raha.ToString();
			thirdStats[1].text = k.suosio.ToString();
			thirdStats[2].text = k.rauha.ToString();
			break;
		}
	}
}

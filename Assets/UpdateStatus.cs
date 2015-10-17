using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpdateStatus : MonoBehaviour {

	public Text firstKing;
	public Text secondKing;
	public Text thirdKing;

	public void UpdateValues(List<King> kings) {
		float k1total = kings[0].Values;
		float k2total = kings[1].Values;
		float k3total = kings[2].Values;
		if(k1total >= k2total && k1total >= k3total){
			firstKing.text = kings[0].name;
			if(k2total > k3total) {
				secondKing.text = kings[1].name;
				thirdKing.text = kings[2].name;
			}
			else {
				secondKing.text = kings[2].name;
				thirdKing.text = kings[1].name;
			}
		} else if(k2total >= k3total && k2total >= k1total) {
			firstKing.text = kings[1].name;
			if(k1total > k3total) {
				secondKing.text = kings[0].name;
				thirdKing.text = kings[2].name;
			}
			else{
				secondKing.text = kings[2].name;
				thirdKing.text = kings[0].name;
			}
		} else if(k3total >= k1total && k3total >= k2total) {
			firstKing.text = kings[2].name;
			if(k1total > k2total) {
				secondKing.text = kings[0].name;
				thirdKing.text = kings[1].name;
			}
			else{
				secondKing.text = kings[1].name;
				thirdKing.text = kings[0].name;
			}
		}
	}
}

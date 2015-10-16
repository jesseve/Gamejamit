using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardScript : MonoBehaviour {

	public Image stat1, stat2, stat3;

	[Range(-1,1)] public float raha;
	[Range(-1,1)] public float rauha;
	[Range(-1,1)] public float suosio;

	// Use this for initialization
	void Start () {
		stat1.fillAmount = raha;
		stat2.fillAmount = suosio;
		stat3.fillAmount = rauha;
	}
}

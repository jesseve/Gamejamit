using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public TurnController turnCtrl;
    //public GameObject wealthText;
    //public GameObject kingText;
    //public GameObject peopleText;
    //public GameObject peaceText;
    public int wealth;
    //public int favorKing;
    public int favorPeople;
    public int peace;
    public Text wealthNumber;
    //Text kingNumber;
    public Text peopleNumber;
    public Text peaceNumber;
    
	public Text upkeep1, upkeep2, upkeep3;

    //int military;

    void Start()
    {
		EndOfTurn();
    }


    public void EndOfTurn()
    {
		King k = turnCtrl.kings[0];

        wealth = (int)k.raha;
		favorPeople = (int)k.suosio;
		peace = (int)k.rauha;

		wealthNumber.text = wealth.ToString();
        peopleNumber.text = favorPeople.ToString();
        peaceNumber.text = peace.ToString();
        
		upkeep1.text = k.ukRaha.ToString();
		upkeep2.text = k.ukSuosio.ToString();
		upkeep3.text = k .ukRauha.ToString();

        //Military upkeep:
        //wealth -= military * 10;
    }
}

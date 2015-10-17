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
    

    //int military;

    void Start()
    {
		EndOfTurn();
    }


    public void EndOfTurn()
    {
        wealth = (int)turnCtrl.kings[0].raha;
		favorPeople = (int)turnCtrl.kings[0].suosio;
		peace = (int)turnCtrl.kings[0].rauha;
        //peace = favorPeople;// + military;
        wealthNumber.text = wealth.ToString();
        peopleNumber.text = favorPeople.ToString();
        peaceNumber.text = peace.ToString();
        

        //Military upkeep:
        //wealth -= military * 10;
    }
}

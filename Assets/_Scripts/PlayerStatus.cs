using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public TurnController turnCtrl;
    public GameObject wealthText;
    //public GameObject kingText;
    public GameObject peopleText;
    public GameObject peaceText;
    public int wealth;
    //public int favorKing;
    public int favorPeople;
    public int peace;
    Text wealthNumber;
    //Text kingNumber;
    Text peopleNumber;
    Text peaceNumber;
    

    //int military;

    void Start()
    {
        turnCtrl.GetComponent<TurnController>();
        wealth = 50;
        //favorKing = 50;
        favorPeople = 50;
        //military = 10;
        wealthNumber = wealthText.GetComponent<Text>();
        //kingNumber = kingText.GetComponent<Text>();
        peopleNumber = peopleText.GetComponent<Text>();
        peaceNumber = peopleText.GetComponent<Text>();
    }


    public void EndOfTurn()
    {
        wealth = (int)turnCtrl.kings[0].raha * 100;
		favorPeople = (int)turnCtrl.kings[0].suosio * 100;
		peace = (int)turnCtrl.kings[0].rauha * 100;
        peace = favorPeople;// + military;
        wealthNumber.text = wealth.ToString();
        //kingNumber.text = favorKing.ToString();
        peopleNumber.text = favorPeople.ToString();
        peaceNumber.text = peace.ToString();
        

        //Military upkeep:
        //wealth -= military * 10;
    }
}

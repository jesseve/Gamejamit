using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    int wealth;
    int favorKing;
    int favorPeople;
    int peace;
    int military;
    

    void EndOfTurn()
    {
        peace = favorPeople + military;
    }
}

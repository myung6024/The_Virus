using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStatus : MonoBehaviour {
    private int CardHP;
    private int CardResistance;

    public void SetHP(int number)
    {
        CardHP = number;
    }
    public void SetResistance(int number)
    {
        CardResistance = number;
    }
    public int GetHP()
    {
        return CardHP;
    }
    public int GetResistance()
    {
        return CardResistance;
    }
}

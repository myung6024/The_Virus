using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStatus : MonoBehaviour {
    private int CardHP;
    private int CardResistance;
    private string CardName;

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
    public string GetName()     // get,set 블록 종류에 따른 카드 이름도 넣음
    {
        return CardName;
    }
    public void SetName(string str)
    {
        CardName = str;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawCard : MonoBehaviour {
    public GameObject CardPrefab;
    public GameObject Parent;
    public GameObject Strength;
    public GameObject Resistance;
    public GameObject image;
    private List<GameObject> Card_List;
    private int num = 0;
    public Sprite[] Card_Image_Array;
    private Sprite Card_Image;
    public Sprite Temp;
    private string[] Card_Title_Array = { "코감기 ", "기침", "독감", "중이염", "성대결절"};
    private string Card_Title;
    private string[] Card_Strength_Array = { "체력: 2", "체력: 1", "체력: 5", "체력: 6", "체력: 8"};
    private string Card_Strength;
    private string[] Card_Resistance_Array = { "저항력: 1", "저항력: 2", "저항력: 4", "저항력: 7", "저항력: 5" };
    private string Card_Resistance;

    void Start()
    {
        Card_List = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            Withdraw();
        }
    }

    public void Withdraw()
    {
        Transform temp;
        int arrayIdx = Random.Range(0, Card_Title_Array.Length);
        string debug_title, debug_strength, debug_resistance, debug_blockname;
        Card_Title = Card_Title_Array[arrayIdx];
        Card_Strength = Card_Strength_Array[arrayIdx];
        Card_Resistance = Card_Resistance_Array[arrayIdx];
        Card_Image = Card_Image_Array[arrayIdx];
        Strength.GetComponent<Text>().text = Card_Strength;
        Resistance.GetComponent<Text>().text = Card_Resistance;
        image.GetComponent<Image>().sprite = Card_Image;
        GameObject newCard = Instantiate(CardPrefab);
        newCard.transform.SetParent(Parent.transform);
        newCard.GetComponentInChildren<Text>().text=Card_Title;

        Card_List.Add(newCard);
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardTitle");
        debug_title = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardStrength");
        debug_strength = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardResistance");
        debug_resistance = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("Image");
        Temp = temp.GetComponent<Image>().sprite;
        debug_blockname = Temp.name;

        /*Debug.Log("List[" + num+"]");
        Debug.Log(debug_title);
        Debug.Log(debug_strength);
        Debug.Log(debug_resistance);*/
        //Debug.Log(debug_blockname);

        /*temp = newCard.GetComponentInChildren<Transform>().Find("CardTitle");
        debug_title=temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("CardStrength");
        debug_strength = temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("CardResistance");
        debug_resistance = temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("image");
        debug_blockname = Card_Image.name;

        Debug.Log(debug_title);
        Debug.Log(debug_strength);
        Debug.Log(debug_resistance);
        Debug.Log(debug_blockname);*/
        num++;
    }
}
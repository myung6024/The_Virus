using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blockdata : MonoBehaviour {

    public Blockmanager bMar;    // 블럭 매니저에 접근하기 위한 변수
    //private SpriteRenderer MyBlockImg;  //현재 블록의 이미지

    public int iX, iY;   //블럭 위치
    public int iType;    //블럭 종류
    private string Block_name;  //블록 종류에 따른 이름 (a,b,c,d..)
    private Dragable card_received;
    private int number;
    private int hp, resist, speed;
    //public char Blocknum;  //블럭 모양에 따른 넘버
    //public GameObject sMar;
 

    public void Recieve()
    {
        Dropable Card = GameObject.Find("Deck").GetComponent<Dropable>();
        Dropable Block = GameObject.Find("Deck").GetComponent<Dropable>();
        card_received = Card.card_to_block;//넘겨 줄때 카드 자체를 넘겨줌!!
        Block_name = card_received.GetComponentInChildren<Transform>().Find("Image").GetComponent<Image>().sprite.name;



        //int인 체력 저항력 받아오는 부분
        CardStatus Card_int_info= card_received.GetComponent<CardStatus>();
        hp = Card_int_info.GetHP();
        resist = Card_int_info.GetResistance();
        //string인 카드 이름 받아오는 부분
        //Block_name = Card_int_info.GetName();
        Debug.Log(hp);
        Debug.Log(resist);
        Debug.Log(Block_name);


        //Debug.Log(card_received.GetComponentInChildren<Transform>().Find("CardStrength").GetComponent<Text>().text);//카드를 보냈으니 체력을 받는지 확인!!
        //Block_name = Block.picture.name;
        //Debug.Log(Block_name);
        // MyBlockImg = GetComponent<SpriteRenderer>();
        // bMar = GameObject.Find("Blockmanager").GetComponent<Blockmanager>();

        Blockmanager temp = GameObject.Find("BlockManager").GetComponent<Blockmanager>();
        temp.CreateAdBlock(Block_name);
        /*
        if (Block_name == "A")
        {
            print("A");
            //Blockmanager.CreateAdBlock(Block_name);
        }
        if (Block_name == "B")
        {
            //Blockmanager.CreateAdBlock(a);
        }
        if (Block_name == "C")
        {
            print("e");
        }
        if (Block_name == "D")
        {
            print("e");
        }
        if (Block_name == "E")
        {
            print("e");
        }*/

    }
    public void SetBlockImg(Sprite _sprite) {
        gameObject.GetComponent<Image>().sprite = _sprite;}
}

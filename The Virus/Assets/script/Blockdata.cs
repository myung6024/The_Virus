using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockdata : MonoBehaviour {

    public Blockmanager bMar;    // 블럭 매니저에 접근하기 위한 변수
    //private SpriteRenderer MyBlockImg;  //현재 블록의 이미지

    public int iX, iY;   //블럭 위치
    public int iType;    //블럭 종류
    public string Block_name;
    private int number;
    //public char Blocknum;  //블럭 모양에 따른 넘버
    //public GameObject sMar;
 

    public void Recieve()
    {

        Dropable Block = GameObject.Find("Deck").GetComponent<Dropable>();
        Block_name = Block.picture.name;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class block : MonoBehaviour {

    public GameManager gMar;    // 게임 매니저에 접근하기 위한 변수
    public SpriteRenderer MyBlockImg;  //현재 블록의 이미지

    public int iX, iY;   //블럭 위치
    public int iType;    //블럭 종류

    
    void Awake()
    {
           MyBlockImg = GetComponent<SpriteRenderer>();
           gMar = GameObject.Find("GameManager").GetComponent<GameManager>();
      
    }
    public void SetBlockImg(Sprite _sprite) { MyBlockImg.sprite = _sprite; }
}

    /*
public class block : MonoBehaviour
{
    public GameObject ablock;
    public SpriteRenderer MyBlockImg;
    public GameManager gMar;

    void Start()
    {
        MyBlockImg = ablock.GetComponent<SpriteRenderer>();
        gMar = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}*/
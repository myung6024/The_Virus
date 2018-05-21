using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class block : MonoBehaviour {

    public GameManager gMar;    // 게임 매니저에 접근하기 위한 변수
    public Image MyBlockImg;  //현재 블록의 이미지
    public int state = 0;

    public int iX, iY;   //블럭 위치
    public int iType;    //블럭 종류

    
    void Awake()
    {
           MyBlockImg = GetComponent<Image>();
           gMar = GameObject.Find("GameManager").GetComponent<GameManager>();
      
    }
    public void SetBlockImg(Sprite _sprite) { MyBlockImg.sprite = _sprite; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("dwdq");
        if (collision.transform.tag == "main_block" && state != 2)
        {
            MyBlockImg.color = new Color(255/255, 100/255, 100/255);
           // Debug.Log("dwdq");
            state = 1;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("dwdq");
        if (collision.transform.tag == "main_block" && state != 2)
        {
            MyBlockImg.color = new Color(255 / 255, 100 / 255, 100 / 255);
            state = 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("dwdq");
        if (collision.transform.tag == "main_block" && state != 2)
        {
            MyBlockImg.color = new Color(255 / 255, 1, 1);
            state = 0;
        }

    }
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
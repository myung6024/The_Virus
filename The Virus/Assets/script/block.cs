using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class block : MonoBehaviour {
    
    public Image MyBlockImg;  //현재 블록의 이미지
    public int state = 0;

    public int iX, iY;   //블럭 위치
    public int iType;    //블럭 종류
    public int hp, resist, speed;


    void Awake()
    {
           MyBlockImg = GetComponent<Image>();
      
    }
    public void SetBlockImg(Sprite _sprite) { MyBlockImg.sprite = _sprite; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(GameManager.main_block_state);
        if (collision.transform.tag == "side_block" && state <= 2 && GameManager.main_block_state <= 2)
        {
            if(GameManager.main_block_state == 1)
            {
                MyBlockImg.color = new Color(150f / 255, 150f / 255, 150f / 255);
                // Debug.Log("dwdq");
                state = 1;
            }else if (GameManager.main_block_state == 2)
            {
                MyBlockImg.color = new Color(255 / 255, 100 / 255, 100 / 255);
                // Debug.Log("dwdq");
                state = 2;
            }

        }

        if (collision.transform.tag == "side_block" && state ==3 && GameManager.main_block_state <= 2)
        {
            if (GameManager.main_block_state == 1)
            {
                state = 6;
            }
        }

        if (collision.transform.tag == "main_block" && state <= 5)
        {
           
            // Debug.Log("dwdq");
            if (state <= 1 || state == 4)
            {
                MyBlockImg.color = new Color(150f / 255, 150f / 255, 150f / 255);
                state = 4;
                GameManager.main_block_state = 1;
            }
            else
            {
                GameManager.main_block_state = 2;
            }

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("dwdq");
        if (collision.transform.tag == "side_block" && state <= 2 && GameManager.main_block_state <= 2)
        {
            if (GameManager.main_block_state == 1)
            {
                MyBlockImg.color = new Color(150f / 255, 150f / 255, 150f / 255);
                // Debug.Log("dwdq");
                state = 1;
            }
            else if (GameManager.main_block_state == 2)
            {
                MyBlockImg.color = new Color(255 / 255, 100 / 255, 100 / 255);
                // Debug.Log("dwdq");
                state = 2;
            }
        }

        if (collision.transform.tag == "side_block" && state == 3 && GameManager.main_block_state <= 2)
        {
            if (GameManager.main_block_state == 1)
            {
                state = 6;
            }
        }

        if (collision.transform.tag == "main_block" && state <= 5)
        {
            if (state <= 1 || state == 4)
            {
                MyBlockImg.color = new Color(150f / 255, 150f / 255, 150f / 255);
                state = 4;
                GameManager.main_block_state = 1;
            }
            else
            {
                GameManager.main_block_state = 2;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("dwdq");
        if (collision.transform.tag == "side_block" && state <= 2 && GameManager.main_block_state <= 2)
        {
            MyBlockImg.color = new Color(255 / 255, 1, 1);
            state = 0;
        }

        if (collision.transform.tag == "main_block" && (state <= 2 || state == 4))
        {
            MyBlockImg.color = new Color(255 / 255, 1, 1);
            state = 0;
            GameManager.main_block_state = 1;

        }
        if (collision.transform.tag == "side_block" && state == 6 && GameManager.main_block_state <= 2)
        {
            state = 3;
        }


    }
    public void pp()
    {
        if(state == 3)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().SetCardSpacText(hp,resist,speed);
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
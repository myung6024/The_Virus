using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {

    private Vector3 setMoveRoate;
    private string imageName;
    private float moveSpeed = 4;
    private int hp = 100;
    private int nowHp = 100;
    private int resist = 100;
    public Sprite[] monImage;
    private characteristic monCha = characteristic.NULL;
    private state monState = state.NULL;

    enum state
    {
        NULL,
        SLOW,
        STUN
    }

    public enum characteristic
    {
        NULL,
        SLOW
    }

    // Use this for initialization
    void Start()
    {
        //mm.transform.localPosition = new Vector3(100, 100, 0);
        setMoveRoate = new Vector3(0, 1, 0);
        StartCoroutine(moved());
    }

    public void setState(int monNum, float speed, int hp, int resist, characteristic cha)
    {
        moveSpeed = speed;
        this.hp = hp;
        nowHp = hp;
        monCha = cha;
        this.resist = resist;
        GetComponent<Image>().sprite = monImage[monNum];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "bullet")
        {
            nowHp -= 10;
            transform.Find("Hpbar").GetComponent<Image>().fillAmount = (float)nowHp / (float)hp;
            collision.gameObject.SetActive(false);
            if(nowHp <= 0)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }

        }
        if (collision.transform.tag == "icebullet")
        {
            if(monCha != characteristic.SLOW)
                StartCoroutine(slow());
            nowHp -= 10;
            transform.Find("Hpbar").GetComponent<Image>().fillAmount = (float)nowHp / (float)hp;
            collision.gameObject.SetActive(false);
            if (nowHp <= 0)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }

        }

        if (collision.transform.tag == "righttile")
        {
            Debug.Log("부딪침");
            setMoveRoate = new Vector3(1, 0, 0);
        }
        if (collision.transform.tag == "uptille")
        {
            Debug.Log("부딪침");
            setMoveRoate = new Vector3(0, 1, 0);
        }
        if (collision.transform.tag == "lefttile")
        {
            Debug.Log("부딪침");
            setMoveRoate = new Vector3(-1, 0, 0);
        }
        if (collision.transform.tag == "downtile")
        {
            Debug.Log("부딪침");
            setMoveRoate = new Vector3(0, -1, 0);
        }
        if (collision.transform.tag == "final")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().damageTohp();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }

    IEnumerator slow()
    {

        if (monState != state.SLOW)
        {
            float preSpeed = moveSpeed;
            monState = state.SLOW;
            moveSpeed = moveSpeed * 0.4f;
            yield return new WaitForSeconds(1f);
            monState = state.NULL;
            moveSpeed = preSpeed;
        }
  
    }

    IEnumerator moved()
    {
        while (true)
        {
            transform.localPosition += setMoveRoate * moveSpeed;
            yield return new WaitForSeconds(0.03f);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmouse : MonoBehaviour {

    private bool onTouch = false; // 터치중인 상태인지
    private Vector2 prePos; // 움직이기 전의 좌표
    //public GameObject a_block;

    void Awake()
    {
        prePos = transform.localPosition; // 좌표 백업
        
    }

    void OnMouseDown()
    {
        Debug.Log("down");
        onTouch = true;
        StartCoroutine(DragObject());
        
        GameManager gMar = GameObject.Find("GameManager").GetComponent<GameManager>();
        gMar.fill = 0;  //블럭을 옮기려고 집었을 때 그 자리를 초기화

    }
    void OnMouseUp()
    {
        onTouch = false;
    }

    IEnumerator DragObject()
    {
        while (onTouch)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //a_block = GameObject.Find("a_block").GetComponent<GameObject>();
            /*a_block.*/
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        transform.localPosition = new Vector3(prePos.x,prePos.y,-1); // 드래그가 끝나면 원래 위치로  
    }

}

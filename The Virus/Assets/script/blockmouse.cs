using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmouse : MonoBehaviour {

    private bool onTouch = false; // 터치중인 상태인지
    private Vector2 prePos; // 움직이기 전의 좌표

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
        /*GameObject block = GameObject.Find("Block");
        BlockGameManager gMar = GameObject.Find("GameManager").GetComponent<BlockGameManager>();
        block sBlock = gMar.OriginBlock.GetComponent<block>();
        bool flag = false;
        Debug.Log("onmouseup");
        if (block.transform.position.x < -0.5 || block.transform.position.y < -0.5)
        {
            block.transform.position = new Vector3(0, 0, 10);
        }
        else if (block.transform.position.x > gMar.iBlockX-1 || block.transform.position.y > gMar.iBlockY-1)
        {
            block.transform.position = new Vector3(gMar.iBlockX - 1, gMar.iBlockY - 1, 10);
        } else{

            for (sBlock.iY = 0; sBlock.iY < gMar.iBlockY; sBlock.iY++)
            {
                for (sBlock.iX = 0; sBlock.iX < gMar.iBlockX; sBlock.iX++)
                {

                    if (block.transform.position.x < sBlock.iX + 0.5 && block.transform.position.y < sBlock.iY + 0.5) //블럭보드칸이랑 가까운데에 위치
                    {
                        block.transform.position = new Vector3(sBlock.iX, sBlock.iY, 10);// 블럭 놓았을 때 블럭보드칸 위치로
                        gMar.fill = 1;                                                       // 블럭 판이 채워짐
                        flag = true;
                        //Debug.Log(gMar.fill);
                        break;
                    }
                    if (flag == true)
                    {
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }

            }
        }
        Debug.Log("x:" + block.transform.position.x);
        Debug.Log("y:" + block.transform.position.y);*/

    }

    /*
    void OnMouseDrag()
    {
        GameObject block = GameObject.Find("Block");

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        block.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //this.transform.position = mousePosition;
        Debug.Log("x:" + block.transform.position.x);
        Debug.Log("y:" + block.transform.position.y);


        //Blockmanager gMar = GameObject.Find("BlockManager").GetComponent<Blockmanager>();
        //gMar.a_block.transform.position = mousePosition;

    }*/

    IEnumerator DragObject()
    {
        while (onTouch)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        transform.localPosition = prePos; // 드래그가 끝나면 원래 위치로  
    }

}

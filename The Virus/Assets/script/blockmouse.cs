using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmouse : MonoBehaviour {

    void OnMouseDown()
    {
        //print("마우스 다운");
        BlockGameManager gMar = GameObject.Find("GameManager").GetComponent<BlockGameManager>();
        gMar.fill = 0;  //블럭을 옮기려고 집었을 때 그 자리를 초기화

    }
    void OnMouseUp()
    {
        GameObject block = GameObject.Find("Block");
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
        Debug.Log("y:" + block.transform.position.y);
        

    }

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

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmouse : MonoBehaviour {

  
    private void Start()
    {
    }

    void OnMouseDown()
    {
        //print("마우스 다운");
        BlockGameManager gMar = GameObject.Find("GameManager").GetComponent<BlockGameManager>();
        gMar.fill = 0;  //블럭을 옮기려고 집었을 때 그 자리를 초기화

    }
    void OnMouseUp()
    {

        BlockGameManager gMar = GameObject.Find("GameManager").GetComponent<BlockGameManager>();
        block sBlock = gMar.OriginBlock.GetComponent<block>();
        bool flag = false;

        for (sBlock.iY = 0; sBlock.iY < gMar.iBlockY; sBlock.iY++)
        {
            for (sBlock.iX = 0; sBlock.iX < gMar.iBlockX; sBlock.iX++)
            {
                if (this.transform.position.x < sBlock.iX + 0.5 && this.transform.position.y < sBlock.iY + 0.5) //블럭보드칸이랑 가까운데에 위치
                {
                    this.transform.localPosition = new Vector3(sBlock.iX, sBlock.iY, 10);// 블럭 놓았을 때 블럭보드칸 위치로
                    gMar.fill = 1;                                                       // 블럭 판이 채워짐
                    flag = true;
                    //print(gMar.fill);
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
            //print(gMar.fill);
        }

    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //Blockmanager gMar = GameObject.Find("BlockManager").GetComponent<Blockmanager>();
        //gMar.a_block.transform.position = mousePosition;
      
    }

}

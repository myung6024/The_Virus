using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGameManager : MonoBehaviour {

    public GameObject OriginBlock;
    public GameObject mainblock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public GameObject[][] BlockBoard;      //블럭 보드
    public int fill;                //블럭 보드가 채워짐 여부

 
    void Awake()
    {
        BlockBoard = new GameObject[iBlockX][];
        for(int i =0; i < iBlockX; i++)
        {
            BlockBoard[i] = new GameObject[iBlockY];
        }

        CreateBlock();
    }

    //블럭보드 만드는 함수
    void CreateBlock()
    {
        for (int y =0; y< iBlockY; y++)
        {
            
            for (int x = 0; x < iBlockX; x++)
            {

                BlockBoard[y][x] = Instantiate(OriginBlock, new Vector3(x, y, 0), Quaternion.identity);
                BlockBoard[y][x].transform.SetParent(transform);
                BlockBoard[y][x].transform.localPosition = new Vector3(220+x*50, 220+y*-50, 1);
                BlockBoard[y][x].transform.localScale = new Vector3(1, 1, 1);

                int iType = Random.Range(0, BlockType.Length);

                block sBlock = BlockBoard[y][x].GetComponent<block>();
                sBlock.iX = x;
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                //BlockBoard[x][y] = iType;
                fill = 0;
       

            }
        }
    }

    public void checkBlock()
    {
        for (int y = 0; y < iBlockY; y++)
        {

            for (int x = 0; x < iBlockX; x++)
            {
                if(BlockBoard[x][y].GetComponent<block>().state == 1)
                {
                    BlockBoard[x][y].GetComponent<block>().state = 2;
                    BlockBoard[x][y].GetComponent<Image>().color = new Color(100 / 255, 100 / 255, 100 / 255);
                }
            }
        }

        Transform[] childList = mainblock.GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i] != mainblock.transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }

    public void GoMonster()
    {
        for (int y = 0; y < iBlockY; y++)
        {

            for (int x = 0; x < iBlockX; x++)
            {
                if (BlockBoard[x][y].GetComponent<block>().state == 2)
                {
                    BlockBoard[x][y].GetComponent<block>().state = 2;
                    BlockBoard[x][y].GetComponent<Image>().color = new Color(100 / 255, 100 / 255, 100 / 255);
                }
            }
        }
    }
}
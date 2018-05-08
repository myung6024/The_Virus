using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour {

    public GameObject OriginBlock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public int[][] BlockBoard;      //블럭 보드
    public int fill;                //블럭 보드가 채워짐 여부

 
    void Awake()
    {
        BlockBoard = new int[iBlockX][];
        for(int i =0; i < iBlockX; i++)
        {
            BlockBoard[i] = new int[iBlockY];
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
               
                GameObject block = Instantiate(OriginBlock, new Vector3(x, y, 0), Quaternion.identity);
                block.transform.SetParent(transform);

                int iType = Random.Range(0, BlockType.Length);

                block sBlock = block.GetComponent<block>();
                sBlock.iX = x;
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][y] = iType;
                fill = 0;
       

            }
        }
    }
}
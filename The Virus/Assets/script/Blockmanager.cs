using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmanager : MonoBehaviour {

    public GameObject OriginBlock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public int[][] BlockBoard;      //블럭 보드


    void Awake()
    {
        BlockBoard = new int[iBlockX][];
        for (int i = 0; i < iBlockX; i++)
        {
            BlockBoard[i] = new int[iBlockY];
        }


        CreateBlock();
    }

    void CreateBlock()
    {
        for (int x = 0; x < iBlockX; x++)
        {
            //print("x");
            GameObject a_block = Instantiate(OriginBlock, new Vector3(x, 0, 0), Quaternion.identity);
            a_block.transform.SetParent(transform);

            int iType = Random.Range(0, BlockType.Length);

            Blockdata sBlock = a_block.GetComponent<Blockdata>();
            //sBlock.iX = x;
            //sBlock.iY = y;
            //sBlock.iType = iType;
            //sBlock.SetBlockImg(BlockType[iType]);
            //BlockBoard[x][0] = iType;

        }

        for (int y = 0; y < iBlockY; y++)
        {
           // print("y");
            GameObject a_block = Instantiate(OriginBlock, new Vector3(0, y, 0), Quaternion.identity);
            a_block.transform.SetParent(transform);

            int iType = Random.Range(0, BlockType.Length);

            Blockdata sBlock = a_block.GetComponent<Blockdata>();
            //sBlock.iX = x;
            //sBlock.iY = y;
            //sBlock.iType = iType;
            //sBlock.SetBlockImg(BlockType[iType]);
            //BlockBoard[0][y] = iType;


        }
    }

}

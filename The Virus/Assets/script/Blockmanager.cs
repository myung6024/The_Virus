using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmanager : MonoBehaviour
{

    public GameObject OriginBlock;
    public GameObject Block;

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

        //CreateAdBlock();
    }

    public void CreateAdBlock(string name)
    {
        Block = GameObject.Find("Block");
        if (name == "A")
        {
            Debug.Log("나는 에이다");
            for (int x = 1; x < 3; x++)
            {
                //Debug.Log(x);
               // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                //Debug.Log("x:" + a_block.transform.position.x);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            for (int y = 1; y < 2; y++)
            {
                //Debug.Log(y);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                //Debug.Log("y:"+a_block.transform.position.y);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[0][y] = iType;


            }
        }
        else if (name == "B")
        {
            Debug.Log("나는 비다");
            for (int x = 1; x < 2; x++)
            {
                Debug.Log(x);
                //Debug.Log("Ori x:"+OriginBlock.transform.position.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
                //Debug.Log("x:" + a_block.transform.position.x);
                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            for (int y = 1; y < 2; y++)
            {
                Debug.Log(y);
                //Debug.Log("ori x:"+OriginBlock.transform.position.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
                //Debug.Log("x:" + a_block.transform.position.x);
                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[0][y] = iType;

            }
        }
        else if(name == "C")
        {
            Debug.Log("나는 씨다");
            for (int x = 1; x < 2; x++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x - x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);

                GameObject b_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                b_block.transform.SetParent(transform);
                
                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

                Blockdata sbBlock = b_block.GetComponent<Blockdata>();
                sbBlock.iX = x;
                sbBlock.iY = 0;
                sbBlock.iType = iType;
                sbBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            
        }else if(name == "D")
        {
            Debug.Log("나는 D다");
            for (int x = 1; x < 2; x++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x - x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
               
                GameObject b_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                b_block.transform.SetParent(transform);
                

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

                Blockdata sbBlock = b_block.GetComponent<Blockdata>();
                sbBlock.iX = x;
                sbBlock.iY = 0;
                sbBlock.iType = iType;
                sbBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            for (int y = 1; y < 2; y++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y+y, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
               
                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[0][y] = iType;

            }
        }else if(name == "E")
        {
            for (int y = 1; y < 2; y++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[0][y] = iType;

            }
        }





    }

}
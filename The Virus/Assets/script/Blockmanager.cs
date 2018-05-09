using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmanager : MonoBehaviour
{

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

        //CreateAdBlock();
    }

    public void CreateAdBlock(string name)
    {
        //Blockdata.Recieve();

        /*Blockdata bBlock = OriginBlock.GetComponent<Blockdata>();
        bBlock.Block_name = Block.picture.name;*/
        if (name == "A")
        {
            //Debug.Log("나는 에이다");

            /*for (int y = 0; y < iBlockY; y++)
            {

                for (int x = 0; x < iBlockX; x++)
                {

                    GameObject block = Instantiate(OriginBlock, new Vector3(x, y, 0), Quaternion.identity);
                    block.transform.SetParent(transform);

                    int iType = Random.Range(0, BlockType.Length - 1);

                    Blockdata sBlock = block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iY = y;
                    sBlock.iType = iType;
                    sBlock.SetBlockImg(BlockType[iType]);
                    BlockBoard[x][y] = iType;
                    //fill = 0;


                }
            }*/
            for (int x = 0; x < 3; x++)
            {
                //Debug.Log(x);
                //Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
                //Debug.Log("x:" + a_block.transform.position.x);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            for (int y = 0; y < 2; y++)
            {
                //Debug.Log(y);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);
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
            //Debug.Log("나는 비다");
            for (int x = 0; x < 2; x++)
            {
               
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[x][0] = iType;

            }
            for (int y = 0; y < 2; y++)
            {
                
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(transform);

                int iType = Random.Range(0, BlockType.Length);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iY = y;
                sBlock.iType = iType;
                sBlock.SetBlockImg(BlockType[iType]);
                BlockBoard[0][y] = iType;

            }
        }
        else
        {
            //Debug.Log("xxxxxxxx");

        }





    }

}
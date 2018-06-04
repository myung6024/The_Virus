using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blockmanager : MonoBehaviour
{

    public GameObject OriginBlock;
    public GameObject Block;

    public Sprite[] BlockType;
    public Sprite[] mainBlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public int[][] BlockBoard;      //블럭 보드


    void Awake()
    {
        
        BlockBoard = new int[iBlockX][];
        for (int i = 0; i < iBlockX; i++)
        {
            BlockBoard[i] = new int[iBlockY];
        }

    }

    public void CreateAdBlock(string name)     //다른 모양의 block prefab을 생성하는 함수
    {
        Block.GetComponent<Image>().sprite = mainBlockType[int.Parse(name)];
        Blockdata blockstate = Block.GetComponent<Blockdata>();
        Debug.Log("createad");
        if (name == "0")
        {
            Debug.Log("나는 에이다");
            for (int x = 1; x < 3; x++)
            {
                //Debug.Log(x);
               // Debug.Log("OriginBlock:" + Origin0);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3((x*50), 0, 0);
                
                //Debug.Log("x:" + a_block.transform.position.x);
              
                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = 0;
                sBlock.SetBlockImg(BlockType[0]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 0;

            }
            for (int y = 1; y < 2; y++)
            {
                //Debug.Log(y);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0,0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0,  - (y*50), 0);
                //Debug.Log("y:"+a_block.transform.position.y);
  
                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = 0;
                sBlock.SetBlockImg(BlockType[0]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[0][y] = 0;


            }
        }
        else if (name == "1")
        {
            //Debug.Log("나는 비다");
            for (int x = 1; x < 2; x++)
            {
              
                //Debug.Log("Ori x:"+OriginBlock.transform.position.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3((x * 50), 0, 0);
                //Debug.Log("x:" + a_block.transform.position.x);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iType = 1;
                sBlock.SetBlockImg(BlockType[1]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 1;

            }
            for (int y = 1; y < 2; y++)
            {
                //Debug.Log(y);
                //Debug.Log("ori x:"+OriginBlock.transform.position.x);
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0 , 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0, 0 - (y * 50), 0);
                //Debug.Log("x:" + a_block.transform.position.x);

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iY = y;
                sBlock.iType = 1;
                sBlock.SetBlockImg(BlockType[1]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[0][y] = 1;

            }
        }
        else if(name == "2")
        {
            //Debug.Log("나는 씨다");
            for (int x = 1; x < 2; x++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(0 + x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0 + (x * 50), 0, 0);

                GameObject b_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                b_block.transform.SetParent(Block.transform);
                b_block.transform.localScale = new Vector3(1, 1, 1);
                b_block.transform.localPosition = new Vector3(0 - (x * 50), 0, 0);
                

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = 2;
                sBlock.SetBlockImg(BlockType[2]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 2;

                Blockdata sbBlock = b_block.GetComponent<Blockdata>();
                sbBlock.iX = x;
                sbBlock.iY = 0;
                sbBlock.iType = 2;
                sbBlock.SetBlockImg(BlockType[2]);
                sbBlock.setHp(blockstate.getHp());
                sbBlock.setResist(blockstate.getResist());
                sbBlock.setSpeed(blockstate.getSpeed());
                sbBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 2;

            }
            
        }else if(name == "3")
        {
            //Debug.Log("나는 D다");
            for (int x = 1; x < 2; x++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x - x, 0, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0 + (x * 50), 0, 0);

                GameObject b_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x + x, 0, 0), Quaternion.identity);
                b_block.transform.SetParent(Block.transform);
                b_block.transform.localScale = new Vector3(1, 1, 1);
                b_block.transform.localPosition = new Vector3(0 - (x * 50), 0, 0);

               

                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = x;
                sBlock.iY = 0;
                sBlock.iType = 3;
                sBlock.SetBlockImg(BlockType[3]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 3;

                Blockdata sbBlock = b_block.GetComponent<Blockdata>();
                sbBlock.iX = x;
                sbBlock.iY = 0;
                sbBlock.iType = 3;
                sbBlock.SetBlockImg(BlockType[3]);
                sbBlock.setHp(blockstate.getHp());
                sbBlock.setResist(blockstate.getResist());
                sbBlock.setSpeed(blockstate.getSpeed());
                sbBlock.iType = blockstate.iType;
                BlockBoard[x][0] = 3;

            }
            for (int y = 1; y < 2; y++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y+y, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0, 0 + (y * 50), 0);
                
                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = 3;
                sBlock.SetBlockImg(BlockType[3]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[0][y] = 3;

            }
        }else if(name == "4")
        {
            for (int y = 1; y < 2; y++)
            {
                GameObject a_block = Instantiate(OriginBlock, new Vector3(OriginBlock.transform.position.x, OriginBlock.transform.position.y + y, 0), Quaternion.identity);
                a_block.transform.SetParent(Block.transform);
                a_block.transform.localScale = new Vector3(1, 1, 1);
                a_block.transform.localPosition = new Vector3(0, 0 - (y * 50), 0);
                
                Blockdata sBlock = a_block.GetComponent<Blockdata>();
                sBlock.iX = 0;
                sBlock.iY = y;
                sBlock.iType = 4;
                sBlock.SetBlockImg(BlockType[4]);
                sBlock.setHp(blockstate.getHp());
                sBlock.setResist(blockstate.getResist());
                sBlock.setSpeed(blockstate.getSpeed());
                sBlock.iType = blockstate.iType;
                BlockBoard[0][y] = 4;

            }
        }





    }

}
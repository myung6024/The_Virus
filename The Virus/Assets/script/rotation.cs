using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
       
    public GameObject Block;

    private string Block_name;  //블록 이름 (get)받아오는 변수
    private Dragable card_received;  //드래그하는 현카드 상태 받아오기
    private int rotnum = 0;

    public GameObject OriginBlock;
    public GameObject mainblock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기


    //블록 회전함수
    public void Rotation()
    {
        Debug.Log("rat");

        Blockdata blockdata = GameObject.Find("a_block").GetComponent<Blockdata>();
        Block_name = blockdata.GetName();


        if (Block_name == "A")
        {
            if (rotnum == 0)
            {
                rotnum = 1;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 3; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
            else if (rotnum == 1)
            {
                rotnum = 2;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 3; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
            else if (rotnum == 2)
            {
                rotnum = 3;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Debug.Log(Block_name + i);
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 3; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
            else if (rotnum == 3)
            {
                rotnum = 0;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 3; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
        }
        else if (Block_name == "B")
        {
            if (rotnum == 0)
            {
                rotnum = 1;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 1)
            {
                rotnum = 2;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 2)
            {
                rotnum = 3;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Debug.Log(Block_name + i);
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
            else if (rotnum == 3)
            {
                rotnum = 0;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    //Debug.Log("x:" + a_block.transform.position.x);


                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;


                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    //int iType = Random.Range(0, BlockType.Length);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);
                    //BlockBoard[x][0] = iType;

                }
            }
        }
        else if (Block_name == "C")
        {
            if (rotnum == 0)
            {
                rotnum = 1;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 1)
            {
                rotnum = 2;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 2)
            {
                rotnum = 3;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 3)
            {
                rotnum = 0;
                for (int i = 0; i < 2; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int x = 1; x < 2; x++)
                {
                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
        }
        else if (Block_name == "D")
        {
            if (rotnum == 0)
            {
                rotnum = 1;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 1)
            {
                rotnum = 2;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 2)
            {
                rotnum = 3;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 3)
            {
                rotnum = 0;
                for (int i = 0; i < 3; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);


                }
                for (int y = 1; y < 2; y++)
                {

                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }

        }
        else if (Block_name == "E")
        {
            if (rotnum == 0)
            {
                rotnum = 1;
                for (int i = 0; i < 1; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x - x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x - (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                
            }
            else if (rotnum == 1)
            {
                rotnum = 2;
                for (int i = 0; i < 1; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
            }
            else if (rotnum == 2)
            {
                rotnum = 3;
                for (int i = 0; i < 1; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int x = 1; x < 2; x++)
                {

                    // Debug.Log("OriginBlock:" + OriginBlock.transform.localPosition.x);
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x + x, Block.transform.localPosition.y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x + (x * 50), Block.transform.localPosition.y, 0);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iX = x;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }
                
            }
            else if (rotnum == 3)
            {
                rotnum = 0;
                for (int i = 0; i < 1; i++)
                {
                    GameObject[] desObject = GameObject.FindGameObjectsWithTag("side_block");
                    Destroy(desObject[i]);
                }
                for (int y = 1; y < 2; y++)
                {
                    GameObject a_block = Instantiate(mainblock, new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y + y, 0), Quaternion.identity);
                    a_block.transform.SetParent(Block.transform);
                    a_block.transform.localScale = new Vector3(1, 1, 1);
                    a_block.transform.localPosition = new Vector3(Block.transform.localPosition.x, Block.transform.localPosition.y - (y * 50), 0);
                    //Debug.Log("y:"+a_block.transform.position.y);

                    Blockdata sBlock = a_block.GetComponent<Blockdata>();
                    sBlock.iY = y;
                    sBlock.iType = 1;
                    sBlock.SetBlockImg(BlockType[1]);

                }

            }
        }

    }

}
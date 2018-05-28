using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static int main_block_state = 1;
    public GameObject can;
    public GameObject mon;
    public GameObject block;
    public GameObject monster;
    public GameObject tile;
    public GameObject tile_left;
    public GameObject tile_right;
    public GameObject tile_up;
    public GameObject tile_down;
    public GameObject tower;
    public GameObject final;
    public Text StageHpText;
    private int stageHp = 15;
    private Vector3 start_pos;

    private List<int> mons = new List<int>();

    public GameObject OriginBlock;
    public GameObject mainblock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public GameObject[][] BlockBoard;      //블럭 보드
    public int fill;                //블럭 보드가 채워짐 여부

    public GameObject boomprefab;

    GameObject _prefab;

    enum mapTile{
        none,
        tile,
        tile_start,
        tile_left,
        tile_right,
        tile_up,
        tile_down,
        final,
        mapImage,
        tower,
        tower2,
        tower3
    }

    const int mapSizeX = 10;
    const int mapSizeY = 10;

    mapTile[,] stage1 = new mapTile[mapSizeX, mapSizeY]{
        {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.final, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower2, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower3, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile_right, mapTile.tile, mapTile.tile_up, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.tower, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile_up, mapTile.tile_left, mapTile.none, mapTile.tower3, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile_start, mapTile.none, mapTile.tower2, mapTile.none, mapTile.none, mapTile.none }};
	// Use this for initialization

	void Start () {
        mapMaker();
        //makeMonster();

        BlockBoard = new GameObject[iBlockY][];
        for (int i = 0; i < iBlockY; i++)
        {
            BlockBoard[i] = new GameObject[iBlockX];
        }

        CreateBlock();
    }

    public void damageTohp()
    {
        stageHp -= 1;
        Debug.Log(stageHp);
        StageHpText.GetComponent<Text>().text = "HP : " + stageHp.ToString();
    }

    void mapMaker()
    {
        for(int i=0; i< mapSizeX; i++)
        {
            for(int j=0;j< mapSizeY;j++)
            {
                if(stage1[i,j] == mapTile.none) { }
                else
                {
                    if (stage1[i, j] == mapTile.tile) { _prefab = tile; }
                    else if (stage1[i, j] == mapTile.tile_start) { _prefab = tile; }
                    else if (stage1[i, j] == mapTile.tower) { _prefab = tower;}
                    else if (stage1[i, j] == mapTile.tower2) { _prefab = tower; }
                    else if (stage1[i, j] == mapTile.tower3) { _prefab = tower; }
                    else if (stage1[i, j] == mapTile.tile_down) { _prefab = tile_down; }
                    else if (stage1[i, j] == mapTile.tile_left) { _prefab = tile_left; }
                    else if (stage1[i, j] == mapTile.tile_right) { _prefab = tile_right; }
                    else if (stage1[i, j] == mapTile.tile_up) { _prefab = tile_up; }
                    else if (stage1[i, j] == mapTile.final) { _prefab = final; }

                    GameObject prefab = Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    prefab.transform.parent = can.transform;
                    prefab.transform.localPosition = new Vector3(60 * j - 520, 300 - 60 * i, 0);
                    prefab.transform.localScale = new Vector3(1, 1, 1);

                    if (stage1[i, j] == mapTile.tile_start) { start_pos = prefab.transform.localPosition; }

                    if (stage1[i, j] == mapTile.tower) { prefab.GetComponent<Tower>().setState(0, 4, 0.1f); }
                    else if (stage1[i, j] == mapTile.tower2) { prefab.GetComponent<Tower>().setState(1, 4, 0.1f); }
                    else if (stage1[i, j] == mapTile.tower3) { prefab.GetComponent<Tower>().setState(2, 4, 0.5f); }
                }

            }
        }
    }

    void makeMonster()
    {
        /*
        for (int i = 0; i < 15; i++)
        {
            GameObject prefab = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
            if (i % 2 == 0)
            {
                prefab.GetComponent<Monster>().setState(0, 3, 100, 10, Monster.characteristic.NULL);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (i % 3 == 0)
            {
                prefab.GetComponent<Monster>().setState(2, 5, 300, 10, Monster.characteristic.SLOW);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                prefab.GetComponent<Monster>().setState(1, 4, 200, 10, Monster.characteristic.NULL);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
        }*/

        for(int i=0; i<mons.Count; i++)
        {
            GameObject prefab = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
            if (mons[i] % 2 == 0)
            {
                prefab.GetComponent<Monster>().setState(0, 3, 100, 10, Monster.characteristic.NULL);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (mons[i] % 3 == 0)
            {
                prefab.GetComponent<Monster>().setState(2, 5, 300, 10, Monster.characteristic.SLOW);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                prefab.GetComponent<Monster>().setState(1, 4, 200, 10, Monster.characteristic.NULL);
                prefab.transform.SetParent(mon.transform);
                prefab.transform.localPosition = new Vector3(60 * 4 - 520, start_pos.y - 60 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        mons.Clear();
        
    }

    public void boomEffect(Vector3 pos)
    {
        StartCoroutine(boom(pos));
    }

    IEnumerator boom(Vector3 pos)
    {
        float size = 0;
        GameObject Boom = Instantiate(boomprefab, pos, Quaternion.identity);
        Boom.transform.SetParent(can.transform);
        Boom.transform.localScale = new Vector3(size, size, 1);
        Boom.transform.localPosition = pos;
        while (size < 1)
        {
            size += 0.1f;
            Boom.transform.localScale = new Vector3(size, size, 1);
            yield return new WaitForSeconds(0.01f);
        }

        while (size > 0)
        {
            size -= 0.1f;
            Boom.transform.localScale = new Vector3(size, size, 1);
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(Boom);

    }

    //블럭보드 만드는 함수
    void CreateBlock()
    {
        for (int y = 0; y < iBlockY; y++)
        {

            for (int x = 0; x < iBlockX; x++)
            {

                BlockBoard[y][x] = Instantiate(OriginBlock, new Vector3(x, y, 0), Quaternion.identity);
                BlockBoard[y][x].transform.SetParent(block.transform);
                BlockBoard[y][x].transform.localPosition = new Vector3(220 + x * 50, 220 + y * -50, 1);
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
                if (BlockBoard[y][x].GetComponent<block>().state == 1)
                {
                    BlockBoard[y][x].GetComponent<block>().state = 2;
                    BlockBoard[y][x].GetComponent<Image>().color = new Color(100 / 255, 100 / 255, 100 / 255);
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
                if (BlockBoard[y][x].GetComponent<block>().state == 2)
                {
                    mons.Add(BlockBoard[y][x].GetComponent<block>().state);
                    //BlockBoard[x][y].GetComponent<block>().state = 2;
                    //BlockBoard[x][y].GetComponent<Image>().color = new Color(100 / 255, 100 / 255, 100 / 255);
                }
            }
        }

        makeMonster();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Canvas can;
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

    GameObject _prefab;

    enum mapTile{
        none,
        tile,
        tile_left,
        tile_right,
        tile_up,
        tile_down,
        final,
        mapImage,
        tower,
        tower2
    }

    const int mapSizeX = 10;
    const int mapSizeY = 10;

    mapTile[,] stage1 = new mapTile[mapSizeX, mapSizeY]{
        {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.final, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower2, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile_right, mapTile.tile, mapTile.tile_up, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.tower, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.tile_up, mapTile.tile_left, mapTile.none, mapTile.tower, mapTile.none, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.tower2, mapTile.none, mapTile.none, mapTile.none }};
	// Use this for initialization

	void Start () {
        mapMaker();
        makeMonster();
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
                    else if (stage1[i, j] == mapTile.tower) { _prefab = tower;}
                    else if (stage1[i, j] == mapTile.tower2) { _prefab = tower; }
                    else if (stage1[i, j] == mapTile.tile_down) { _prefab = tile_down; }
                    else if (stage1[i, j] == mapTile.tile_left) { _prefab = tile_left; }
                    else if (stage1[i, j] == mapTile.tile_right) { _prefab = tile_right; }
                    else if (stage1[i, j] == mapTile.tile_up) { _prefab = tile_up; }
                    else if (stage1[i, j] == mapTile.final) { _prefab = final; }

                    GameObject prefab = Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    prefab.transform.parent = can.transform;
                    prefab.transform.localPosition = new Vector3(150 * j - 520, 600 - 150 * i, 0);
                    prefab.transform.localScale = new Vector3(1, 1, 1);

                    if (stage1[i, j] == mapTile.tower) { prefab.GetComponent<Tower>().setState(0, 4, 100); }
                    else if (stage1[i, j] == mapTile.tower2) { prefab.GetComponent<Tower>().setState(1, 4, 100); }
                }

            }
        }
    }

    void makeMonster()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject prefab = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
            if (i % 2 == 0)
            {
                prefab.GetComponent<Monster>().setState(0, 4, 100, 10, Monster.characteristic.NULL);
                prefab.transform.parent = can.transform;
                prefab.transform.localPosition = new Vector3(150 * 4 - 520, -800 - 150 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (i % 3 == 0)
            {
                prefab.GetComponent<Monster>().setState(2, 7, 300, 10, Monster.characteristic.SLOW);
                prefab.transform.parent = can.transform;
                prefab.transform.localPosition = new Vector3(150 * 4 - 520, -800 - 150 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                prefab.GetComponent<Monster>().setState(1, 6, 200, 10, Monster.characteristic.NULL);
                prefab.transform.parent = can.transform;
                prefab.transform.localPosition = new Vector3(150 * 4 - 520, -800 - 150 * i, 0);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }
}

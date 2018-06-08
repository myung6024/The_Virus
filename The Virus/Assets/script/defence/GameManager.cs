using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static int main_block_state = 0;
    public GameObject can;
    public GameObject blockParent;
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
    public GameObject specialLight;
    public ParticleSystem specialLight_color;
    public Blockmanager blockManager;
    public WithdrawCard cardManager;
    private string Block_name;  //블록 이름 (get)받아오는 변수
    private Dragable card_received;  //드래그하는 현카드 상태 받아오기
    public Text StageHpText;
    private int stageHp = 15;
    private Vector3 start_pos;

    public Text CardSpac_health;
    public Text CardSpac_resist;
    public Text CardSpac_speed;

    public Sprite[] days;
    public Image dayText;
    public GameObject dayText2;
    private int day = 0;

    public GameObject publishBtn;

    private List<monster_stat> mons = new List<monster_stat>();

    public GameObject OriginBlock;
    public GameObject mainblock;
    public Sprite[] BlockType;

    public int iBlockX, iBlockY;    //블럭보드의 가로 세로 크기
    public GameObject[][] BlockBoard;      //블럭 보드
    public GameObject[][] ParticleBoard;      //블럭 보드
    public int fill;                //블럭 보드가 채워짐 여부

    public GameObject boomprefab;
    public GameObject boomEffect_prefab;

    public GameObject Clear;
    public GameObject Fail;

    class monster_stat
    {
        int hp;
        int resist;
        int speed;
        int type;

        public monster_stat(int type,int hp, int resist, int speed)
        {
            this.type = type;
            this.hp = hp;
            this.resist = resist;
            this.speed = speed;
        }
        public int getHp()
        {
            return hp;
        }
        public int getResist()
        {
            return resist;
        }
        public int getSpeed()
        {
            return speed;
        }
        public int getType()
        {
            return type;
        }
    }

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

    const int mapSizeX = 7;
    const int mapSizeY = 13;

    mapTile[,] stage1 = new mapTile[mapSizeY, mapSizeX]{
        {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile_right, mapTile.final, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.tower, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile_right, mapTile.tile, mapTile.tile, mapTile.tile_up, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile_up, mapTile.tile, mapTile.tile, mapTile.tile_left, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile_right, mapTile.tile, mapTile.tile, mapTile.tile_up, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile, mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.tile_up, mapTile.tile, mapTile.tile, mapTile.tile_left, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none },
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile, mapTile.none, mapTile.none},
    {mapTile.none, mapTile.none, mapTile.none, mapTile.none, mapTile.tile_start, mapTile.none, mapTile.none}};
	// Use this for initialization

	void Start () {
        mapMaker();
        //makeMonster();

        BlockBoard = new GameObject[iBlockY][];
        ParticleBoard = new GameObject[iBlockY][];
        for (int i = 0; i < iBlockY; i++)
        {
            BlockBoard[i] = new GameObject[iBlockX];
            ParticleBoard[i] = new GameObject[iBlockX];
        }

        CreateBlock();
    }

    public void damageTohp()
    {
        FK.StaticFunc.ETCFunc.ShakeCamera(0.1f, 15f);
        stageHp -= 1;
        Debug.Log(stageHp);
        StageHpText.GetComponent<Text>().text = "HP : " + stageHp.ToString();
        if(stageHp == 0)
        {
            Clear.SetActive(true);
        }
    }

    public void publishOn()
    {
        if (publishBtn.activeSelf == false)
        {
            publishBtn.SetActive(true);
            cardManager.DrawCard(2);
        }
        if(day == 10)
        {
            Fail.SetActive(true);
        }
    }

    public void SetCardSpacText(int heal,int res,int spe)
    {
        CardSpac_health.text = "체력 : " + heal;
        CardSpac_resist.text = "저항력 : " + res;
        CardSpac_speed.text = "이동속도 : " + spe;
    }

    void mapMaker()
    {
        for(int i=0; i< mapSizeY; i++)
        {
            for(int j=0;j< mapSizeX;j++)
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
                    prefab.transform.SetParent(can.transform);
                    prefab.transform.localPosition = new Vector3(100 * j - 520, 300 - 100 * i, 0);
                    prefab.transform.localScale = new Vector3(1, 1, 1);

                    if (stage1[i, j] == mapTile.tile_start) { start_pos = prefab.transform.localPosition; }

                    if (stage1[i, j] == mapTile.tower) { prefab.GetComponent<Tower>().setState(0, 4, 0.1f); }
                    else if (stage1[i, j] == mapTile.tower2) { prefab.GetComponent<Tower>().setState(1, 4, 0.1f); }
                    else if (stage1[i, j] == mapTile.tower3) { prefab.GetComponent<Tower>().setState(2, 4, 0.5f); }

                    else if (stage1[i, j] == mapTile.tile)
                    {
                        if (stage1[i, j + 1] != mapTile.none && stage1[i, j - 1] != mapTile.none)
                        {
                            prefab.transform.localRotation = Quaternion.Euler(0f, 0f, 90);
                        }
                    }
                    else if (stage1[i, j] == mapTile.tile_down) {
                        
                    }
                    else if (stage1[i, j] == mapTile.tile_left) {
                        if (j > 0)
                        {
                            if (stage1[i, j - 1] != mapTile.none && stage1[i + 1, j] != mapTile.none)
                                prefab.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                            if (stage1[i, j - 1] != mapTile.none && stage1[i - 1, j] != mapTile.none)
                                prefab.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);

                        }
                    }
                    else if (stage1[i, j] == mapTile.tile_right) {
                        if (j > 0)
                        {
                            if (stage1[i, j + 1] != mapTile.none && stage1[i + 1, j] != mapTile.none)
                            {
                                
                                prefab.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                            }

                        }
                    }
                    else if (stage1[i, j] == mapTile.tile_up) {

                        if (stage1[i, j - 1] != mapTile.none)
                        {
                            prefab.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                        }


                    }
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
        Transform[] childList = mon.GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i] != mon.transform)
                    Destroy(childList[i].gameObject);
            }
        }
        publishBtn.SetActive(false);
        PublicStatic.liveMonCnt = mons.Count;
        for(int i=0; i<mons.Count; i++)
        {
            GameObject prefab = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
            /*if (mons[i] % 2 == 0)
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
            }*/
            prefab.GetComponent<Monster>().setState(mons[i].getType(), mons[i].getSpeed(), mons[i].getHp(), mons[i].getResist(), Monster.characteristic.NULL);
            prefab.transform.SetParent(mon.transform);
            prefab.transform.localPosition = new Vector3(100 * 4 - 520, start_pos.y - 100 * i, 0);
            prefab.transform.localScale = new Vector3(1, 1, 1);
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
        GameObject BoomEffect = Instantiate(boomEffect_prefab, pos, Quaternion.identity);
        BoomEffect.transform.SetParent(can.transform);
        BoomEffect.transform.localScale = new Vector3(100, 100, 178);
        BoomEffect.transform.localPosition = pos - new Vector3(0, 0, 10000);

        GameObject Boom = Instantiate(boomprefab, pos, Quaternion.identity);
        Boom.transform.SetParent(can.transform);
        Boom.transform.localScale = new Vector3(100, 100, 1);
        Boom.transform.localPosition = pos - new Vector3(0,0,2);
        //yield return new WaitForSeconds(1f);
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

                //int iType = Random.Range(0, BlockType.Length);

                block sBlock = BlockBoard[y][x].GetComponent<block>();
                sBlock.iX = x;
                sBlock.iY = y;
                sBlock.iType = 0;
                sBlock.SetBlockImg(BlockType[0]);
                //BlockBoard[x][y] = iType;
                fill = 0;


            }
        }
    }

    public void checkBlock()
    {
        Blockdata main_block = GameObject.Find("main_block").GetComponent<Blockdata>();
        int cnt = 0;
        for (int y = 0; y < iBlockY; y++)
        {

            for (int x = 0; x < iBlockX; x++)
            {
                if (BlockBoard[y][x].GetComponent<block>().state == 1)
                {  
                    BlockBoard[y][x].GetComponent<block>().state = 3;
                    BlockBoard[y][x].GetComponent<block>().hp = main_block.getHp();
                    BlockBoard[y][x].GetComponent<block>().resist = main_block.getResist();
                    BlockBoard[y][x].GetComponent<block>().speed = main_block.getSpeed();
                    BlockBoard[y][x].GetComponent<block>().iType = main_block.iType;
                    BlockBoard[y][x].GetComponent<Image>().sprite = blockManager.BlockType[main_block.iType];
                    BlockBoard[y][x].GetComponent<Image>().color = new Color(1, 1, 1);
                }
                else if (BlockBoard[y][x].GetComponent<block>().state == 4)
                {
                    cnt++;
                    BlockBoard[y][x].GetComponent<block>().state = 5;
                    BlockBoard[y][x].GetComponent<Image>().sprite = blockManager.mainBlockType[main_block.iType];
                    BlockBoard[y][x].GetComponent<Image>().color = new Color(1, 1, 1);
                }
                else if (BlockBoard[y][x].GetComponent<block>().state == 6)
                {
                    print("겹침");
                    BlockBoard[y][x].GetComponent<block>().state = 3;
                    BlockBoard[y][x].GetComponent<block>().hp += main_block.getHp() + BlockBoard[y][x].GetComponent<block>().hp/10;
                    BlockBoard[y][x].GetComponent<block>().resist += main_block.getResist() + BlockBoard[y][x].GetComponent<block>().resist / 10;
                    BlockBoard[y][x].GetComponent<block>().speed = (main_block.getSpeed() + BlockBoard[y][x].GetComponent<block>().speed)/2 + BlockBoard[y][x].GetComponent<block>().speed/5;
                    BlockBoard[y][x].GetComponent<Image>().color -= new Color(20/255f, 80/255f, 80/255f,0);

                    if (ParticleBoard[y][x] == null && BlockBoard[y][x].GetComponent<block>().hp > 200)
                    {
                        ParticleBoard[y][x] = Instantiate(specialLight, new Vector3(0, 0, 0), Quaternion.identity);
                        ParticleBoard[y][x].transform.SetParent(blockParent.transform);
                        ParticleBoard[y][x].transform.localPosition = BlockBoard[y][x].transform.localPosition + new Vector3(0, 0, -10000);
                        ParticleBoard[y][x].transform.localScale = new Vector3(100, 100, 178);
                        ParticleBoard[y][x].GetComponent<ParticleSystem>().startColor -= new Color(0, 80 / 255f, 80 / 255f, 0);
                    }
                }
            }
        }

        if (cnt > 0)
        {
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
    }


    public void GoMonster()
    {
        int cnt=0;
        ++day;
        if (day >= 10)
        {
            dayText.sprite = days[day / 10];
            dayText2.SetActive(true);
            dayText2.GetComponent<Image>().sprite = days[day % 10];
        }
        else
        {
            dayText.sprite = days[day];
        }
        for (int y = 0; y < iBlockY; y++)
        {
            for (int x = 0; x < iBlockX; x++)
            {
                if (BlockBoard[y][x].GetComponent<block>().state == 3)
                {
                    cnt++;
                    block bl = BlockBoard[y][x].GetComponent<block>();
                    mons.Add(new monster_stat(bl.iType, bl.hp, bl.resist, bl.speed));
                        //BlockBoard[y][x].GetComponent<block>().state);
                    //BlockBoard[x][y].GetComponent<block>().state = 2;
                    //BlockBoard[x][y].GetComponent<Image>().color = new Color(100 / 255, 100 / 255, 100 / 255);
                }
            }
        }

        if(cnt == 0)
        {
            publishOn();
        }else
            makeMonster();
    }

    public void GoToStage()
    {
        LoadingManager.LoadScene("Stage");
    }
}

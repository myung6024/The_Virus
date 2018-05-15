using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

    public GameObject[] bullet;
    public Canvas canvas;
    float time = 0.5f;
    private int towerNum;
    private float damage;
    private float attackSpeed;
    public Sprite[] towerImage;
    List<Collider2D> monsters = new List<Collider2D>();

    private float accumTimeAterUpdate;
    private float updateTime = 0.5f;
    private Vector3 myposition;

    // Use this for initialization
    void Start () {
        myposition = transform.position;
        StartCoroutine(coolTime());
	}

    public void setState(int towerNum, float damage, float attackSpeed)
    {
        this.towerNum = towerNum;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        GetComponent<Image>().sprite = towerImage[towerNum];
    }
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.transform.tag == "monster")
        {
            /*Debug.Log("들어옴");
            GameObject mBullet =  Instantiate(bullet, transform.localPosition, Quaternion.identity);
            mBullet.transform.SetParent(canvas.transform);
            mBullet.transform.localScale = new Vector3(1, 1, 1);
            mBullet.transform.localPosition = transform.localPosition;
            StartCoroutine(moveBullet(mBullet,col));*/
            monsters.Add(col);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        
    }

    IEnumerator moveBullet(GameObject mBullet, Vector3 monster)
    {
        while (mBullet.activeSelf && (mBullet.transform.localPosition.x < 800 && mBullet.transform.localPosition.x > -800) &&
            (mBullet.transform.localPosition.y < 800 && mBullet.transform.localPosition.y > -800))
        {

            // Target위치에서 자신의 위치를 뺀다
            Vector3 vec3dir = monster - myposition;
            vec3dir.Normalize();
            mBullet.transform.position = mBullet.transform.position + vec3dir/10;

            //mBullet.transform.position = Vector3.MoveTowards(mBullet.transform.position, monster.transform.position, 7 * Time.deltaTime);
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(mBullet);
    }

    IEnumerator coolTime()
    {
        while (true)
        {
            if (GetComponent<CircleCollider2D>().enabled == false)
            {
                //Debug.Log(monsters.Count);
                ShootNearlest();
                yield return new WaitForSeconds(time);
                monsters.Clear();
                GetComponent<CircleCollider2D>().enabled = true;
            }
            yield return new WaitForSeconds(attackSpeed);
        }
        
    }

    void ShootNearlest()
    {
        float length = 10000;
        int target = 0;
        for(int i =0; i<monsters.Count; i++)
        {
            float x = transform.position.x - monsters[i].transform.position.x;
            float y = transform.position.y - monsters[i].transform.position.y;
            //Debug.Log(i + "번째 : " + (x * x) + (y * y));
            if((x * x) + (y * y) < length)
            {
                length = x * x + y * y;
                target = i;
            }
        }
        GameObject mBullet = Instantiate(bullet[towerNum], transform.localPosition, Quaternion.identity);
        mBullet.transform.SetParent(transform.parent);
        mBullet.transform.localScale = new Vector3(1, 1, 1);
        mBullet.transform.localPosition = transform.localPosition;
        StartCoroutine(moveBullet(mBullet, monsters[target].transform.position));
    }
}

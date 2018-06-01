using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawCard : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject Parent;
    public GameObject Strength;
    public GameObject Resistance;
    public GameObject Speed;
    public GameObject image;
    private List<GameObject> Card_List;
    private int num = 0;
    public Sprite[] Card_Image_Array;
    private Sprite Card_Image;
    public Sprite Temp;
    private string[] Card_Title_Array = { "코감기 ", "기침", "독감", "중이염", "성대결절" };
    private string Card_Title;
    //private string[] Card_Strength_Array = { "체력: 100", "체력: 50", "체력: 70", "체력: 60", "체력: 75" };
    //private string Card_Strength;
    //private string[] Card_Resistance_Array = { "저항력: 1", "저항력: 2", "저항력: 4", "저항력: 7", "저항력: 5" };

    //private string[] Card_Speed_Array = { "이동속도: 1", "이동속도: 2", "이동속도: 4", "이동속도 3", "이동속도: 5" };
    private string Card_Speed;
    private string[] Card_Block_name = { "0", "1", "2", "3", "4" };
    private int[] HP_Array = { 100, 50, 70, 60, 75 };
    private int[] Resistance_Array = { 1, 2, 4, 7, 5 };
    private int[] Speed_Array = { 1, 2, 4, 7, 5 };
    private string Card_Resistance;

    void Start()
    {
        Card_List = new List<GameObject>();
        StartCoroutine(draw(3));
    }

    public void Withdraw()
    {
        //Transform temp;
        int arrayIdx = Random.Range(0, Card_Title_Array.Length);
        //string debug_title, debug_strength, debug_resistance, debug_blockname;
        Card_Title = Card_Title_Array[arrayIdx];
        //Card_Strength = Card_Strength_Array[arrayIdx];
        //Card_Resistance = Card_Resistance_Array[arrayIdx];
        //Card_Speed = Card_Speed_Array[arrayIdx];
        Card_Image = Card_Image_Array[arrayIdx];
        Strength.GetComponent<Text>().text = "체력 : " + HP_Array[arrayIdx].ToString();
        Resistance.GetComponent<Text>().text ="저항 : " + Resistance_Array[arrayIdx].ToString();
        Speed.GetComponent<Text>().text ="이동속도 : " + Speed_Array[arrayIdx].ToString();
        image.GetComponent<Image>().sprite = Card_Image;
        GameObject newCard = Instantiate(CardPrefab);
        newCard.transform.SetParent(Parent.transform);
        newCard.transform.localScale = new Vector3(1, 1, 1);
        newCard.GetComponentInChildren<Text>().text = Card_Title;

        Card_List.Add(newCard);
        /*temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardTitle");
        debug_title = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardStrength");
        debug_strength = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("CardResistance");
        debug_resistance = temp.GetComponent<Text>().text;
        temp = Card_List[num].GetComponentInChildren<Transform>().Find("Image");
        Temp = temp.GetComponent<Image>().sprite;
        debug_blockname = Temp.name;*/

        CardStatus info_to_block = newCard.GetComponent<CardStatus>();
        int HP_to_block = HP_Array[arrayIdx];
        int Resistance_to_block = Resistance_Array[arrayIdx];
        int Speed_to_block = Speed_Array[arrayIdx];
        string Block_Name = Card_Block_name[arrayIdx];
        info_to_block.SetHP(HP_to_block);
        info_to_block.SetResistance(Resistance_to_block);
        info_to_block.SetName(Block_Name);
        info_to_block.SetSpeed(Speed_to_block);

        /*Debug.Log("List[" + num+"]");
        Debug.Log(debug_title);
        Debug.Log(debug_strength);
        Debug.Log(debug_resistance);*/
        //Debug.Log(debug_blockname);

        /*temp = newCard.GetComponentInChildren<Transform>().Find("CardTitle");
        debug_title=temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("CardStrength");
        debug_strength = temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("CardResistance");
        debug_resistance = temp.GetComponent<Text>().text;
        temp = newCard.GetComponentInChildren<Transform>().Find("image");
        debug_blockname = Card_Image.name;

        Debug.Log(debug_title);
        Debug.Log(debug_strength);
        Debug.Log(debug_resistance);
        Debug.Log(debug_blockname);*/
        num++;
    }

    IEnumerator draw(int cnt)
    {
        for(int i=0; i<cnt; i++)
        {
            Withdraw();
            yield return new WaitForSeconds(0.1f);
        }

    }
}

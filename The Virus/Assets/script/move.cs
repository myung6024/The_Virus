using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    //public GameObject mm;
    // Use this for initialization
    public int Hp;
	void Start () {
        //mm.transform.localPosition = new Vector3(100, 100, 0);
        StartCoroutine(moved());
    }

    IEnumerator moved()
    {
        while (true)
        {
            transform.localPosition += new Vector3(0, 2f, 0);
            yield return new WaitForSeconds(0.03f);
        }
        
    }
}

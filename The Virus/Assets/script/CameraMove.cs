using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    IEnumerator leftco,rightco;
    bool left, right;

	// Use this for initialization
	void Start () {
        //StartCoroutine(cameraLeftmove());
        leftco = cameraLeftmove();
        rightco = cameraRightmove();
    }
	
    public void cameraLeft()
    {
        leftco = cameraLeftmove();
        StartCoroutine(leftco);
        if (right == true)
        {
            StopCoroutine(rightco);
            right = false;
        }
        
    }

    public void cameraRight()
    {
        rightco = cameraRightmove();
        StartCoroutine(rightco);
        
        if (left == true)
        {
            StopCoroutine(leftco);
            left = false;
        }


    }
    // Update is called once per frame
    IEnumerator cameraLeftmove()
    {
        left = true;
        print("들어옴");
        while (transform.position.x > -3.65f)
        {
            Vector3 TargetPos = new Vector3(-5f, 0, -10);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
            yield return new WaitForSeconds(0.02f);
        }
        left = false;
    }

    IEnumerator cameraRightmove()
    {
        right = true;
        print("들어옴");
        while (transform.position.x < 3.65f)
        {
            Vector3 TargetPos = new Vector3(5f, 0, -10);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
            yield return new WaitForSeconds(0.02f);
        }

        right = false;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    public Transform placeholderparent = null;
    public GameObject placeholder = null;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderparent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //Debug.Log(placeholder.transform.GetSiblingIndex());
    }
    public void OnDrag(PointerEventData eventData)
    {
        placeholder.transform.SetParent(placeholderparent);
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;
        int temp = placeholderparent.childCount;
        for (int i = 0; i < placeholderparent.childCount; i++)
        {
            if (this.transform.position.x < placeholderparent.GetChild(i).transform.position.x)
            {
                temp = i;
                //Debug.Log("I" + i);
                if (placeholder.transform.GetSiblingIndex() < temp)
                {
                    //Debug.Log("HerePlaceHolder" + placeholder.transform.GetSiblingIndex());
                    //Debug.Log("Here" + temp);
                    temp--;// placeholer temp <== temp를 placeholer로 한칸씩 떙기는 효과
                }
                break;
            }
        }
        //Debug.Log("Temp" + temp);
        placeholder.transform.SetSiblingIndex(temp);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dropable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Sprite picture;
    public Transform temp;
    public Dragable card_to_block;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("PointerEnter" + gameObject.name);
        //print("PointerEnter" + gameObject.name);
        if (eventData.pointerDrag == null)
            return;
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            d.placeholderparent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("PointerExit"+ gameObject.name);
        //print("PointerExit" + gameObject.name);

        if (eventData.pointerDrag == null)
            return;
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null && d.placeholderparent == this.transform)
        {
            d.placeholderparent = d.parentToReturnTo;
        }
        if(gameObject.name=="Deck")
        {
            //temp = d.GetComponentInChildren<Transform>().Find("Image");
            //picture = temp.GetComponent<Image>().sprite;
            card_to_block = d;
            Blockdata reciever = GameObject.Find("a_block").GetComponent<Blockdata>();
            reciever.Recieve();
            Destroy(d.gameObject);
            Destroy(d.placeholder);
            // Debug.Log(picture.name);

        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to" + gameObject.name);

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if(d!=null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

}

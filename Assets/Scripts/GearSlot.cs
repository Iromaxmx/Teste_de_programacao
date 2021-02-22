using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearSlot : MonoBehaviour, IDropHandler
{
    public enum slotType { slotBase, slotGear01, slotGear02, slotGear03 , slotGear04 , slotGear05};
    public slotType slots;
    public Sprite gearImg;
    [SerializeField] private RectTransform rectTransform;
    private Vector2 sizeGear = new Vector2(100, 100);
    private singleton sing;

    void Awake()
    {
        sing = FindObjectOfType<singleton>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(slots == slotType.slotBase)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
        }
        if (slots == slotType.slotGear01)
        {
            eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = sizeGear;
            eventData.pointerDrag.GetComponent<SphereCollider>().enabled = true;
        }
        if (slots == slotType.slotGear02)
        {
            eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = sizeGear;
            eventData.pointerDrag.GetComponent<SphereCollider>().enabled = true;
        }
        if (slots == slotType.slotGear03)
        {
            eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = sizeGear;
            eventData.pointerDrag.GetComponent<SphereCollider>().enabled = true;
        }
        if (slots == slotType.slotGear04)
        {
            eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = sizeGear;
            eventData.pointerDrag.GetComponent<SphereCollider>().enabled = true;
        }
        if (slots == slotType.slotGear05)
        {
            eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = sizeGear;
            eventData.pointerDrag.GetComponent<SphereCollider>().enabled = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("gear"))
        {
            sing.addQtd(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("gear"))
        {
            other.GetComponent<SphereCollider>().enabled = false;
            if (sing.gearQtd > 0)
            sing.gearQtd -= 1;
        }
    }
}

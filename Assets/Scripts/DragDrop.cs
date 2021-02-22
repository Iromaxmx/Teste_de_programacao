using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CanvasGroup canvasGroup;
    public Sprite gearImg;
    private singleton sing;
    private GearSlot[] slots;

    private void Awake()
    {
        slots = FindObjectsOfType<GearSlot>();
        sing = FindObjectOfType<singleton>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        eventData.pointerDrag.GetComponent<Image>().sprite = gearImg;
        eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = new Vector2(70, 70);
        eventData.pointerDrag.GetComponent<RectTransform>().rotation = Quaternion.Euler(Vector2.zero);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
    }
}

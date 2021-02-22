using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gear : MonoBehaviour
{
    public float speed;

    private singleton sing;
    private Vector3 gearRotation;
    private float horario;
    private float antiHorario;
    public float XposMax, XposMin, YposMax, YposMin;
    RectTransform transform;
    private void Start()
    {
        transform = GetComponent<RectTransform>();
        sing = FindObjectOfType<singleton>();
        speed = sing.gearSpeed;
        antiHorario = speed * -1;
        horario = speed;
    }
    private void Update()
    {
        gearRotation.z += speed * Time.deltaTime;
        if (sing.canRotate)
        {
            this.GetComponent<RectTransform>().rotation = Quaternion.Euler(gearRotation);
        }
        if(transform.anchoredPosition.x > XposMax)
        {
            transform.anchoredPosition = new Vector2(XposMax,transform.anchoredPosition.y);
        }
        if (transform.anchoredPosition.x < XposMin)
        {
            transform.anchoredPosition = new Vector2(XposMin, transform.anchoredPosition.y);
        }
        if (transform.anchoredPosition.y > YposMax)
        {
            transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, YposMax);
        }
        if (transform.anchoredPosition.y < YposMin)
        {
            transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, YposMin);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (sing.canRotate)
        {
        if (other.gameObject.GetComponent<GearSlot>().slots == GearSlot.slotType.slotGear04 ||
          other.gameObject.GetComponent<GearSlot>().slots == GearSlot.slotType.slotGear05)
        {
            speed = horario;
        }
        else if (other.gameObject.GetComponent<GearSlot>().slots == GearSlot.slotType.slotGear01 ||
           other.gameObject.GetComponent<GearSlot>().slots == GearSlot.slotType.slotGear02 ||
           other.gameObject.GetComponent<GearSlot>().slots == GearSlot.slotType.slotGear03)
        {
            speed = antiHorario;
        }
        }
    }

}

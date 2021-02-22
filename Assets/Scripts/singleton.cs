using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class singleton : MonoBehaviour
{
    public static singleton Singleton;
    public bool canRotate = false;
    public int gearQtd;
    [Range(0, 20)] public float gearSpeed;
    public string startTaskTxt;
    public string taskFinishTxt;
    public TextMeshProUGUI taskTxt;

    private void Awake()
    {
        Singleton = this;
    }
    private void Update()
    {
        if (gearQtd == 5)
        {
            canRotate = true;
            taskTxt.text = taskFinishTxt;
        }else
        {
            taskTxt.text = startTaskTxt;
            canRotate = false;
        }
    }
    public void addQtd(int qtd)
    {
        gearQtd += qtd;
    }

    public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

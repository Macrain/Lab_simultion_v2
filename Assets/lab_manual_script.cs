using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lab_manual_script : MonoBehaviour
{

    public GameObject lab_manual_canvas;


    public void Start()
    {        
        lab_manual_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.clicked_lab_manual)
        {
            lab_manual_canvas.SetActive(true);
        }
        else if (!Globals.clicked_lab_manual)
        {
            lab_manual_canvas.SetActive(false);
        }
    }
}

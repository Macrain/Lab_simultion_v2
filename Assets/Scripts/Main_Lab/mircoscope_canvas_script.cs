using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mircoscope_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_back;
    public GameObject microscope_canvas;
    public GameObject Wafer_gameObj;

    // Use this for initialization
    void Start()
    {
        button_back = button_back_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }

    void button_back_TaskOnClick()
    {
        Globals.wafer_click_microscope = false;
        microscope_canvas.SetActive(false);
        //Wafer_gameObj.transform.Rotate(90, 0, 0, Space.Self);
        Wafer_gameObj.transform.RotateAround(Wafer_gameObj.transform.parent.position, Wafer_gameObj.transform.parent.right, 90);
    }
}
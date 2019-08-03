using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lab_manual_canvas_script : MonoBehaviour {
    public Button button_back_field;
    public Button button_back;
    public GameObject lab_manual_canvas_canvas;

    // Use this for initialization
    void Start () {
        button_back = button_back_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
    }

    void button_back_TaskOnClick()
    {
        Globals.clicked_lab_manual = false;
        lab_manual_canvas_canvas.SetActive(false);
        //Wafer_gameObj.transform.Rotate(90, 0, 0, Space.Self);
    }
}

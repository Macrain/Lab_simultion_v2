using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warning_canvas : MonoBehaviour {

    public Button button_done_field;
    public Button button_done;

    public GameObject Warning_Canvas;

    void Start () {
        button_done = button_done_field.GetComponent<Button>();
        button_done.onClick.AddListener(button_done_TaskOnClick); // create functions
    }

    void button_done_TaskOnClick() // when you click on the done button
    {
        Warning_Canvas.SetActive(false); // turn the canvas off
        Globals.warning_canvas = false;
    }
}

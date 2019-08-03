using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hot_Plate_Panel_Canvas : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject HotPlate_Panel_Canvas;
    public Slider Hot_Plate_Time;
    public Slider Hot_Plate_Temperature;
    public Text Hot_Plate_Time_Answer;
    public Text Hot_Plate_Temperature_Answer;

    // Use this for initialization
    void Start()
    {
        button_back = button_back_field.GetComponent<Button>();
        button_done = button_done_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
        button_done.onClick.AddListener(button_done_TaskOnClick);
    }

    private void Update()
    {
        Hot_Plate_Time_Answer.text = Hot_Plate_Time.value.ToString("0.0");
        Hot_Plate_Temperature_Answer.text = Hot_Plate_Temperature.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.clicked_on_spinner_pannel = false;
        HotPlate_Panel_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.Hot_Plate_Time_value = Hot_Plate_Time.value;
        Globals.Hot_Plate_Temperature_value = Hot_Plate_Temperature.value;

        Globals.clicked_on_hot_plate_panel = false;
        HotPlate_Panel_Canvas.SetActive(false);
    }
}

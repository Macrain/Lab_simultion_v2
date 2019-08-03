using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinner_Pannel_Canvas : MonoBehaviour {
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Spinner_Panel_Canvas;
    public Slider Spread_time;
    public Slider Spread_speed;
    public Slider Spin_time;
    public Slider Spin_speed;
    public Text Spread_time_Answer;
    public Text Spread_speed_Answer;
    public Text Spin_time_Answer;
    public Text Spin_speed_Answer;


    // Use this for initialization
    void Start () {
        button_back = button_back_field.GetComponent<Button>();
        button_done = button_done_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
        button_done.onClick.AddListener(button_done_TaskOnClick);
    }

    private void Update()
    {
        Spread_time_Answer.text = Spread_time.value.ToString("0.0");
        Spread_speed_Answer.text = Spread_speed.value.ToString("0.0");
        Spin_time_Answer.text = Spin_time.value.ToString("0.0");
        Spin_speed_Answer.text = Spin_speed.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.clicked_on_spinner_pannel = false;
        Spinner_Panel_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.Spread_time_value = Spread_time.value;
        Globals.Spread_speed_value = Spread_speed.value;
        Globals.Spin_time_value = Spin_time.value;
        Globals.Spin_speed_value = Spin_speed.value;

        Globals.clicked_on_spinner_pannel = false;
        Spinner_Panel_Canvas.SetActive(false);
    }
}
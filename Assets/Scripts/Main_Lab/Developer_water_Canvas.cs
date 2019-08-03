using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Developer_water_Canvas : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Developer_water_Canvas1;
    public Slider time;
    public Text time_Answer;

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
        time_Answer.text = time.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.wafer_hit_Developer_water = false;
        Developer_water_Canvas1.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.time_developer_water_value = time.value;
        Globals.wafer_hit_Developer_water = false;
        Developer_water_Canvas1.SetActive(false);
    }
}

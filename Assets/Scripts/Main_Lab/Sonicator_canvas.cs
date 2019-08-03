using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonicator_canvas : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Sonicator_Canvas_obj;

    public Slider Acetone_time_slider;
    public Slider Methanol_time_slider;
    public Slider Water_time_slider;

    public Text Acetone_time_Answer;
    public Text Methanol_time_Answer;
    public Text Water_time_Answer;

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
        Acetone_time_Answer.text = Acetone_time_slider.value.ToString("0.0");
        Methanol_time_Answer.text = Methanol_time_slider.value.ToString("0.0");
        Water_time_Answer.text = Water_time_slider.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Debug.Log("You have clicked the button Back!");
        Globals.wafer_hit_Sonicator = false;
        Sonicator_Canvas_obj.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Debug.Log("You have clicked the button Done!");

        Globals.Acetone_time_value = Acetone_time_slider.value;
        Globals.Methanol_time_value = Methanol_time_slider.value;
        Globals.Water_time_value = Water_time_slider.value;

        Globals.wafer_hit_Sonicator = false;
        Sonicator_Canvas_obj.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Make sure to set the clicked on button in the FPController to stop the motion 
public class Piranha_Canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Piranha_Canvas;
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
        Globals.wafer_hit_piranha = false;
        Piranha_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.piranha_time_value = time.value;
        Globals.wafer_hit_piranha = false;
        Piranha_Canvas.SetActive(false);
    }
}

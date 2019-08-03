using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHF_canvas_script : MonoBehaviour {
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject BHF_Canvas;
    public Slider time;
    public Text time_Answer;

    GameObject Wafer_gameObj;
    Wafer Wafer_script;

    void Start ()
    {

        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_script = Wafer_gameObj.GetComponent<Wafer>();

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
        Globals.wafer_hit_BHF = false;
        BHF_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.BHF_time = time.value;
        Globals.wafer_hit_BHF = false;
        BHF_Canvas.SetActive(false);
    }
}

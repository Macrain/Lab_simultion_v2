using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expose_canvas_script : MonoBehaviour {

    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;

    public GameObject Expose_Canvas;
    //public GameObject Directional_Canvas;
    //public GameObject Done_Canvas;

    public Slider time;
    public Text time_Answer;
    public Slider energy;
    public Text energy_Answer;
    public Slider power;
    public Text power_Answer;

    // Use this for initialization
    void Start () {
        button_back = button_back_field.GetComponent<Button>();
        button_done = button_done_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
        button_done.onClick.AddListener(button_done_TaskOnClick);
        State_machine_2.flag_correct = false;
    }
	
	// Update is called once per frame
	void Update () {
        time_Answer.text = time.value.ToString("0.0");
        energy_Answer.text = energy.value.ToString("0.0");
        power_Answer.text = power.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.clicked_mask_aligner = false;
        Expose_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.expose_time = time.value;
        Globals.expose_energy = energy.value;
        Globals.expose_power = power.value;
        State_machine_2.flag_correct = true;
        //Debug.Log(State_machine_2.flag_correct);
        //Expose_Canvas.SetActive(false);
        //Done_Canvas.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evap_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject evap_canvas;
    public Slider Gas_flow_rate;
    public Slider Time;
    public Slider Temperature;
    public Text Gas_flow_rate_Answer;
    public Text Temperature_Answer;
    public Text Time_Answer;
    public Dropdown Gas_flow_rate_dropdown;
    public string Gas_flow_rate_dropdown_text;

    GameObject Wafer_gameObj;
    Wafer Wafer_script;

    // Use this for initialization
    void Start()
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
        Gas_flow_rate_Answer.text = Gas_flow_rate.value.ToString("0.0");
        Temperature_Answer.text = Temperature.value.ToString("0.0");
        Time_Answer.text = Time.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.clicked_evap = false;
        evap_canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.Evap_flow_rate = Gas_flow_rate.value;
        Globals.Evap_temperature = Temperature.value;
        Globals.Evap_time = Time.value;

        Globals.Gas_name = Gas_flow_rate_dropdown.value;

        evap_canvas.SetActive(false);
        Globals.clicked_evap = false;
        //if (State_machine.master_step_count == 2)
        //    create_layer_SiO2();
    }

    void create_layer_SiO2()
    {
        Debug.Log("create_layer_siO2");
        //Wafer_script.Create_virtual_layer_on_wafer(8); // 8 = SiO2
        //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
        //Wafer_script.remove_material(0);
    }

    void create_layer_Al()
    {
        Debug.Log("create_layer AL");
        //Wafer_script.Create_virtual_layer_on_wafer(9); // 9 = Al
        //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer - 1);
    }

}
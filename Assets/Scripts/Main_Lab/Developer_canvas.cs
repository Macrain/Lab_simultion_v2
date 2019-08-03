using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Developer_canvas : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Developer_Canvas1;
    public Slider time;
    public Text time_Answer;

    public GameObject Wafer_gameObj;
    Wafer Wafer_script;

    // Use this for initialization
    void Start()
    {
        //Wafer_script = Wafer_gameObj.GetComponent<Wafer>();

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
        Globals.wafer_hit_Developer = false;
        Developer_Canvas1.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.time_developer_value = time.value;
        Globals.wafer_hit_Developer = false;
        Developer_Canvas1.SetActive(false);

        //if ((Globals.time_developer_value <= 60 && Globals.time_developer_value >= 30)) { }
        //    remove_exposed_photoresist();
    }

    void remove_exposed_photoresist()
    {
        switch (maskchoosing.chosen)         
        {
            case 1:
                Wafer_script.remove_material(1);
                Debug.Log("remove_exposed_photoresist mask1");
                break;
            case 2:
                Wafer_script.remove_material(2);
                Debug.Log("remove_exposed_photoresist mask2");
                break;
            case 3:
                Wafer_script.remove_material(3);
                Debug.Log("remove_exposed_photoresist mask3");
                break;
            case 4:
                Wafer_script.remove_material(4);
                Debug.Log("remove_exposed_photoresist mask4");
                break;
        }
    }
}

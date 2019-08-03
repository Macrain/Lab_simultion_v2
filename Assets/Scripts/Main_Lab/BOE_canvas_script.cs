using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Make sure to set the clicked on button in the FPController to stop the motion 
public class BOE_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject BOE_Canvas;
    public Slider time;
    public Text time_Answer;

    //public GameObject Wafer_gameObj;
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
        Globals.wafer_hit_BOE = false;
        BOE_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.BOE_time_value = time.value;
        Globals.wafer_hit_BOE = false;
        BOE_Canvas.SetActive(false);
       
        // check is siO2
        //remove_material();
    }

    void remove_material()
    {
        switch (maskchoosing.chosen)
        {
            case 1:
                Wafer_script.remove_material_second_to_top_layer(1);
                Debug.Log("remove_SiO2  mask1");
                break;
            case 2:
                Wafer_script.remove_material_second_to_top_layer(2);
                Debug.Log("remove_SiO2 mask2");
                break;
            case 3:
                Wafer_script.remove_material_second_to_top_layer(3);
                Debug.Log("remove_SiO2 mask3");
                break;
            case 4:
                Wafer_script.remove_material_second_to_top_layer(4);
                Debug.Log("remove_SiO2  mask4");
                break;
        }
    }
}

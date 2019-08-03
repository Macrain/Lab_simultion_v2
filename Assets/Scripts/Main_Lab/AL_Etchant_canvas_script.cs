using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Make sure to set the clicked on button in the FPController to stop the motion 
public class AL_Etchant_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Al_Etchant_Canvas;
    public Slider time;
    public Text time_Answer;

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
        time_Answer.text = time.value.ToString("0.0");
    }

    void button_back_TaskOnClick()
    {
        Globals.wafer_hit_Al_Etchant = false;
        Al_Etchant_Canvas.SetActive(false);
    }

    void button_done_TaskOnClick()
    {
        Globals.Al_Etchant_time_value = time.value;
        Globals.wafer_hit_Al_Etchant = false;
        Al_Etchant_Canvas.SetActive(false);

        // Check if AL
        //remove_material();
    }

    void remove_material()
    {
        switch (maskchoosing.chosen)
        {
            case 1:
                Wafer_script.remove_material_second_to_top_layer(1);
                Debug.Log("remove_AL mask1");
                break;
            case 2:
                Wafer_script.remove_material_second_to_top_layer(2);
                Debug.Log("remove_AL mask2");
                break;
            case 3:
                Wafer_script.remove_material_second_to_top_layer(3);
                Debug.Log("remove_AL mask3");
                break;
            case 4:
                Wafer_script.remove_material_second_to_top_layer(4);
                Debug.Log("remove_AL mask4");
                break;
        }
    }
}

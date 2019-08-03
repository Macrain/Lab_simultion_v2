using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Tip: Make sure to set the clicked on button in the FPController to stop the motion 
// Attached to propanol canvas

public class Propanol_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    Button button_back;
    Button button_done;
    public GameObject Propanol_Canvas;
    public Slider time;
    public Text time_Answer;
    
    //public GameObject Wafer_gameObj;
    //Wafer Wafer_script;

    void Start()
    {

        //Wafer_script = Wafer_gameObj.GetComponent<Wafer>(); // Allows us to use wafer.cs

        button_back = button_back_field.GetComponent<Button>();
        button_done = button_done_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick); //create functions
        button_done.onClick.AddListener(button_done_TaskOnClick); //create functions
    }

    private void Update()
    {
        time_Answer.text = time.value.ToString("0.0"); // set the string to 0 to look nice and initialize
    }

    void button_back_TaskOnClick() // when you click on the back button...
    {
        Globals.wafer_hit_propanol = false; // reset variable
        Propanol_Canvas.SetActive(false); // turn the canvas off
    }

    void button_done_TaskOnClick() // when you click on the done button
    {
        Globals.propanol_time_value = time.value; // assign the time value to globals for record keeping
        Globals.wafer_hit_propanol = false; // reset variable
        Propanol_Canvas.SetActive(false); // turn the canvas off

        //remove_all_photoresist(); 
    }

    void remove_all_photoresist()
    {
        //if(Wafer.wafer_layers[Wafer_script.layer_number_wafer-1,5,11] == 1)
        //    Wafer_script.remove_entire_layer(); // assume that propanol removes the photoresist
    }
}

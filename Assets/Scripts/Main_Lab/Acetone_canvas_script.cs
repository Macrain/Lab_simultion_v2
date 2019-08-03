using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Summary: Controls the Canvas
 * Tip: Make sure to set the clicked on button in the FPController to stop the motion 
 * Note: Attached to Acetone canvas
*/
public class Acetone_canvas_script : MonoBehaviour
{
    public Button button_back_field;
    public Button button_done_field;
    public Button button_back;
    public Button button_done;
    public GameObject Acetone_Canvas;
    public Slider time;
    public Text time_Answer;

    /* Function: Start()
     * Parameters: none
     * Function:  Set up all the buttons and connect them to the proper functions
     */
    void Start()
    {
        button_back = button_back_field.GetComponent<Button>();
        button_done = button_done_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick); //create functions
        button_done.onClick.AddListener(button_done_TaskOnClick); // create functions
    }

    /* Function: Update()
     * Parameters: none
     * Function: Set the slider to 0.0
     */
    private void Update()
    {
        time_Answer.text = time.value.ToString("0.0"); // set the string to 0 to look nice and initialize
    }

    /* Function: button_back_TaskOnClick()
     * Parameters: none
     * Fucntion: If the back button is pressed, then the flag wafer_hit_acetone is set to false in Globals.cs and the canvas is turned off.
     */
    void button_back_TaskOnClick() // when you click on the back button...
    {
        Globals.wafer_hit_acetone = false; // reset "wafer_hit_acetone"
        Acetone_Canvas.SetActive(false); // turn the canvas off
    }

    /* Function: button_done_TaskOnClick()
     * Parameters: none
     * Fucntion: Collects all the values that were set by the user in the siders and saves them in Globals.cs.  
     *              It also turns the canvas off. 
     */
    void button_done_TaskOnClick() // when you click on the done button
    {
        Globals.acetone_time_value = time.value; // assign the time value to globals for record keeping
        Globals.wafer_hit_acetone = false; // reset "wafer_hit_acetone"
        Acetone_Canvas.SetActive(false); // turn the canvas off
    }
}

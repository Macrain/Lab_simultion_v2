using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attached to Propanol
public class Propanol_script : MonoBehaviour
{
    public GameObject Propanol_canvas;
    public GameObject Warning_canvas;
    public GameObject Wafer_gameObj;
    public GameObject Player;
    public Text warning_messages;

    /* Function: Start()
    * Parameters: none
    * Function: Make sure that the canvas is set to false so it is not on.
    */
    void Start()
    {
        Propanol_canvas.SetActive(false);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }

    /* Function: Update()
     * Parameters: none
     * Function: If the wafer has collided with the bowl, the the canvas turns on else it turns off.  This collision is set in wafer.cs
     */
    void Update()
    {
        if (Globals.wafer_hit_propanol)
        {
            if ((State_machine.master_step_count != 3) && (State_machine.master_step_count != 10) && (State_machine.master_step_count != 21) && (State_machine.master_step_count != 30))
            {
                Wafer_gameObj.transform.parent = Player.transform;
                Wafer_gameObj.transform.localPosition = new Vector3(0, 1, 3);
                Wafer_gameObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                Wafer_gameObj.GetComponent<Rigidbody>().useGravity = false;
                Wafer_gameObj.GetComponent<Rigidbody>().isKinematic = false;
                Wafer_gameObj.GetComponent<BoxCollider>().enabled = false;
                Globals.pick_up_wafer = true;

                Warning_canvas.SetActive(true);
                Globals.warning_canvas = true;
                Globals.wafer_hit_propanol = false;
                warning_messages.text = "Do not put the wafer into this solution at this step in the process.  Poropanol is used to remove all photoresist from the wafer.  However, at this step, it may damage the wafer.";
            }
            else
                Propanol_canvas.SetActive(true);
        }
        else if (!Globals.wafer_hit_propanol)
        {
            Propanol_canvas.SetActive(false);
        }

    }
}


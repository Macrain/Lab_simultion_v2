using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// On the pannel of the spinner in the photo resist roomf
public class Evap_script : MonoBehaviour
{

    public GameObject evap_Canvas; //public static GameObject Spinner_Panel_Canvas; 1/9 946
    public GameObject Warning_canvas;
    GameObject Wafer_gameObj;
    public GameObject Player;
    public Text warning_messages;

    void Start()
    {
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }

    public void click_panel()
    {
        if (Globals.clicked_evap)
        {
            evap_Canvas.SetActive(false);
            Globals.clicked_evap = false;
        }
        else if (!Globals.clicked_evap)
        {
            if (State_machine.master_step_count != 31 )
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
                Globals.clicked_evap = false;
                warning_messages.text = "Do not put the wafer into the evaporator at this step in the process.  The evaporator is used to add material to the wafer and at this step, adding material will damage the wafer.";
            }
            else
            {
                evap_Canvas.SetActive(true);
                Globals.clicked_evap = true;
            }

        }
    }
}

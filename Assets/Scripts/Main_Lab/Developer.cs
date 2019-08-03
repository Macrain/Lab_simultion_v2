using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// On the pannel of the spinner in the photo resist roomf
public class Developer : MonoBehaviour
{
    public GameObject Developer_obj;
    public GameObject Warning_canvas;
    public GameObject Wafer_gameObj;
    public GameObject Player;
    public Text warning_messages;

    void Start()
    {
        Developer_obj.SetActive(false);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_Developer)
        {
            if ( (State_machine.master_step_count != 8) && (State_machine.master_step_count != 19) && (State_machine.master_step_count != 28) && (State_machine.master_step_count != 37) )
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
                Globals.wafer_hit_Developer = false;
                warning_messages.text = "Do not put the wafer into this solution at this step in the process.  This solution is used to develop photoresist that has been exposed.  However, at this step, it may damage the wafer.";
            }
            else
                Developer_obj.SetActive(true);
        }
        else if (!Globals.wafer_hit_Developer)
        {
            Developer_obj.SetActive(false);
        }

    }
}

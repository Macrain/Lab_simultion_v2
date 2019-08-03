using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// On the pannel of the spinner in the photo resist roomf
public class AL_Etchant_script : MonoBehaviour
{
    public GameObject AL_Etchant_canvas;
    public GameObject Warning_canvas;
    public GameObject Wafer_gameObj;
    public GameObject Player;
    public Text warning_messages;

    void Start()
    {
        AL_Etchant_canvas.SetActive(false);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_Al_Etchant)
        {
            if (State_machine.master_step_count != 38)
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
                Globals.wafer_hit_Al_Etchant = false;
                warning_messages.text = "Do not put the wafer into this solution at this step in the process.  This chemical is used to etch exposed aluminum.  However, at this step, it may damage the wafer.";
            }
            else
                AL_Etchant_canvas.SetActive(true);
        }
        else if (!Globals.wafer_hit_Al_Etchant)
        {
            AL_Etchant_canvas.SetActive(false);
        }

    }
}

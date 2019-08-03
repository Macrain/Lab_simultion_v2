using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHF_script : MonoBehaviour {

    public GameObject BHF_canvas;
    public GameObject Warning_canvas;
    public GameObject Wafer_gameObj;
    public GameObject Player;
    public Text warning_messages;

    void Start () {
        BHF_canvas.SetActive(false);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
    }
	
	void Update () {
        if (Globals.wafer_hit_BHF)
        {
            if (State_machine.master_step_count != 13)
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
                Globals.wafer_hit_BHF = false;
                warning_messages.text = "Do not put the wafer into this solution at this step in the process.  This chemical is used to etch exposed dopant.  However, at this step, it may damage the wafer.";
            }
            else
                BHF_canvas.SetActive(true);
        }
        else if (!Globals.wafer_hit_BHF)
        {
            BHF_canvas.SetActive(false);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profilometer_script : MonoBehaviour {

    public GameObject Player;
    public GameObject profilometer_Canvas;
    public GameObject Wafer_gameObj;
    Wafer Wafer_script;
    GameObject row;


    void Start () {
        //Wafer_script = Wafer_gameObj.GetComponent<Wafer>();
        profilometer_Canvas.SetActive(false);
        Wafer_gameObj = GameObject.Find("Wafer_temp");
        //select_profilometer();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Globals.wafer_click_profilometer)
        {
            profilometer_Canvas.SetActive(true);
            Player.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (!Globals.wafer_click_profilometer)
        {
            profilometer_Canvas.SetActive(false);
        }
    }

    /*public void select_profilometer()
    {
        GameObject layer_top = GameObject.Find("Parent" + Wafer_script.layer_number_wafer.ToString());
        GameObject layer_second_top = GameObject.Find("Parent" + (Wafer_script.layer_number_wafer-1).ToString());

    }*/
}

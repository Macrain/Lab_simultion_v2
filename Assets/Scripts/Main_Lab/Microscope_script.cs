using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscope_script : MonoBehaviour {

    public GameObject Player;
    public GameObject Microscope_Canvas;
    public GameObject Wafer_gameObj;
    Wafer Wafer_script;
    

    public void Start()
    {
        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_script = Wafer_gameObj.GetComponent<Wafer>();
        Microscope_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_click_microscope)
        {
            Microscope_Canvas.SetActive(true);
        }
        else if (!Globals.wafer_click_microscope)
        {
            Microscope_Canvas.SetActive(false);
        }
    }

    public void select_microscope()
    {         
        Wafer_gameObj.transform.parent = Player.transform;
        //Wafer_gameObj.transform.rotation = Quaternion.identity;
        //Wafer_gameObj.transform.Rotate(0, 270, 0, Space.Self);
        Wafer_gameObj.transform.RotateAround(Wafer_gameObj.transform.parent.position, Wafer_gameObj.transform.parent.right, -90);
        Wafer_gameObj.transform.localPosition = new Vector3(0, 2, 2);       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class hot_plate_script : MonoBehaviour
{

    public GameObject Hot_plate_panel_Canvas; //public static GameObject Spinner_Panel_Canvas; 1/9 946

    void Start()
    {
        Hot_plate_panel_Canvas.SetActive(false);
    }

    public void click_panel_hot_plate()
    {
        if (Globals.clicked_on_hot_plate_panel)
        {
            Hot_plate_panel_Canvas.SetActive(false);
            Globals.clicked_on_hot_plate_panel = false;
        }
        else if (!Globals.clicked_on_hot_plate_panel)
        {
            Hot_plate_panel_Canvas.SetActive(true);
            Globals.clicked_on_hot_plate_panel = true;
        }
    }
}

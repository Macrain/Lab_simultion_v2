using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class Spinner_panel : MonoBehaviour {
    
    public GameObject Spinner_Panel_Canvas; //public static GameObject Spinner_Panel_Canvas; 1/9 946

    void Start () {
        Spinner_Panel_Canvas.SetActive(false);
    }
    
    public void click_panel() {
        if (Globals.clicked_on_spinner_pannel)
        {
            Spinner_Panel_Canvas.SetActive(false);
            Globals.clicked_on_spinner_pannel = false;
        }
        else if (!Globals.clicked_on_spinner_pannel)
        {
            Spinner_Panel_Canvas.SetActive(true);
            Globals.clicked_on_spinner_pannel = true;
        }
    }
}

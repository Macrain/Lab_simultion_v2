using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//On the lid of the spinner in the photo resist room
public class Spinner_lid : MonoBehaviour {

    static Animator anim;
    public static bool spinner_selected;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.ResetTrigger("Open");
    }

    public static void open_lid()
    //void OnMouseDown()
    {
        //if( spinner_selected == true)
        {
            if (Input.GetKeyDown("space") && (Globals.spinner_lid_open == false))
            {
                anim.Play("Spinner_Open_Lid");
                Globals.spinner_lid_open = true;
            }
            else if (Input.GetKeyDown("space") && (Globals.spinner_lid_open == true))
            {
                anim.Play("Spinner_Close_Lid");
                Globals.spinner_lid_open = false;
            }
        }
    }
}

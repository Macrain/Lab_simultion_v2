using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid_Spinner : MonoBehaviour {
    Animator lid;
    public static int lid_Clicked;
    public static bool lid_up;

    void Start () {
        lid = GetComponent<Animator>();
        lid_Clicked = 0;
        lid_up = false;
        lid.ResetTrigger("Lid_up");
        lid.ResetTrigger("Lid_down");
    }

    private void OnMouseDown()
    {
        lid_Clicked = lid_Clicked + 1;
        if (lid_Clicked == 1)
        {
            lid.SetTrigger("Lid_up");
            lid_up = true;
        }
        if (lid_Clicked == 2)
        {
            lid.SetTrigger("Lid_down");
            lid_Clicked = 0;
            lid_up = false;
        }
    }
}

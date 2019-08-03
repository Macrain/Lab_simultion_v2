using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open_close : MonoBehaviour {

    Animator anim;
    Animation open;
    Animation close;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (Globals.door_chemp_pr_open == false))
        {
            Debug.Log("clicked on door_1");
            anim.Play("open");
            Globals.door_chemp_pr_open = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (Globals.door_chemp_pr_open == true))
        {
            Debug.Log("clicked on door_2");
            anim.Play("close");
            Globals.door_chemp_pr_open = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wafer_PR_object : MonoBehaviour
{
    Vector3 vec1;
    Animator wafer;
    public static int wafer_Clicked;
    public static bool wafer_PR_applied;
    public static bool wafer_adhesive_applied;
    public static bool wafer_in_spinner;

    public Renderer rend;

    void Start()
    {
        wafer = GetComponent<Animator>();
        wafer_Clicked = 0;
        wafer_adhesive_applied = false;
        wafer_PR_applied = false;
        wafer_in_spinner = false;
        wafer.ResetTrigger("wafer_to_spinner");

        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (wafer_PR_applied)
            StartCoroutine(wafer_red());        
    }

    private void OnMouseDown()
    {
        //wafer_Clicked = wafer_Clicked + 1;
        if (Lid_Spinner.lid_up)
        {
            wafer.SetTrigger("wafer_to_spinner");
            wafer_in_spinner = true;
        }
    }

    IEnumerator wafer_red()
    {
        yield return new WaitForSeconds(2);
        rend.material.color = Color.red;
    }
}
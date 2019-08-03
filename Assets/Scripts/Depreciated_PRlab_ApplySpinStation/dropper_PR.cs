using UnityEngine;
using System.Collections;

public class dropper_PR : MonoBehaviour
{
    Animator dropper;
    public static int dropper_Clicked;

    void Start()
    {
        dropper = GetComponent<Animator>();
        dropper_Clicked = 0;
        dropper.ResetTrigger("Dropper_to_wafer");
        dropper.ResetTrigger("Dropper_to_Beaker");
    }

    private void OnMouseDown()
    {
        dropper_Clicked = dropper_Clicked + 1;
        if (dropper_Clicked == 1)
        {
            dropper.SetTrigger("Dropper_to_wafer");
            wafer_PR_object.wafer_PR_applied = true;
        }                 
        if (dropper_Clicked == 2)
        {
            dropper.SetTrigger("Dropper_to_Beaker");
            dropper_Clicked = 0;
        }
    }
}
using UnityEngine;
using System.Collections;

public class dropper_adhesive : MonoBehaviour
{
    Animator dropper;
    private static int dropper_Clicked;

    private void Start()
    {
        dropper = GetComponent<Animator>();
        dropper_Clicked = 0;
        dropper.ResetTrigger("Dropper_to_wafer");
        dropper.ResetTrigger("Dropper_to_Beaker");
    }

    public void OnMouseDown()
    {
        dropper_Clicked = dropper_Clicked + 1;
        if (dropper_Clicked == 1)
        {
            dropper.SetTrigger("Dropper_to_wafer");
            wafer_PR_object.wafer_adhesive_applied = true;
        }
        if (dropper_Clicked == 2)
        {
            dropper.SetTrigger("Dropper_to_Beaker");
            dropper_Clicked = 0;
        }
    }
}
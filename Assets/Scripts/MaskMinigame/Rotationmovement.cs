using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationmovement : MonoBehaviour {
    public GameObject emptywafer;
    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    public GameObject mask4;
    public GameObject chosen_mask;
    public GameObject wafer;
	Ray ray;
    RaycastHit hit;

    void Start()
    {
        //maskchoosing.chosen = 2;

        switch (maskchoosing.chosen)
        {
            case 1:
                mask1.SetActive(true); mask2.SetActive(false); mask3.SetActive(false); mask4.SetActive(false);
                chosen_mask = mask1;
                wafer = emptywafer;
                break;
            case 2:
                mask1.SetActive(false); mask2.SetActive(true); mask3.SetActive(false); mask4.SetActive(false);
                chosen_mask = mask2;
                wafer = mask1;
                break;
            case 3:
                mask1.SetActive(false); mask2.SetActive(false); mask3.SetActive(true); mask4.SetActive(false);
                chosen_mask = mask3;
                wafer = mask2;
                break;
            case 4:
                mask1.SetActive(false); mask2.SetActive(false); mask3.SetActive(false); mask4.SetActive(true);
                chosen_mask = mask4;
                wafer = mask3;
                break;
        }
    }


    void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // find the mouse position 
        float rotX = Input.GetAxis("Mouse X")*Mathf.Deg2Rad; // rotate depend on the mouse movement 
		float rotY = Input.GetAxis("Mouse Y")*Mathf.Deg2Rad;

		if(Input.GetMouseButton(0) && (Physics.Raycast(ray, out hit)) && (hit.collider.name == "rotationwheeltrigger"))  // if the mouse hover over the wheel and pressed 
		{
            chosen_mask.transform.Rotate(Vector3.up *- rotX*100); // rotate the object .
    	}
	}
}

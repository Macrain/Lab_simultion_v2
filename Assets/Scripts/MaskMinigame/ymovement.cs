using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ymovement : MonoBehaviour {

    public GameObject emptywafer;
    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    public GameObject mask4;

    public GameObject chosen_mask;
    public GameObject wafer;

    public Camera m_OrthographicCamera;

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
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // find the mouse position 
        
		if(Input.GetMouseButton(0) && (Physics.Raycast(ray, out hit))) // if the wheel is pressed 
		{
		    {
		        Vector3 dir = Input.mousePosition - (Vector3)transform.position;
				float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
            
                if (hit.collider.name == "ydown" )
                {
                    chosen_mask.transform.position = chosen_mask.transform.position - new Vector3(0,0.1f,0);
            	}
                if (hit.collider.name == "yup")
                {
                    chosen_mask.transform.position = chosen_mask.transform.position + new Vector3(0,0.1f,0);
            	}
            	 if (hit.collider.name == "xleft" )
                {
                    chosen_mask.transform.position = chosen_mask.transform.position - new Vector3(0.1f,0,0);
            	}
                if (hit.collider.name == "xright")
                {
                    chosen_mask.transform.position = chosen_mask.transform.position + new Vector3(0.1f,0,0);
            	}
                if(hit.collider.name == "Center")
                {
                    //m_OrthographicCamera.transform.position = new Vector3(-17, 0, -20);
                    //m_OrthographicCamera.orthographicSize = 1.50f;
                }
                if(hit.collider.name== "Edge")
                {
                    //m_OrthographicCamera.transform.position = new Vector3(-9, 0, -20);
                    //m_OrthographicCamera.orthographicSize = 1.5f;
                }
            
			}

		}		
	}
}

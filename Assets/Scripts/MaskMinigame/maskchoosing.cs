using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class maskchoosing : MonoBehaviour
{
    //public GameObject selected;
    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    public GameObject mask4;

    public static int chosen;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    public void Update()
    {
        if (Input.GetKey("b"))
            SceneManager.LoadScene("PR_lab");

        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "mask1") chosen = 1;
                else if (result.gameObject.name == "mask2") chosen = 2;
                else if (result.gameObject.name == "mask3") chosen = 3;
                else if (result.gameObject.name == "mask4") chosen = 4;                
            }
        }
        //Debug.Log(chosen);
    }
}

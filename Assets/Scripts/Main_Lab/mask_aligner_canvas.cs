using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mask_aligner_canvas : MonoBehaviour
{
    public Button button_up_field;
    public Button button_down_field;
    public Button button_left_field;
    public Button button_right_field;
    public Button button_rotate_right_field;
    public Button button_rotate_left_field;
    public Button button_go_center_field;
    public Button button_go_left_field;
    public Button button_zoom_out_field;
    public GameObject button_zoom_out_gameobj;

    Button button_up;
    Button button_down;
    Button button_left;
    Button button_right;
    Button button_rotate_right;
    Button button_rotate_left;
    Button button_go_center;
    Button button_go_left;
    Button button_zoom_out;
    public GameObject canvas;

    public GameObject emptywafer;
    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    public GameObject mask4;

    public GameObject mask1_glass;
    public GameObject mask2_glass;
    public GameObject mask3_glass;
    public GameObject mask4_glass;

    public GameObject chosen_mask;
    public GameObject wafer;

    public Camera m_OrthographicCamera;
    public bool zoom_in_flag;

    // Use this for initialization
    void Start()
    {
        zoom_in_flag = false;

        button_up = button_up_field.GetComponent<Button>();
        button_down = button_down_field.GetComponent<Button>();
        button_left = button_left_field.GetComponent<Button>();
        button_right = button_right_field.GetComponent<Button>();
        button_rotate_right = button_rotate_right_field.GetComponent<Button>();
        button_rotate_left = button_rotate_left_field.GetComponent<Button>();
        button_go_center = button_go_center_field.GetComponent<Button>();
        button_go_left = button_go_left_field.GetComponent<Button>();
        button_zoom_out = button_zoom_out_field.GetComponent<Button>();

        button_up.onClick.AddListener(button_up_TaskOnClick);
        button_down.onClick.AddListener(button_down_TaskOnClick);
        button_left.onClick.AddListener(button_left_TaskOnClick);
        button_right.onClick.AddListener(button_right_TaskOnClick);
        button_rotate_right.onClick.AddListener(button_rotate_right_TaskOnClick);
        button_rotate_left.onClick.AddListener(button_rotate_left_TaskOnClick);
        button_go_center.onClick.AddListener(button_go_center_TaskOnClick);
        button_go_left.onClick.AddListener(button_go_left_TaskOnClick);
        button_zoom_out.onClick.AddListener(button_zoom_out_TaskOnClick);


        switch (maskchoosing.chosen)
        {
            case 1:
                chosen_mask = mask1;
                wafer = emptywafer;
                break;
            case 2:
                chosen_mask = mask2;
                wafer = mask1;
                break;
            case 3:
                chosen_mask = mask3;
                wafer = mask2;
                break;
            case 4:
                chosen_mask = mask4;
                wafer = mask3;
                break;
        }

        switch (maskchoosing.chosen)
        {
            case 1:
                chosen_mask = mask1_glass;
                break;
            case 2:
                chosen_mask = mask2_glass;
                break;
            case 3:
                chosen_mask = mask3_glass;
                break;
            case 4:
                chosen_mask = mask4_glass;
                break;
        }


    }
    private void Update()
    {
        if (Globals.difficulty == 1)
        {
            button_zoom_out_gameobj.SetActive(false);
            if (zoom_in_flag == false)
            {
                m_OrthographicCamera.transform.position = new Vector3(-8, .5f, -20);
                m_OrthographicCamera.orthographicSize = 2.1f;
                zoom_in_flag = true;
            }

        }
        else if (Globals.difficulty == 0)
        {
            button_zoom_out_gameobj.SetActive(true);
            zoom_in_flag = false;
            //m_OrthographicCamera.transform.position = new Vector3(-9, 0, -20);
            //m_OrthographicCamera.orthographicSize = 18f;
        }
    }
    void button_up_TaskOnClick()
    {
        emptywafer.transform.position = emptywafer.transform.position + new Vector3(0, 0.1f, 0);
    }

    void button_down_TaskOnClick()
    {
        emptywafer.transform.position = emptywafer.transform.position - new Vector3(0, 0.1f, 0);
    }

    void button_left_TaskOnClick()
    {
        emptywafer.transform.position = emptywafer.transform.position - new Vector3(0.1f, 0, 0);
    }

    void button_right_TaskOnClick()
    {
        emptywafer.transform.position = emptywafer.transform.position + new Vector3(0.1f, 0,0);
    }

    void button_rotate_right_TaskOnClick()
    {
        float rotX = .5f;
        emptywafer.transform.Rotate(Vector3.up * -rotX); // rotate the object .

    }
    void button_rotate_left_TaskOnClick()
    {
        float rotX = .5f;
        emptywafer.transform.Rotate(Vector3.up * rotX); // rotate the object .
    }
    void button_go_center_TaskOnClick()
    {
        m_OrthographicCamera.transform.position = new Vector3(-8, .5f, -20);
        m_OrthographicCamera.orthographicSize = 2.1f;
    }
    void button_go_left_TaskOnClick()
    {                 
        m_OrthographicCamera.transform.position = new Vector3(-17f, .5f, -20);
        m_OrthographicCamera.orthographicSize = 2.1f;
    }
    void button_zoom_out_TaskOnClick()
    {
        m_OrthographicCamera.transform.position = new Vector3(-9, 0, -20);
        m_OrthographicCamera.orthographicSize = 18f;
    }

}

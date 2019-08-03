using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profilometer_canvas_script : Wafer {
    public GameObject new_parent1;
    public Button button_back_field;
    public Button button_back;
    public GameObject Profilometer_canvas;
    public GameObject Wafer_gameObj;
    public GameObject backdrop;
    public Material lineMaterial;
    public float lineWidth;
    public int count_test1;
    public int count_test_first;
    public int count_test_up;
    public int count_test_down;
    public int count_test_last;
    public static bool draw_graph_bool;

    void Start ()
    {
        Wafer_gameObj = GameObject.Find("Wafer_temp");
        button_back = button_back_field.GetComponent<Button>();
        button_back.onClick.AddListener(button_back_TaskOnClick);
        draw_graph_bool = false;
        //draw_graph();
    }

    void button_back_TaskOnClick()
    {
        Destroy(new_parent1);        
        Globals.wafer_click_profilometer = false;
        Profilometer_canvas.SetActive(false);
    }

    public void draw_graph()
    {
        
        Wafer.create_wafer_cross_section();

        //draw_graph_bool = true;

        int i;
        Vector3 lineStartPoint = new Vector3(0f, 0f, 0f);
        Vector3 lineEndPoint = new Vector3(0f, 0f, 0f);

        float x_coor_1 = -2f;
        float y_coor_1 = 1f;
        float z_coor = -4f;
        float length_line = .2f;
        count_test1 = 0;

        Vector3 Player_pos = GameObject.Find("Player").transform.position;

        GameObject new_parent = new GameObject("Canvas");
        new_parent1 = new GameObject("Profile_Graph");
        
        for (i = 0; i < 12; i++) 
        {
            lineStartPoint = new Vector3(x_coor_1, y_coor_1, z_coor);
            lineEndPoint = new Vector3(x_coor_1 + length_line, y_coor_1, z_coor);
            lineStartPoint = lineStartPoint + Player_pos;
            lineEndPoint = lineEndPoint + Player_pos;
            x_coor_1 = length_line + x_coor_1;
            count_test_first++;
            //Debug.Log("first lines: " + count_test_first);
            create_line(lineStartPoint, lineEndPoint);

            if (Wafer.wafer_cross_section[i] > Wafer.wafer_cross_section[i + 1])
            {
                lineStartPoint = new Vector3(x_coor_1, y_coor_1, -4f);
                lineEndPoint = new Vector3(x_coor_1, y_coor_1- length_line, -4f);
                lineStartPoint = lineStartPoint + Player_pos;
                lineEndPoint = lineEndPoint + Player_pos;
                y_coor_1 =  y_coor_1 - length_line;
                count_test_up++;
                //Debug.Log("up lines :" + count_test_up);
                create_line(lineStartPoint, lineEndPoint);
            }
            if (Wafer.wafer_cross_section[i] < Wafer.wafer_cross_section[i + 1])
            {
                lineStartPoint = new Vector3(x_coor_1, y_coor_1, -4f);
                lineEndPoint = new Vector3(x_coor_1, y_coor_1 + length_line, -4f);
                lineStartPoint = lineStartPoint + Player_pos;
                lineEndPoint = lineEndPoint + Player_pos;
                y_coor_1 = y_coor_1+ length_line;
                count_test_down++;
                //Debug.Log("down lines :" + count_test_down);
                create_line(lineStartPoint, lineEndPoint);
            }

            lineStartPoint = new Vector3(x_coor_1, y_coor_1, z_coor);
            lineEndPoint = new Vector3(x_coor_1 + length_line, y_coor_1, z_coor);
            lineStartPoint = lineStartPoint + Player_pos;
            lineEndPoint = lineEndPoint + Player_pos;
            x_coor_1 = length_line + x_coor_1;
            count_test_last++;
            //Debug.Log("last lines: " + count_test_last);
            create_line(lineStartPoint, lineEndPoint);

        }
    }

    void create_line(Vector3 lineStartPoint, Vector3 lineEndPoint)
    {
        GameObject gameObject = new GameObject("line");
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.SetPositions(new Vector3[] { lineStartPoint, lineEndPoint });

        gameObject.transform.parent = new_parent1.transform;
        count_test1++;
        //Debug.Log("all lines" + count_test1);
    }
}

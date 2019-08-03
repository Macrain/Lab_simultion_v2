// not used

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette_Adhesive : MonoBehaviour {
    float distance = 3;
    public Camera fps;
    public Vector3 original_position;

    private void Start()
    {
        original_position.Set(4, 4, 7);
    }

    /*void OnMouseUp()
    {
        transform.position = original_position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = fps.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }*/

    public static void move_pipette_adhesive()
    {
        
    }
}

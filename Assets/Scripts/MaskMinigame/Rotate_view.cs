using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_view : MonoBehaviour {
    public KeyCode pressLeft;
    public KeyCode pressRight;
    Transform camera_fps;
    int z_coordinate;
    public Camera Cam;
    // Use this for initialization
    void Start () {
        z_coordinate = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(pressLeft))
            z_coordinate = 1;
        else if (Input.GetKeyDown(pressRight))
            z_coordinate = -1;
        else if (!Input.GetKeyDown(pressRight) && !Input.GetKeyDown(pressLeft))
            z_coordinate = 0;

        //transform.rotation = Quaternion.Euler(0, z_coordinate, 0);
        //Quaternion rotation = Quaternion.Euler(0, z_coordinate, 0);
        //transform.rotation = rotation;
        //Camera.transform.rotation = CameraRotation;
        transform.RotateAround(Vector3.zero, Vector3.up, z_coordinate * 2000 * Time.deltaTime);
        Cam.transform.RotateAround(Vector3.zero, Vector3.up, z_coordinate * 2000 * Time.deltaTime);
        //transform.localRotation = rotation;
        //m_MouseLook.LookRotation(transform, m_Camera.transform);
    }
}

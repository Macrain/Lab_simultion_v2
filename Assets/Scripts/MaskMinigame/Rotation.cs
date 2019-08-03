using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardLook : MonoBehaviour
{

    public bool SmoothLook = true;
    public float SmoothTime = 5f;
    public GameObject Camera;               //Drag Camera in the inspector.  Ideally is would be a child of the character gameobject

    private Quaternion _CharacterRotation;
    private Quaternion _CameraRotation;

    public void Start()
    {
        _CharacterRotation = transform.localRotation;
        _CameraRotation = Camera.transform.localRotation;
    }
    public void Update()
    {
        float yRotation = 0;
        float xRotation = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            xRotation = -1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            xRotation = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            yRotation = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            yRotation = -1;
        }

        _CharacterRotation *= Quaternion.Euler(0f, yRotation, 0f);
        _CameraRotation *= Quaternion.Euler(xRotation, 0f, 0f);

        if (SmoothLook)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _CharacterRotation, SmoothTime * Time.deltaTime);
            Camera.transform.localRotation = Quaternion.Slerp(Camera.transform.localRotation, _CameraRotation, SmoothTime * Time.deltaTime);
        }
        else
        {
            transform.localRotation = _CharacterRotation;
            Camera.transform.localRotation = _CameraRotation;
        }
    }
}

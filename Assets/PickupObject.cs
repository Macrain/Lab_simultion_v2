// Depreciated

using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour
{
    // I think i can delete this because it picks objects up using the mouse but check other scenes to be sure.
    /*GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    //public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            Carry(carriedObject);
            checkDrop();
            //RotateObject();
        }
        else
        {
            Pickup();
        }
    }

    void RotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void Carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void Pickup()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupables p = hit.collider.GetComponent<Pickupables>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.rigidbody.isKinematic = true;
                    //rb.isKinematic = true;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }*/
}


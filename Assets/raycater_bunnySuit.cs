using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycater_bunnySuit : MonoBehaviour
{
    // Use this for initialization
    public float targetDistance;
    public GameObject Player;
    public static GameObject currObject; //public static GameObject currObject; 1/9 935

    // Update is called once per frame
    void Update()
    {
        RaycastHit TheHit;

        //Send out raycast from object we are attached to, output (distance, and object we are looking at )it to TheHit
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out TheHit))
        {
            targetDistance = TheHit.distance;
            currObject = TheHit.transform.gameObject;
        }
    }
}

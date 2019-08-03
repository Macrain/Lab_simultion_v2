using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class Sonicator : MonoBehaviour
{
    public GameObject Sonicator_obj;

    void Start()
    {
        Sonicator_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_Sonicator)
        {
            Sonicator_obj.SetActive(true);
        }
        else if (!Globals.wafer_hit_Sonicator)
        {
            Sonicator_obj.SetActive(false);
        }

    }
}

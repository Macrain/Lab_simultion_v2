using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class Developer_water : MonoBehaviour
{
    public GameObject Developer_water_obj;

    void Start()
    {
        Developer_water_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_Developer_water)
        {
            Developer_water_obj.SetActive(true);
        }
        else if (!Globals.wafer_hit_Developer_water)
        {
            Developer_water_obj.SetActive(false);
        }

    }
}

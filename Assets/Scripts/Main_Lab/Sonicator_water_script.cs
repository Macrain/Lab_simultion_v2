using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class Sonicator_water_script : MonoBehaviour
{
    public GameObject Sonicator_water_canvas;

    void Start()
    {
        Sonicator_water_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_sonicator_water)
        {
            Sonicator_water_canvas.SetActive(true);
        }
        else if (!Globals.wafer_hit_sonicator_water)
        {
            Sonicator_water_canvas.SetActive(false);
        }

    }
}


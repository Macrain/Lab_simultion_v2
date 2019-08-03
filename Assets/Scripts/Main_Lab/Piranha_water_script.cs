using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On the pannel of the spinner in the photo resist roomf
public class Piranha_water_script : MonoBehaviour
{
    public GameObject Piranha_water_canvas;

    void Start()
    {
        Piranha_water_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.wafer_hit_piranha_water)
        {
            Piranha_water_canvas.SetActive(true);
        }
        else if (!Globals.wafer_hit_piranha_water)
        {
            Piranha_water_canvas.SetActive(false);
        }

    }
}

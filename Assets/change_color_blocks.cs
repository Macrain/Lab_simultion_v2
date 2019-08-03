using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color_blocks : MonoBehaviour
{

    public Material photoresist;

    void Start()
    {
        change_color();
    }

    public void change_color()
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                 mats[j] = photoresist;
            }
            rend.materials = mats;
        }
    }
}

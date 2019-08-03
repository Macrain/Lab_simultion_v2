using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color_mask : MonoBehaviour {

    public Material material_hard;
    public Material material_easy;

	void Start () {
        change_color();
	}
	
    public void change_color()
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer> ();

        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for(var j = 0; j<rend.materials.Length; j++)
            {
                //if (Globals.difficulty == 0)
                    mats[j] = material_easy;
                //else
                //    mats[j] = material_hard;
            }
            rend.materials = mats;
        }
    }
}

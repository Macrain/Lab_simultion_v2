using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomin1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Camera>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (ZoominPannel.controlPannel_Clicked ==  1)
            GetComponent<Camera> ().enabled = true;

    }
}

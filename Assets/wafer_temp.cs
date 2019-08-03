using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wafer_temp : MonoBehaviour {

    GameObject Wafer_gameObj;

	void Awake () {
        Wafer_gameObj = GameObject.Find("Wafer");
        DontDestroyOnLoad(this);

        if (Globals.wafer_loaded == true)
        {
            //Destroy(Wafer_gameObj.gameObject);
            Debug.Log("hello");
        }
            
        Globals.wafer_loaded = true;

        //Debug.Log(Globals.wafer_loaded);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTextCollider : MonoBehaviour {

	public bool triggerCollider = false;
	// Use this for initialization
	void Start () {
		triggerCollider = false;
	}

	void Awake(){
		triggerCollider = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() 
	{
		triggerCollider = true;
	}


	void OnTriggerExit() 
	{
		triggerCollider = false;
	}
}

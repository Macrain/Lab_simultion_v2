using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

	// Use this for initialization
	public float fallMultiplier = 2f;
	public GameObject character;


	// Update is called once per frame
	void Update () {
		if(FPController.verticalVelocity < 0){
			FPController.verticalVelocity += FPController.gravity * (fallMultiplier - 1) * Time.deltaTime;
		}
	}
}

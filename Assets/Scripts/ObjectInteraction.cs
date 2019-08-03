using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

	// Use this for initialization

	public GameObject item; //the cube itself
	public GameObject tempParent;
	public Transform guide;
	public GameObject target;
	private Vector3 playerpos;
	float pickupdist = 3f;
    public bool isPickupable;
    bool interactedWith;
	bool pickup = false;
    // for now,  the input values is hardwired as F
	public string Interact = "f";

	void Start () {
        pickup = false;
        item.GetComponent<Rigidbody> ().useGravity = true;
		tempParent = GameObject.Find ("Guide");
		guide = GameObject.Find ("Guide").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		target = raycater_bunnySuit.currObject; //access public variable from Raycaster Script
		playerpos = GameObject.Find("Player").transform.position;
		float dist = Vector3.Distance (item.transform.position, playerpos);

        //
        if ((Input.GetButtonDown("Interact") || Input.GetKeyDown(Interact)) && dist <= pickupdist) {
            interactedWith = true;
        }

        // if the object is set to be able to be picked up but not deactivated by the player
        if (isPickupable) {
            if (!pickup && Input.GetKeyDown(Interact) && target == item && dist <= pickupdist) {
                pickup = true;
            }

            else if (pickup && Input.GetKeyDown(Interact)) {
                pickup = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null; //remove parent
                item.transform.position = guide.transform.position;
                pickup = false;
            }

            if (pickup) {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.transform.position;
                item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;
            }
        }
	}
		
}
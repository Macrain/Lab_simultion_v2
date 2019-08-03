using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPController : MonoBehaviour {
	public GameObject eyes; //this links to the camera to control up/down rotation
	public float speed = 3f;
	public float sensitivity = 2f;
	public float pushPower = 2f;

    public GameObject FPController_game_obj;

    CharacterController player; //should this be private?
	float moveFB;
	float moveLR;
    float rotationX;
	float rotationY;
	public static float verticalVelocity;
	public static float gravity = 10f;

	// Use this for initialization
	void Start () {
		player = GetComponent <CharacterController> (); 
	}

	void Update () {
        if (!UITextManager.finished_mini_game_suit_up && !Globals.wafer_hit_BHF && !Globals.clicked_evap && !Globals.clicked_lab_manual && !Globals.warning_canvas && 
            !Globals.control_text_activate && !Globals.wafer_click_profilometer && !Globals.wafer_furnace && 
            !Globals.wafer_click_microscope && !Globals.wafer_hit_Al_Etchant && !Globals.wafer_hit_BOE && 
            !Globals.wafer_hit_Developer && !Globals.wafer_hit_Developer_water && !Globals.clicked_on_hot_plate_panel && 
            !Globals.clicked_on_spinner_pannel && !Globals.wafer_hit_piranha && !Globals.wafer_hit_piranha_water && 
            !Globals.wafer_hit_acetone && !Globals.wafer_hit_propanol && !Globals.wafer_hit_sonicator_water && !Globals.levels_canvas_activate)
        {
            moveFB = Input.GetAxis("Vertical") * speed;
            moveLR = Input.GetAxis("Horizontal") * speed;
            rotationX = Input.GetAxis("Mouse X") * sensitivity;
            rotationY = Input.GetAxis("Mouse Y") * sensitivity;

            //float bu = eyes.rotation.eulerAngles.x;
            //Debug.Log(rotationY);

            verticalVelocity -= gravity * Time.deltaTime;

            Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
            transform.Rotate(0, rotationX, 0);
            movement = transform.rotation * movement;
            player.Move(movement * Time.deltaTime); //technically player is just whatever this script attached to

            //Debug.Log(rotationY);
            eyes.transform.Rotate(-rotationY, 0, 0); //control camera look up and down
            //eyes.transform.Rotate(Mathf.Clamp(-rotationY, -1, 1), 0, 0);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        string object_player_touching = collision.collider.tag;

        //if (object_player_touching == "Doors") { SceneManager.LoadScene("PR_lab"); }
        //if (object_player_touching == "Mask_aligner") { SceneManager.LoadScene("Maskminigame"); }
    }
/*
    void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic)
			return;

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f)
			return;

		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.

		// Apply the push
		body.velocity = pushDir * pushPower;
	}
    */
}

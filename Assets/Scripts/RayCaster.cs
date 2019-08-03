using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCaster : MonoBehaviour {

	// Use this for initialization
	public float targetDistance;
    public GameObject Player;
    public static GameObject currObject;

    GameObject Wafer_gameObj;
    public GameObject Wafer_og_gameObj;
    Wafer Wafer_script;

    public GameObject pipette_adhesive_gameObj;
    Pipette_Adhesive pipette_adhesive_script;

    public GameObject pipette_photoresist_gameObj;
    pipette_photo_resist pipette_photoresist_script;

    public GameObject Spinner_Panel_gameObj;
    Spinner_panel spinner_panel_script;
    
    public GameObject Hot_plate_gameObj;
    hot_plate_script Hot_plate_script;

    public GameObject Microscope_gameObj;
    Microscope_script Microscope_script;

    public GameObject profilometer_gameObj;
    profilometer_canvas_script profilometer_canvas_script;

    public GameObject Furnace_gameObj;
    furnace_script Furnace_script;

    public GameObject lab_manual;

    public GameObject evap_canvas;

    int distance = 15;

    public Text hover_text;
    public static string str;

    public Text hover_text_wafer;
    public string str_wafer;

    private void Start()
    {
        UITextManager.finished_mini_game_suit_up = false;

        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_og_gameObj = GameObject.Find("Wafer");

        Wafer_script = Wafer_gameObj.GetComponent<Wafer>();
        pipette_adhesive_script = pipette_adhesive_gameObj.GetComponent<Pipette_Adhesive>();
        pipette_photoresist_script = pipette_photoresist_gameObj.GetComponent<pipette_photo_resist>();
        spinner_panel_script = Spinner_Panel_gameObj.GetComponent<Spinner_panel>();
        Hot_plate_script = Hot_plate_gameObj.GetComponent<hot_plate_script>();
        Microscope_script = Microscope_gameObj.GetComponent<Microscope_script>();
        profilometer_canvas_script = profilometer_gameObj.GetComponent<profilometer_canvas_script>();
        Furnace_script = Furnace_gameObj.GetComponent<furnace_script>();

        str_wafer = "Press f to pick up the wafer.";
        hover_text_wafer.text = str_wafer;
    }

    // Update is called once per frame
    void Update () {
		RaycastHit TheHit;

        //Send out raycast from object we are attached to, output (distance, and object we are looking at )it to TheHit
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out TheHit)) {
            targetDistance = TheHit.distance;
			currObject = TheHit.transform.gameObject;
            select_obj(currObject);
        }

        if (currObject.name != "Wafer_temp" && Input.GetKeyDown("f") && Globals.pick_up_wafer == true && !Globals.wafer_click_microscope)
        {
            Wafer_og_gameObj.transform.parent = null;
            //Wafer_gameObj.transform.parent = null;
            Wafer_gameObj.transform.parent = Wafer_og_gameObj.transform;
            Wafer_gameObj.GetComponent<Rigidbody>().useGravity = true;
            Wafer_gameObj.GetComponent<BoxCollider>().enabled = true;
            Globals.pick_up_wafer = false;

            str_wafer = "Press f to pick up the wafer";
        }
        else if ( Input.GetKeyDown("f") && Globals.pick_up_wafer == false && !Globals.wafer_click_microscope)
        {
            Wafer_gameObj.transform.parent = Player.transform;
            Wafer_gameObj.transform.localPosition = new Vector3(0, 1, 3);
            Wafer_gameObj.transform.rotation = Quaternion.Euler(0, 0, 0);
            Wafer_gameObj.GetComponent<Rigidbody>().useGravity = false;
            Wafer_gameObj.GetComponent<Rigidbody>().isKinematic = false;
            Wafer_gameObj.GetComponent<BoxCollider>().enabled = false;
            Globals.pick_up_wafer = true;

            str_wafer = "Press f to drop the wafer";
        }

        hover_text_wafer.text = str_wafer;
        hover_text.text = str;
    }

    private void select_obj(GameObject currObject)
    {            
        // Pipette photoresist
        if (currObject.name == "Pipette_Photo_Resist" && (targetDistance <= distance))
        {
            
            if ( (State_machine.master_step_count == 5) || (State_machine.master_step_count == 16) || 
                (State_machine.master_step_count == 25) || (State_machine.master_step_count == 34))
            {
                if (State_machine.spin_photoresist_step_count == 1)
                    str = "Press the space bar to put photoresist onto the wafer";
            }

            if (Input.GetKeyDown("space"))
            {
                ////Debug.Log(currObject);
                Globals.wafer_photo_resist = true;
                pipette_photo_resist.move_pippette_photo_resist();
                //Wafer_script.Create_virtual_layer_on_wafer(1); // 1 = photoresist
                //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer - 1);
            }
        }

        //Pipette adhesive
        if (currObject.name == "Pipette_Adhesive" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 4) || (State_machine.master_step_count == 15) ||
                (State_machine.master_step_count == 24) || (State_machine.master_step_count == 33))
            {
                if (State_machine.spin_adhesive_step_count == 1)
                    str = "Press the space bar to put adhesive onto the wafer";
            }

            if (Input.GetKeyDown("space"))
            {
                ////Debug.Log(currObject);
                Globals.wafer_adhesive = true;
                Pipette_Adhesive.move_pipette_adhesive();
                //Wafer_script.Create_virtual_layer_on_wafer(2);
            }
        }

        //Pippette dopant
        if (currObject.name == "Pipette_Dopant" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 13))
            {
                if (State_machine.spin_on_dopant_step_count == 2)
                    str = "Press the space bar to put dopant onto the wafer";
            }

            if (Input.GetKeyDown("space"))
            {
                ////Debug.Log(currObject);
                Globals.wafer_dopant = true;
                //Pipette_Adhesive.move_pipette_adhesive();
                //Wafer_script.Create_virtual_layer_on_wafer(2);
                //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer - 1);
            }
        }

        // Spinner
        if (currObject.name == "Spinner_Lid" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 5) || (State_machine.master_step_count == 16) ||
                (State_machine.master_step_count == 25) || (State_machine.master_step_count == 34) ||
                (State_machine.master_step_count == 4) || (State_machine.master_step_count == 15) ||
                (State_machine.master_step_count == 24) || (State_machine.master_step_count == 33) ||
                (State_machine.master_step_count == 13))
            {
                if ((State_machine.spin_adhesive_step_count == 4) || (State_machine.spin_photoresist_step_count == 4) ||
                    (State_machine.spin_on_dopant_step_count == 4) || (State_machine.spin_adhesive_step_count == 3) || 
                    (State_machine.spin_photoresist_step_count == 3) || (State_machine.spin_on_dopant_step_count == 3))
                    str = "Press the space bar to open and close the lid of the spinner";
            }

            if (Input.GetKeyDown("space"))
            {
                //Debug.Log(currObject);
                //Spinner_lid.spinner_selected = true;
                Spinner_lid.open_lid();
            }
        }
        
        //else Spinner_lid.spinner_selected = false;
        if (currObject.name == "Spinner_Panel" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 5) || (State_machine.master_step_count == 16) ||
                (State_machine.master_step_count == 25) || (State_machine.master_step_count == 34) ||
                (State_machine.master_step_count == 4) || (State_machine.master_step_count == 15) ||
                (State_machine.master_step_count == 24) || (State_machine.master_step_count == 33) ||
                (State_machine.master_step_count == 13))
            {
                if ((State_machine.spin_adhesive_step_count == 5) || (State_machine.spin_photoresist_step_count == 5) ||
                    (State_machine.spin_on_dopant_step_count == 5))
                    str = "Press the space bar to open the spinner panel";
            }

            if (Input.GetKeyDown("space"))
            {
                str = "";
                //hover_text_wafer.enabled = false;
                //Debug.Log(currObject);
                spinner_panel_script.click_panel();
            }
        }

        // Hot plate
        if (currObject.name == "Hot_plate_panel" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 6) || (State_machine.master_step_count == 17) ||
                (State_machine.master_step_count == 26) || (State_machine.master_step_count == 35) ||
                (State_machine.master_step_count == 12) || (State_machine.master_step_count == 14) ||
                (State_machine.master_step_count == 23) || (State_machine.master_step_count == 32) ||
                (State_machine.master_step_count == 13))
            {
                if ((State_machine.soft_bake_step_count == 2) || (State_machine.dehydration_bake_step_count == 2) ||
                    (State_machine.spin_on_dopant_step_count == 9))
                    str = "Press the space bar to open the hot plate panel";
            }

            if (Input.GetKeyDown("space"))
            {
                str = "";
                //hover_text_wafer.enabled = false;
                ////Debug.Log(currObject);
                Hot_plate_script.click_panel_hot_plate();
            }
        }

        //Furnace
        if (currObject.name == "Furnace" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 1) || (State_machine.master_step_count == 13) ||
                (State_machine.master_step_count == 22))
            {
                if ((State_machine.field_oxidizer_step_count == 1) || (State_machine.spin_on_dopant_step_count == 11) ||
                    (State_machine.spin_on_dopant_step_count == 21) || (State_machine.spin_on_dopant_step_count == 23) ||
                    (State_machine.spin_on_dopant_step_count == 25) || (State_machine.gate_oxidation_step_count == 1) ||
                    (State_machine.gate_oxidation_step_count == 3) || (State_machine.gate_oxidation_step_count == 5))
                    str = "Press the space bar to activate the furnace";
            }
                

            if (Input.GetKeyDown("space"))
            {
                //str = "";
                //str_wafer = "";
                //hover_text_wafer.enabled = false;
                Furnace_script.click_panel();                
            }
                
            ////Debug.Log(currObject);
        }

        //Mask Aligner
        if (currObject.name == "MaskAligner" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 7) || (State_machine.master_step_count == 18) ||
                (State_machine.master_step_count == 27) || (State_machine.master_step_count == 36) )
            {
                if ((State_machine.expose_mask_1_step_count == 1) || (State_machine.expose_mask_2_step_count == 1) ||
                    (State_machine.expose_mask_3_step_count == 1) || (State_machine.expose_mask_4_step_count == 1) )
                    str = "Press the space bar to activate the mask aligner";
            }
            
            if (Input.GetKeyDown("space")  && ((State_machine.master_step_count == 7) || (State_machine.master_step_count == 18) ||
                (State_machine.master_step_count == 27) || (State_machine.master_step_count == 36)) )
            {
                str = "";
                //hover_text_wafer.enabled = false;

                Globals.clicked_mask_aligner = true;

                Wafer_og_gameObj.transform.parent = null;
                //Wafer_gameObj.transform.parent = null;
                Wafer_gameObj.transform.parent = Wafer_og_gameObj.transform;
                Wafer_gameObj.GetComponent<Rigidbody>().useGravity = true;
                Wafer_gameObj.GetComponent<BoxCollider>().enabled = true;
                Globals.pick_up_wafer = false;

                ////Debug.Log(currObject);
                SceneManager.LoadScene("Maskchoose");
            }
        }

        // Evaporator
        if (currObject.name == "Evaporator" && (targetDistance <= distance))
        {
            if ((State_machine.master_step_count == 31))
            {
                if ((State_machine.al_evaporation_step_count == 1 ))
                    str = "Press the space bar to activate the evaporator";
            }
                
            if (Input.GetKeyDown("space"))
            {
                str = "";
                //hover_text_wafer.enabled = false;

                Globals.clicked_evap = true;
                evap_canvas.SetActive(true);
            }
        }

        // Microscope
        if (currObject.name == "Microscope" && (targetDistance <= distance))
        {
            str = "Press the space bar to activate the microscope";
            if (Input.GetKeyDown("space"))
            {
                str = "";
               // hover_text_wafer.enabled = false;
                ////Debug.Log(currObject);
                Globals.wafer_click_microscope = true;
                Microscope_script.select_microscope();
            }
        }

        //Profilometer
        if (currObject.name == "Profilometer" && (targetDistance <= distance))
        {
            str = "Press the space bar to activate the profilometer";
            if (Input.GetKeyDown("space"))
            {
                str = "";
                Globals.wafer_click_profilometer = true;
                profilometer_canvas_script.draw_graph();
                //profilometer_script.select_profilometer();
            }
        }

        // Lab manual
        if (currObject.name == "lab_manual" && (targetDistance <= distance))
        {
            str = "Press the space bar to open the lab manual";
            if (Input.GetKeyDown("space"))
            {
                str = "";
                hover_text_wafer.enabled = false;
                Globals.clicked_lab_manual = true;
                lab_manual.SetActive(true);
            }
        }

        if ((currObject.name != "Evaporator") && (currObject.name != "lab_manual") && (currObject.name != "MaskAligner") &&
            (currObject.name != "Furnace") && (currObject.name != "Profilometer") && (currObject.name != "Microscope") &&
            (currObject.name != "Hot_plate_panel") && (currObject.name != "Spinner_Panel") && (currObject.name != "Spinner_Lid") &&
            (currObject.name != "Pipette_Dopant") && (currObject.name != "Pipette_Photo_Resist") && (currObject.name != "Pipette_Adhesive"))
        {
            str = "";
        }

        if (UITextManager.finished_mini_game_suit_up || Globals.wafer_hit_BHF || Globals.clicked_evap ||
            Globals.clicked_lab_manual || Globals.warning_canvas ||
            Globals.control_text_activate || Globals.wafer_click_profilometer || Globals.wafer_furnace ||
            Globals.wafer_click_microscope || Globals.wafer_hit_Al_Etchant || Globals.wafer_hit_BOE ||
            Globals.wafer_hit_Developer || Globals.wafer_hit_Developer_water || Globals.clicked_on_hot_plate_panel ||
            Globals.clicked_on_spinner_pannel || Globals.wafer_hit_piranha || Globals.wafer_hit_piranha_water ||
            Globals.wafer_hit_acetone || Globals.wafer_hit_propanol || Globals.wafer_hit_sonicator_water)
        {
            str = "";
            str_wafer = "";
        }
        else if (Globals.pick_up_wafer == true)
            str_wafer = "Press f to drop the wafer"; 
        else
            str_wafer = "Press f to pick up the wafer";

    }
}
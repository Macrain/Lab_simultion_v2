using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initilize_to_zero_script : MonoBehaviour
{
    public GameObject button_next_scene;
    // Use this for initialization

    public static void initialize_to_zero()
    {
        //button_next_scene.SetActive(false);
        Globals.levels_canvas_activate = false;
        Globals.pick_up_wafer = false;
        Globals.wafer_hit_piranha_water = false;
        Globals.wafer_hit_piranha = false;
        Globals.wafer_hit_acetone = false;
        Globals.wafer_hit_propanol = false;
        Globals.wafer_hit_sonicator_water = false;
        Globals.wafer_spinner_lid = false;
        Globals.wafer_spinner_inside = false;
        Globals.clicked_on_spinner_pannel = false;
        Globals.spinner_lid_open = false;
        Globals.wafer_photo_resist = false;
        Globals.wafer_adhesive = false;
        Globals.wafer_hit_hot_plate = false;
        Globals.clicked_on_hot_plate_panel = false;
        Globals.wafer_hit_Developer_water = false;
        Globals.wafer_hit_Developer = false;
        Globals.wafer_hit_BOE = false;
        Globals.wafer_hit_Al_Etchant = false;
        Globals.door_chemp_pr_open = false;
        Globals.wafer_hit_microscope = false;
        Globals.wafer_click_microscope = false;
        Globals.wafer_dopant = false;
        Globals.wafer_furnace = false;
        Globals.clicked_mask_aligner = false;
        Globals.last_mask = 0;
        Globals.wafer_click_profilometer = false;
        Globals.control_text_activate = false;
        Globals.mask_aligned = false;
        Globals.warning_canvas = false;
        Globals.clicked_lab_manual = false;
        Globals.wafer_loaded = false;
        Globals.mask_mini_game = false;
        Globals.wafer_hit_BHF = false;
        Globals.suit_up_mini_game = false;


        State_machine.master_step_count = 2;// testing...
        State_machine.field_oxidizer_step_count = 1;
        State_machine.piranha_clean_step_count = 1;
        State_machine.strip_photoresist_step_count = 1;
        State_machine.spin_adhesive_step_count = 1;
        State_machine.spin_photoresist_step_count = 1;
        State_machine.soft_bake_step_count = 1;
        State_machine.expose_mask_1_step_count = 1;
        State_machine.expose_mask_2_step_count = 1;
        State_machine.expose_mask_3_step_count = 1;
        State_machine.expose_mask_4_step_count = 1;
        State_machine.develop_photoresist_step_count = 1;
        State_machine.oxide_etch_step_count = 1;
        State_machine.dehydration_bake_step_count = 1;
        State_machine.gate_oxidation_step_count = 1;
        State_machine.al_evaporation_step_count = 1;
        State_machine.al_etch_step_count = 1;
        State_machine.spin_on_dopant_step_count = 1;
        State_machine.evap_step_count = 1;
    }

}

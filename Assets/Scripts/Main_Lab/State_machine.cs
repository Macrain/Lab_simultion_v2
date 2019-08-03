using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class State_machine : MonoBehaviour {

    public static int master_step_count;
    public static int field_oxidizer_step_count;
    public static int piranha_clean_step_count;
    public static int strip_photoresist_step_count;
    public static int spin_adhesive_step_count;
    public static int spin_photoresist_step_count;
    public static int soft_bake_step_count;
    public static int expose_mask_1_step_count;
    public static int expose_mask_2_step_count;
    public static int expose_mask_3_step_count;
    public static int expose_mask_4_step_count;
    public static int develop_photoresist_step_count;
    public static int oxide_etch_step_count;
    public static int dehydration_bake_step_count;
    public static int gate_oxidation_step_count;
    public static int al_evaporation_step_count;
    public static int al_etch_step_count;
    public static int spin_on_dopant_step_count;
    public static int evap_step_count;

    public GameObject Wafer_gameObj;
    Wafer Wafer_script;

    public GameObject furnace_canvas;

    public GameObject finsihed_game_Canvas;
    
    public GameObject Player;

    private void Start()
    {
        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_script = Wafer_gameObj.GetComponent<Wafer>();

        expose_mask_1_step_count = 1;
        expose_mask_2_step_count = 1;
        expose_mask_3_step_count = 1;
        expose_mask_4_step_count = 1;
}

    void Update() {
        
        master_state_machine();
    }

    void master_state_machine()
    {
        if (Globals.debug == true && Input.GetKeyDown("g"))
            master_step_count++;
        if (Globals.debug == true && Input.GetKeyDown("t"))
            spin_on_dopant_step_count++;
        //Debug.Log(master_step_count);
        switch (master_step_count)
        {
            case 1:
                { field_oxidizer(); break; }
            case 2:
                { pirahna_clean(); break; }
            case 3:
                { strip_photoresist(); break; }
            case 4:
                { spin_adhesive(); break; }
            case 5:
                { spin_photoresist(); break; }
            case 6:
                { soft_bake(); break; }
            /*case 7:
                { expose_mask_1(); break; }*/
            case 8:
                { develop_photoresist(); break; }
            case 9:
                { oxide_etch(); break; }
            case 10:
                { strip_photoresist(); break; }
            case 11:
                { pirahna_clean(); break; }
            case 12:
                { dehydration_bake(); break; }
            case 13:
                { spin_on_dopant(); break; }
            case 14:
                { dehydration_bake(); break; }
            case 15: 
                { spin_adhesive(); break; }
            case 16:
                { spin_photoresist(); break; }
            case 17:
                { soft_bake(); break; }
            /*case 18:
                { expose_mask_2(); break; }*/
            case 19:
                { develop_photoresist(); break; }
            case 20:
                { oxide_etch(); break; }
            case 21:
                { strip_photoresist(); break; }
            case 22:
                { gate_oxidation(); break; }
            case 23:
                { dehydration_bake(); break; }
            case 24:
                { spin_adhesive(); break; }
            case 25:
                { spin_photoresist(); break; }
            case 26:
                { soft_bake(); break; }
            /*case 27:
                { expose_mask_3(); break; }*/
            case 28:
                { develop_photoresist(); break; }
            case 29:
                { oxide_etch(); break; }
            case 30:
                { strip_photoresist(); break; }
            case 31:
                { al_evaporation(); break; }
            case 32:
                { dehydration_bake(); break; }
            case 33:
                { spin_adhesive(); break; }
            case 34:
                { spin_photoresist(); break; }
            case 35:
                { soft_bake(); break; }
            /*case 36:
                { expose_mask_4(); break; }*/
            case 37:
                { develop_photoresist(); break; }
            case 38:
                { al_etch(); break; }
            case 39:
                { strip_photoresist(); break; }
        }
    }
    void field_oxidizer()
    {
        if (field_oxidizer_step_count == 1)
        {
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_2_name = 0;
            Globals.Temperature_value = 0;
        }


        if (field_oxidizer_step_count == 1 && Globals.wafer_furnace == true)
            field_oxidizer_step_count = 2;
        if (field_oxidizer_step_count == 2 && 
            ((Globals.Gas_1_flow_rate_value == 6 && Globals.Gas_1_name == 4) && 
            (Globals.Gas_2_flow_rate_value == 3 && Globals.Gas_2_name == 1)) && 
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
            (Globals.Time_furnace_value >= 75 && Globals.Time_furnace_value <= 100))
            field_oxidizer_step_count = 3;

        //Debug.Log(field_oxidizer_step_count);

        if (field_oxidizer_step_count == 3)
        {
            master_step_count = 3;
            field_oxidizer_step_count = 1;

            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_2_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;

            Wafer_script.Create_virtual_layer_on_wafer(8);
            Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
            //Debug.Log("Finished");
        }
    }
    void pirahna_clean()
    {
        if(piranha_clean_step_count == 1)
        {
            Globals.piranha_time_value = 0;
            Globals.piranha_water_time_value = 0;
        }

        if (piranha_clean_step_count == 1 && Globals.wafer_hit_piranha == true)
            piranha_clean_step_count = 2;
        if (piranha_clean_step_count == 2 && Globals.piranha_time_value == 10)
            piranha_clean_step_count = 3;
        if (piranha_clean_step_count == 3 && Globals.wafer_hit_piranha_water == true)
            piranha_clean_step_count = 4;
        if (piranha_clean_step_count == 4 && Globals.piranha_water_time_value == 1)
            piranha_clean_step_count = 5;

        ////Debug.Log(piranha_clean_step_count);

        if (piranha_clean_step_count == 5)
        {
            if (master_step_count == 2)
                master_step_count = 1;
            if (master_step_count == 11)
                master_step_count = 12;

            piranha_clean_step_count = 1;

            Globals.wafer_hit_piranha = false;
            Globals.wafer_hit_piranha_water = false;
            Globals.piranha_time_value = 0;
            Globals.piranha_water_time_value = 0;

            ////Debug.Log("Finished");
        }
    }
    void strip_photoresist()
    {
        if(strip_photoresist_step_count == 1)
        {
            Globals.acetone_time_value = 0;
            Globals.propanol_time_value = 0;
            Globals.sonicator_water_time_value = 0;
        }

        if (strip_photoresist_step_count == 1 && Globals.wafer_hit_acetone == true)
            strip_photoresist_step_count = 2;
        if (strip_photoresist_step_count == 2 && Globals.acetone_time_value == 5)
        {
            if (Wafer.wafer_layers[Wafer_script.layer_number_wafer - 1, 5, 11] == 1)
            {
                Wafer_script.remove_entire_layer();
                Wafer_script.layer_number_wafer = Wafer_script.layer_number_wafer - 1;
            }
                
            strip_photoresist_step_count = 3;
        }
            
        if (strip_photoresist_step_count == 3 && Globals.wafer_hit_propanol == true)
            strip_photoresist_step_count = 4;
        if (strip_photoresist_step_count == 4 && Globals.propanol_time_value == 5 )
            strip_photoresist_step_count = 5;
        if (strip_photoresist_step_count == 5 && Globals.wafer_hit_sonicator_water ==true)
            strip_photoresist_step_count = 6;
        if (strip_photoresist_step_count == 6 && Globals.sonicator_water_time_value == 1)
            strip_photoresist_step_count = 7;

        ////Debug.Log(strip_photoresist_step_count);

        if (strip_photoresist_step_count == 7)
        {
            ////Debug.Log("Finished");
            if (master_step_count == 3)
                master_step_count = 4;
            if (master_step_count == 10)
                master_step_count = 13;
            if (master_step_count == 21)
                master_step_count = 22;
            if (master_step_count == 30)
                master_step_count = 31;
            if (master_step_count == 39)
                finsihed_game_Canvas.SetActive(true);

            strip_photoresist_step_count = 1;

            Globals.wafer_hit_acetone = false;
            Globals.acetone_time_value = 0;
            Globals.wafer_hit_propanol = false;
            Globals.propanol_time_value = 0;
            Globals.wafer_hit_sonicator_water = false;
            Globals.sonicator_water_time_value = 0;
        }
    }
    void spin_adhesive()
    {
        if (spin_adhesive_step_count == 1)
        {
            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;
        }

        if (spin_adhesive_step_count == 1 && Globals.wafer_adhesive == true)
            spin_adhesive_step_count = 3;
        if (spin_adhesive_step_count == 3 && Globals.wafer_spinner_inside == true)
            spin_adhesive_step_count = 4;          
        if (spin_adhesive_step_count == 4 && Globals.spinner_lid_open == false)
            spin_adhesive_step_count = 5;
        if (spin_adhesive_step_count == 5 && Globals.clicked_on_spinner_pannel == true)
            spin_adhesive_step_count = 6;
        if (spin_adhesive_step_count == 6 && 
            (Globals.Spread_time_value >= 4 && Globals.Spread_time_value <= 6) && 
            (Globals.Spread_speed_value >= 400 && Globals.Spread_speed_value <= 600) && 
            (Globals.Spin_time_value >= 20 && Globals.Spin_time_value <= 40) && 
            (Globals.Spin_speed_value >= 1400 && Globals.Spin_speed_value <= 1600))
            spin_adhesive_step_count = 7;
        
        //Debug.Log(spin_adhesive_step_count);

        if (spin_adhesive_step_count == 7)
        {
            //Debug.Log("Finished");
            if (master_step_count == 4)
                master_step_count = 5;
            if (master_step_count == 15)
                master_step_count = 16;
            if (master_step_count == 24)
                master_step_count = 25;
            if (master_step_count == 33)
                master_step_count = 34;

            spin_adhesive_step_count = 1;

            Globals.wafer_adhesive = false; Globals.wafer_photo_resist = false;
            Globals.clicked_on_spinner_pannel = false;
            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;
            Globals.wafer_spinner_inside = false;

            pick_object_up();
        }
    }
    void spin_photoresist()
    {
        if (spin_photoresist_step_count == 1)
        {            
            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;
        }

        if (spin_photoresist_step_count == 1 && Globals.wafer_photo_resist == true)
            spin_photoresist_step_count = 3;
        if (spin_photoresist_step_count == 3 && Globals.wafer_spinner_inside == true)
            spin_photoresist_step_count = 4;
        if (spin_photoresist_step_count == 4 && Globals.spinner_lid_open == false)
            spin_photoresist_step_count = 5;
        if (spin_photoresist_step_count == 5 && Globals.clicked_on_spinner_pannel == true)
            spin_photoresist_step_count = 6;
        if (spin_photoresist_step_count == 6 &&
            (Globals.Spread_time_value >= 4 && Globals.Spread_time_value <= 6) &&
            (Globals.Spread_speed_value >= 475 && Globals.Spread_speed_value <= 525) &&
            (Globals.Spin_time_value >= 20 && Globals.Spin_time_value <= 40) &&
            (Globals.Spin_speed_value >= 1400 && Globals.Spin_speed_value <= 1600))
            spin_photoresist_step_count = 7;

        //Debug.Log(spin_photoresist_step_count);

        if (spin_photoresist_step_count == 7)
        {
            //Debug.Log("Finished");
            if (master_step_count == 5)
                master_step_count = 6;
            if (master_step_count == 16)
                master_step_count = 17;
            if (master_step_count == 25)
                master_step_count = 26;
            if (master_step_count == 34)
                master_step_count = 35;

            spin_photoresist_step_count = 1;
            Globals.wafer_photo_resist = false; Globals.wafer_adhesive = false;
            Globals.clicked_on_spinner_pannel = false;
            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;
            Globals.wafer_spinner_inside = false;

            pick_object_up();

            Wafer_script.Create_virtual_layer_on_wafer(1);
            Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
        }
    }
    void soft_bake()
    {
        if(soft_bake_step_count == 1)
        {
            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;
        }

        if (soft_bake_step_count == 1 && Globals.wafer_hit_hot_plate == true)
            soft_bake_step_count = 2;
        if (soft_bake_step_count == 2 && Globals.clicked_on_hot_plate_panel == true)
            soft_bake_step_count = 3;
        if (soft_bake_step_count == 3 && 
            (Globals.Hot_Plate_Temperature_value >= 85 && Globals.Hot_Plate_Temperature_value <= 115) && 
            Globals.Hot_Plate_Time_value == 3)
            soft_bake_step_count = 4;

        //Debug.Log(soft_bake_step_count);

        if (soft_bake_step_count == 4)
        {
            //Debug.Log("Finished");
            if (master_step_count == 6)
                master_step_count = 7;
            if (master_step_count == 17)
                master_step_count = 18;
            if (master_step_count == 26)
                master_step_count = 27;
            if (master_step_count == 35)
                master_step_count = 36;

            soft_bake_step_count = 1;

            Globals.wafer_hit_hot_plate = false;
            Globals.clicked_on_hot_plate_panel = false;
            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;
        }
    }
    void expose_mask_1()
    {

        if (expose_mask_1_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (expose_mask_1_step_count == 1 && Globals.clicked_mask_aligner)
            expose_mask_1_step_count = 2;
        if (expose_mask_1_step_count == 2 && maskchoosing.chosen == 1)
        {
            expose_mask_1_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }
            
        if (expose_mask_1_step_count == 3 && Globals.mask_aligned == true)
            expose_mask_1_step_count = 4;
        if (expose_mask_1_step_count == 4 && 
            (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && 
            (Globals.expose_power >= 5 && Globals.expose_power <= 25) && 
            Globals.expose_time == 3)
            expose_mask_1_step_count = 5;

        //Debug.Log(expose_mask_1_step_count);

        if (expose_mask_1_step_count == 5)
        {
            SceneManager.LoadScene("PR_lab");
            //Debug.Log("Finished");
            master_step_count = 8;
            expose_mask_1_step_count = 1;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
         }
    }
    void expose_mask_2()
    {
        if (expose_mask_2_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (expose_mask_2_step_count == 1 && Globals.clicked_mask_aligner)
            expose_mask_2_step_count = 2;
        if (expose_mask_2_step_count == 2 && maskchoosing.chosen == 2)
        {
            expose_mask_2_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }            
        if (expose_mask_2_step_count == 3 && Globals.mask_aligned == true)
            expose_mask_2_step_count = 4;
        if (expose_mask_2_step_count == 4 && 
            (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && 
            (Globals.expose_power >= 5 && Globals.expose_power <= 25) && 
            Globals.expose_time == 3)
            expose_mask_2_step_count = 5;

        Debug.Log(expose_mask_2_step_count);

        if (expose_mask_2_step_count == 5)
        {
            SceneManager.LoadScene("PR_lab");
            //Debug.Log("Finished");
            master_step_count = 19;
            expose_mask_2_step_count = 1;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }
    }
    void expose_mask_3()
    {
        if (expose_mask_3_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (expose_mask_3_step_count == 1 && Globals.clicked_mask_aligner)
            expose_mask_3_step_count = 2;
        if (expose_mask_3_step_count == 2 && maskchoosing.chosen == 3)
        {
            expose_mask_3_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }            
        if (expose_mask_2_step_count == 3 && Globals.mask_aligned == true)
            expose_mask_2_step_count = 4;
        if (expose_mask_3_step_count == 4 && (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && 
            (Globals.expose_power >= 5 && Globals.expose_power <= 25) &&
            Globals.expose_time == 3)
            expose_mask_3_step_count = 5;

        //Debug.Log(expose_mask_3_step_count);

        if (expose_mask_3_step_count == 5)
        {

            SceneManager.LoadScene("PR_lab");
            //Debug.Log("Finished");
            master_step_count = 28;
            expose_mask_3_step_count = 1;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }
    }
    void expose_mask_4()
    {
        if (expose_mask_4_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (expose_mask_4_step_count == 1 && Globals.clicked_mask_aligner)
            expose_mask_4_step_count = 2;
        if (expose_mask_4_step_count == 2 && maskchoosing.chosen == 4)
        {
            SceneManager.LoadScene("Maskminigame");
            expose_mask_4_step_count = 3;
        }
        if (expose_mask_2_step_count == 3 && Globals.mask_aligned == true)
            expose_mask_2_step_count = 4;
        if (expose_mask_4_step_count == 4 && (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && 
            (Globals.expose_power >= 5 && Globals.expose_power <= 25) && 
            Globals.expose_time == 3)
            expose_mask_4_step_count = 5;

        //Debug.Log(expose_mask_4_step_count);

        if (expose_mask_4_step_count == 4)
        {
            
            //Debug.Log("Finished");
            master_step_count = 37;
            expose_mask_4_step_count = 1;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
            SceneManager.LoadScene("PR_lab");
        }
    }
    void develop_photoresist()
    {
        if (develop_photoresist_step_count == 1)
        {
            Globals.time_developer_value = 0;
            Globals.time_developer_water_value = 0;
        }

        if (develop_photoresist_step_count == 1 && Globals.wafer_hit_Developer == true)
            develop_photoresist_step_count = 2;
        if (develop_photoresist_step_count == 2 && (Globals.time_developer_value >= 30 && Globals.time_developer_value <= 60))
            develop_photoresist_step_count = 3;
        if (develop_photoresist_step_count == 3 && Globals.wafer_hit_Developer_water == true)
            develop_photoresist_step_count = 4;
        if (develop_photoresist_step_count == 4 && (Globals.time_developer_water_value >= 45 && Globals.time_developer_value <= 75))
            develop_photoresist_step_count = 5;

        //Debug.Log(develop_photoresist_step_count);

        if (develop_photoresist_step_count == 5)
        {
            if (master_step_count == 8)
                master_step_count = 9;
            if (master_step_count == 19)
                master_step_count = 20;
            if (master_step_count == 28)
                master_step_count = 29;
            if (master_step_count == 37)
                master_step_count = 38;

            develop_photoresist_step_count = 1;

            Globals.time_developer_value = 0;
            Globals.time_developer_water_value = 0;
            if (Wafer.wafer_layers[Wafer_script.layer_number_wafer - 1, 5, 11] == 1)
                Wafer_script.remove_entire_layer();
                Wafer_script.remove_material(Globals.last_mask);
            //Debug.Log("Finished");
        }
    }
    void oxide_etch()
    {
        if (oxide_etch_step_count == 1)
        {
            Globals.piranha_water_time_value = 0;
            Globals.BOE_time_value = 0;
        }

        if (oxide_etch_step_count == 1 && Globals.wafer_hit_BOE == true)
            oxide_etch_step_count = 2;
        if (oxide_etch_step_count == 2 && Globals.BOE_time_value == 5)
            oxide_etch_step_count = 3;
        if (oxide_etch_step_count == 3 && Globals.wafer_hit_piranha_water)
            oxide_etch_step_count = 4;
        if (oxide_etch_step_count == 4 && Globals.piranha_water_time_value== 1)
            oxide_etch_step_count = 5;

        //Debug.Log(oxide_etch_step_count);

        if (oxide_etch_step_count == 5)
        {
            if (master_step_count == 9)
                master_step_count = 10;
            if (master_step_count == 20)
                master_step_count = 21;
            if (master_step_count == 29)
                master_step_count = 30;

            oxide_etch_step_count = 1;

            Globals.piranha_water_time_value = 0;
            Globals.BOE_time_value = 0;
            //if (Wafer.wafer_layers[Wafer_script.layer_number_wafer - 1, 5, 11] == 8)
            Wafer_script.remove_material_second_to_top_layer(Globals.last_mask);
            //Debug.Log("Finished");
        }
    }
    void dehydration_bake()
    {
        if (dehydration_bake_step_count == 1)
        {
            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;
        }

        if (dehydration_bake_step_count == 1 && Globals.wafer_hit_hot_plate == true)
            dehydration_bake_step_count = 2;
        if (dehydration_bake_step_count == 2 && Globals.clicked_on_hot_plate_panel == true)
            dehydration_bake_step_count = 3;
        if (dehydration_bake_step_count == 3 && 
            (Globals.Hot_Plate_Temperature_value >= 175 && Globals.Hot_Plate_Temperature_value <= 225) && 
            Globals.Hot_Plate_Time_value == 5)
            dehydration_bake_step_count = 4;

        //Debug.Log(dehydration_bake_step_count);

        if (dehydration_bake_step_count == 4)
        {
            Globals.wafer_hit_hot_plate = false;
            Globals.clicked_on_hot_plate_panel = false;
            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;

            //Debug.Log("Finished");
            if (master_step_count == 12)
                master_step_count = 13;
            if (master_step_count == 14)
                master_step_count = 15;
            if (master_step_count == 23)
                master_step_count = 24;
            if (master_step_count == 32)
                master_step_count = 33;

            dehydration_bake_step_count = 1;
        }
    }
    void spin_on_dopant()
    {
        if (spin_on_dopant_step_count == 1)
        {
            spin_on_dopant_step_count = 2;

            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;

            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;

            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_2_name = 0;
            Globals.Temperature_value = 0;

            Globals.BHF_time = 0;
            Globals.piranha_water_time_value = 0;
        }
        //spin
        if (spin_on_dopant_step_count == 2 && Globals.wafer_dopant == true)
            spin_on_dopant_step_count = 3;
        if (spin_on_dopant_step_count == 3 && Globals.wafer_spinner_inside == true)
            spin_on_dopant_step_count = 4;
        if (spin_on_dopant_step_count == 4 && Globals.spinner_lid_open == false)
            spin_on_dopant_step_count = 5;
        if (spin_on_dopant_step_count == 5 && Globals.clicked_on_spinner_pannel == true)
            spin_on_dopant_step_count = 6;
        if (spin_on_dopant_step_count == 6 &&
            (Globals.Spread_time_value == 0) &&
            (Globals.Spread_speed_value == 0) && 
            (Globals.Spin_time_value >= 10 && Globals.Spin_time_value <= 30) &&
            (Globals.Spin_speed_value >= 2500 && Globals.Spin_speed_value <= 3500))
            spin_on_dopant_step_count = 7;
        if (spin_on_dopant_step_count == 7)
        {
            spin_on_dopant_step_count = 8;

            pick_object_up();
            Wafer_script.Create_virtual_layer_on_wafer(11);
            Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
        }
        //hot plate
        if (spin_on_dopant_step_count == 8 && Globals.wafer_hit_hot_plate == true)
                spin_on_dopant_step_count = 9;
        if (spin_on_dopant_step_count == 9 && Globals.clicked_on_hot_plate_panel == true)
            spin_on_dopant_step_count = 10;
        if (spin_on_dopant_step_count == 10 &&
            (Globals.Hot_Plate_Temperature_value >= 185 && Globals.Hot_Plate_Temperature_value <= 215) &&
            Globals.Hot_Plate_Time_value == 15)
            spin_on_dopant_step_count = 11;
        
        //furnace
        if (spin_on_dopant_step_count == 11 && Globals.wafer_furnace == true)
            spin_on_dopant_step_count = 12;
        if (spin_on_dopant_step_count == 12 &&
            ((Globals.Gas_1_flow_rate_value == 10 && Globals.Gas_1_name == 2) &&
            (Globals.Gas_2_flow_rate_value == 3 && Globals.Gas_2_name == 1)) &&
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
            (Globals.Time_furnace_value >= 0 && Globals.Time_furnace_value <= 10))
        {
            //furnace_canvas.SetActive(false);
            Globals.wafer_furnace = false;
            spin_on_dopant_step_count = 13;
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;
        }
            
        //BHF
        if (spin_on_dopant_step_count == 13 && Globals.wafer_hit_piranha == true)
                spin_on_dopant_step_count = 14;
        if (spin_on_dopant_step_count == 14 && Globals.piranha_time_value == 5)
            spin_on_dopant_step_count = 15;
        if (spin_on_dopant_step_count == 15 && Globals.wafer_hit_piranha_water == true)
            spin_on_dopant_step_count = 16;
        if (spin_on_dopant_step_count == 16 && Globals.piranha_water_time_value == 1)
        {
            spin_on_dopant_step_count = 21;
            Globals.piranha_water_time_value = 0;
            Wafer_script.remove_entire_layer();
            Wafer_script.layer_number_wafer = Wafer_script.layer_number_wafer - 1;
        }
            /*
        // Pirahna
        if (spin_on_dopant_step_count == 17 && Globals.wafer_hit_piranha == true)
            spin_on_dopant_step_count = 18;
        if (spin_on_dopant_step_count == 18 && Globals.piranha_time_value == 10)
            spin_on_dopant_step_count = 19;
        if (spin_on_dopant_step_count == 19 && Globals.wafer_hit_piranha_water == true)
            spin_on_dopant_step_count = 20;
        if (spin_on_dopant_step_count == 20 && Globals.piranha_water_time_value == 1)
            spin_on_dopant_step_count = 21;
        */
        //N+drive in 
        if (spin_on_dopant_step_count == 21 && Globals.wafer_furnace == true)
            spin_on_dopant_step_count = 22;
        if (spin_on_dopant_step_count == 22 &&
            (Globals.Gas_1_flow_rate_value == 5 && Globals.Gas_1_name == 2)  &&
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
            (Globals.Time_furnace_value >= 0 && Globals.Time_furnace_value <= 20))
        {
            spin_on_dopant_step_count = 23;
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;
        }
        if (spin_on_dopant_step_count == 23 && Globals.wafer_furnace == true)
            spin_on_dopant_step_count = 24;
        if (spin_on_dopant_step_count == 24 &&
            ((Globals.Gas_1_flow_rate_value == 3 && Globals.Gas_1_name == 1) && (Globals.Gas_2_flow_rate_value == 6 && Globals.Gas_2_name == 4)) &&
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
            (Globals.Time_furnace_value >= 10 && Globals.Time_furnace_value <= 30))
        {
            spin_on_dopant_step_count = 25;
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;
        }
        if (spin_on_dopant_step_count == 25 && Globals.wafer_furnace == true)
            spin_on_dopant_step_count = 26;
        if (spin_on_dopant_step_count == 26 &&
           ((Globals.Gas_1_flow_rate_value == 5 && Globals.Gas_1_name == 2) || (Globals.Gas_2_flow_rate_value == 5 && Globals.Gas_2_name == 2)) &&
           (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
           (Globals.Time_furnace_value >= 0 && Globals.Time_furnace_value <= 20))
        {
            spin_on_dopant_step_count = 27;
        }
        if (spin_on_dopant_step_count == 27)
        {
            master_step_count = 15;
            spin_on_dopant_step_count = 1;
            //Wafer_script.Create_virtual_layer_on_wafer(11);
            //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer);

            Globals.Spread_time_value = 0;
            Globals.Spread_speed_value = 0;
            Globals.Spin_time_value = 0;
            Globals.Spin_speed_value = 0;
            Globals.wafer_spinner_inside = false;

            Globals.Hot_Plate_Temperature_value = 0;
            Globals.Hot_Plate_Time_value = 0;
            Globals.wafer_hit_hot_plate = false;
            Globals.clicked_on_hot_plate_panel = false;

            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_2_name = 0;
            Globals.Temperature_value = 0;

            Globals.BHF_time = 0;
            Globals.piranha_water_time_value = 0;
        }
    } 
    void gate_oxidation()
    {
        if (gate_oxidation_step_count == 1)
        {
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
        }

        if (gate_oxidation_step_count == 1 && Globals.wafer_furnace == true)
            gate_oxidation_step_count = 2;
        if (gate_oxidation_step_count == 2 && 
            ((Globals.Gas_1_flow_rate_value == 5 && Globals.Gas_1_name == 2) || (Globals.Gas_2_flow_rate_value == 5 && Globals.Gas_2_name == 2)) && 
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200)  &&
            (Globals.Time_furnace_value >= 0 && Globals.Time_furnace_value <= 20))
        {
            gate_oxidation_step_count = 3;
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;
            Globals.wafer_furnace = false;
        }
        if (gate_oxidation_step_count == 3 && Globals.wafer_furnace == true)
            gate_oxidation_step_count = 4;

        if (gate_oxidation_step_count == 4 &&
            ((Globals.Gas_1_flow_rate_value == 5 && Globals.Gas_1_name == 1) || (Globals.Gas_2_flow_rate_value == 5 && Globals.Gas_2_name == 1)) &&
            (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
            (Globals.Time_furnace_value >= 100 && Globals.Time_furnace_value <= 140))
        {
            gate_oxidation_step_count = 5;
            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;
            Globals.wafer_furnace = false;
        }
        if (gate_oxidation_step_count == 5 && Globals.wafer_furnace == true)
            gate_oxidation_step_count = 6;
        if (gate_oxidation_step_count == 6 &&
           ((Globals.Gas_1_flow_rate_value == 5 && Globals.Gas_1_name == 2) || (Globals.Gas_2_flow_rate_value == 5 && Globals.Gas_2_name == 2)) &&
           (Globals.Temperature_value >= 1000 && Globals.Temperature_value <= 1200) &&
           (Globals.Time_furnace_value >= 0 && Globals.Time_furnace_value <= 20))
        {
            gate_oxidation_step_count = 7;
        }
        
        //Debug.Log(gate_oxidation_step_count);

        if (gate_oxidation_step_count == 7)
        {
            //furnace_canvas.SetActive(false);
            Globals.wafer_furnace = false;
            master_step_count = 24;
            gate_oxidation_step_count = 1;

            Globals.Gas_1_flow_rate_value = 0;
            Globals.Gas_2_flow_rate_value = 0;
            Globals.Gas_1_name = 0;
            Globals.Gas_1_name = 0;
            Globals.Temperature_value = 0;
            Globals.Time_furnace_value = 0;

            Wafer_script.Create_virtual_layer_on_wafer(8);
            Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
            //Debug.Log("Finished");
        }
    }
    void al_evaporation()
    {
        if (evap_step_count == 1)
        {
            Globals.Gas_name = 0;
            Globals.Evap_temperature = 0;
            Globals.Evap_time = 0;
            Globals.Evap_flow_rate = 0;
        }

        if (evap_step_count == 1 && Globals.clicked_evap)
            evap_step_count = 2;
        if(evap_step_count == 2 && Globals.Gas_name == 1 &&
            Globals.Evap_flow_rate == 5 &&
            (Globals.Evap_temperature >= 1000 && Globals.Evap_temperature <= 1200) &&
           (Globals.Evap_time == 5))
            evap_step_count = 3;
        if (evap_step_count == 3)
        {
            master_step_count = 33;
            evap_step_count = 1;

            Globals.Gas_name = 0;
            Globals.Evap_temperature = 0;
            Globals.Evap_time = 0;
            Globals.Evap_flow_rate = 0;
            
            Wafer_script.Create_virtual_layer_on_wafer(9);
            Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer-1);
        }
        //Debug.Log("To be decided: Al Evaporation");

    } 
    void al_etch()
    {
        if (al_etch_step_count == 1)
        {
            Globals.Al_Etchant_time_value = 0;
            Globals.piranha_water_time_value = 0;
        }

        if (al_etch_step_count == 1 && Globals.wafer_hit_Al_Etchant == true)
            al_etch_step_count = 2;
        if (al_etch_step_count == 2 && Globals.Al_Etchant_time_value == 5)
            al_etch_step_count = 3;
        if (al_etch_step_count == 3 && Globals.wafer_hit_piranha_water == true)
            al_etch_step_count = 4;
        if (al_etch_step_count == 4 && Globals.piranha_water_time_value == 1)
            al_etch_step_count = 5;

        //Debug.Log(al_etch_step_count);

        if (al_etch_step_count == 5)
        {
            master_step_count = 39;
            al_etch_step_count = 1;

            Globals.Al_Etchant_time_value = 0;
            Globals.piranha_water_time_value = 0;

            //if (Wafer.wafer_layers[Wafer_script.layer_number_wafer - 1, 5, 11] == 9)
            Wafer_script.remove_material_second_to_top_layer(Globals.last_mask);
            //Debug.Log("Finished");
        }
    }

    void pick_object_up()
    {
        Wafer_gameObj.transform.parent = Player.transform;
        Wafer_gameObj.transform.localPosition = new Vector3(0, 1, 3);
        Wafer_gameObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        Wafer_gameObj.GetComponent<Rigidbody>().useGravity = false;
        Wafer_gameObj.GetComponent<Rigidbody>().isKinematic = false;
        Wafer_gameObj.GetComponent<BoxCollider>().enabled = false;
        Globals.pick_up_wafer = true;
    }
}

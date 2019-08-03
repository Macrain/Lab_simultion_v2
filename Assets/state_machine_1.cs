using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class state_machine_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Globals.mask_mini_game = true;
        Globals.mask_mini_game = false;

        if (Globals.mask_mini_game == true)
        {
            State_machine.expose_mask_1_step_count = 2;
            State_machine.expose_mask_2_step_count = 2;
            State_machine.expose_mask_3_step_count = 2;
            State_machine.expose_mask_4_step_count = 2;
        }
        else
        {
            State_machine.expose_mask_1_step_count = 1;
            State_machine.expose_mask_2_step_count = 1;
            State_machine.expose_mask_3_step_count = 1;
            State_machine.expose_mask_4_step_count = 1;
        }
    }
	
	void Update () {
        /*if (Input.GetKeyDown("h") && Globals.debug)
        {
            State_machine.expose_mask_1_step_count = 1;
            State_machine.expose_mask_2_step_count = 1;
            State_machine.expose_mask_3_step_count = 1;
            State_machine.expose_mask_4_step_count = 1;

            State_machine.master_step_count++;
        }*/

        if (Globals.mask_mini_game == true)
            mask2();
        else
        {
            if (State_machine.master_step_count == 7)
                mask1();
            if (State_machine.master_step_count == 18)
                mask2();
            if (State_machine.master_step_count == 27)
                mask3();
            if (State_machine.master_step_count == 36)
                mask4();
        }
    }

    void mask1()
    {
        State_machine.master_step_count = 7;
        if (State_machine.expose_mask_1_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            //Globals.mask_aligned = false;
        }

        if (State_machine.expose_mask_1_step_count == 1 && Globals.clicked_mask_aligner)
            State_machine.expose_mask_1_step_count = 2;
        if (State_machine.expose_mask_1_step_count == 2 && maskchoosing.chosen == 1)
        {
            State_machine.expose_mask_1_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }
    }

    void mask2()
    {
        State_machine.master_step_count = 18;
        if (State_machine.expose_mask_2_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            //Globals.mask_aligned = false;
        }

        if (State_machine.expose_mask_2_step_count == 1 && Globals.clicked_mask_aligner)
            State_machine.expose_mask_2_step_count = 2;
        if (State_machine.expose_mask_2_step_count == 2 && maskchoosing.chosen == 2)
        {
            State_machine.expose_mask_2_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }
    }

    void mask3()
    {
        State_machine.master_step_count = 27;
        if (State_machine.expose_mask_3_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (State_machine.expose_mask_3_step_count == 1 && Globals.clicked_mask_aligner)
            State_machine.expose_mask_3_step_count = 2;
        if (State_machine.expose_mask_3_step_count == 2 && maskchoosing.chosen == 3)
        {
            State_machine.expose_mask_3_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }
    }

    void mask4()
    {
        State_machine.master_step_count = 36;
        if (State_machine.expose_mask_4_step_count == 1)
        {
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
        }

        if (State_machine.expose_mask_4_step_count == 1 && Globals.clicked_mask_aligner)
            State_machine.expose_mask_4_step_count = 2;
        if (State_machine.expose_mask_4_step_count == 2 && maskchoosing.chosen == 4)
        {
            State_machine.expose_mask_4_step_count = 3;
            SceneManager.LoadScene("Maskminigame");
        }
    }

}

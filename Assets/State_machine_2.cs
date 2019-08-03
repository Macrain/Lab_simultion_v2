using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class State_machine_2 : MonoBehaviour {

    public GameObject done_canvas;
    public GameObject Directional_Canvas;
    public GameObject Finished_alignment;
    public GameObject Failed;
    public GameObject Expose_Canvas;

    public static bool flag_correct;

    private void Start()
    {
        State_machine.expose_mask_1_step_count = 3;
        State_machine.expose_mask_2_step_count = 3;
        State_machine.expose_mask_3_step_count = 3;
        State_machine.expose_mask_4_step_count = 3;
        done_canvas.SetActive(false);
        Finished_alignment.SetActive(false);
        Expose_Canvas.SetActive(false);

        Globals.expose_energy = 0;
        Globals.expose_power = 0;
        Globals.expose_time = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Globals.debug == true && Input.GetKeyDown("q"))
            Globals.mask_aligned = true;
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
    public void mask1()
    {
        State_machine.master_step_count = 7;
        if (State_machine.expose_mask_1_step_count == 3 && Globals.mask_aligned == true)
        {
            State_machine.expose_mask_1_step_count = 4;
            Finished_alignment.SetActive(true);
            Directional_Canvas.SetActive(false);
        }

        if ((State_machine.expose_mask_1_step_count == 4) && (flag_correct == true))
        {
            if ((Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && (Globals.expose_power >= 5 && Globals.expose_power <= 25) && Globals.expose_time == 3)
            {
                State_machine.expose_mask_1_step_count = 5;
                Expose_Canvas.SetActive(false);

                if (Globals.mask_mini_game == true)
                    done_canvas.SetActive(true);
                //Debug.Log("Good");
            }
            else
            {
                if (Globals.mask_mini_game == true)
                    Failed.SetActive(false);
                //Debug.Log("Bad");
            }

        }
            


        if (State_machine.expose_mask_1_step_count == 5)
        {

            //Debug.Log("Finished");
            State_machine.master_step_count = 8;
            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
            maskchoosing.chosen = 0;

            if (Globals.mask_mini_game == true)
            {
                State_machine.expose_mask_1_step_count = 2;
                if (flag_correct == true)
                    done_canvas.SetActive(true);
                else
                    Failed.SetActive(true);

            }
            else if (Globals.mask_mini_game == false)
            {
                State_machine.expose_mask_1_step_count = 1;
                SceneManager.LoadScene("PR_lab");
            }

        }
    }
    public void mask2()
    {
        State_machine.master_step_count = 18;
        if (State_machine.expose_mask_2_step_count == 3 && Globals.mask_aligned == true)
        {
            State_machine.expose_mask_2_step_count = 4;
            Finished_alignment.SetActive(true);
            Directional_Canvas.SetActive(false);
        }
        if (State_machine.expose_mask_2_step_count == 4 && (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && (Globals.expose_power >= 5 && Globals.expose_power <= 25) && Globals.expose_time == 3)
        {
            State_machine.expose_mask_2_step_count = 5;
            Expose_Canvas.SetActive(false);
        }
        // mini game code
        /*if ((State_machine.expose_mask_2_step_count == 4))
        {
            
            if (flag_correct == true)
            {
                if ((Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && (Globals.expose_power >= 5 && Globals.expose_power <= 25) && Globals.expose_time == 3)
                {
                    if (Globals.mask_mini_game == true)
                        done_canvas.SetActive(true);
                    Debug.Log("Good");
                }
                else
                {
                    if (Globals.mask_mini_game == true)
                        Failed.SetActive(true);
                    Debug.Log("Bad");
                }
                State_machine.expose_mask_2_step_count = 5;
                Expose_Canvas.SetActive(false);
            }*/

    
        if (State_machine.expose_mask_2_step_count == 5)
        {
            //Debug.Log("Finished");
            State_machine.master_step_count = 19;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
            maskchoosing.chosen = 0;
            flag_correct = false;

            if (Globals.mask_mini_game == true)
            {
                //done_canvas.SetActive(true);
                State_machine.expose_mask_2_step_count = 2;
            }
            else if (Globals.mask_mini_game == false)
            {
                State_machine.expose_mask_2_step_count = 1;
                SceneManager.LoadScene("PR_lab");
            }

        }
    }
    public void mask3()
    {
        State_machine.master_step_count = 27;
        if (State_machine.expose_mask_3_step_count == 3 && Globals.mask_aligned == true)
        {
            State_machine.expose_mask_3_step_count = 4;
            Finished_alignment.SetActive(true);
            Directional_Canvas.SetActive(false);
        }

        if (State_machine.expose_mask_3_step_count == 4 && (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && (Globals.expose_power >= 5 && Globals.expose_power <= 25) && Globals.expose_time == 3)
        {
            State_machine.expose_mask_3_step_count = 5;
            Expose_Canvas.SetActive(false);
        }
        if (State_machine.expose_mask_3_step_count == 5)
        {
            //Debug.Log("Finished");
            State_machine.master_step_count = 28;
            State_machine.expose_mask_3_step_count = 2;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
            maskchoosing.chosen = 0;

            if (Globals.mask_mini_game == true)
            {
                done_canvas.SetActive(true);
                State_machine.expose_mask_3_step_count = 2;
            }
            else if (Globals.mask_mini_game == false)
            {
                State_machine.expose_mask_3_step_count = 1;
                SceneManager.LoadScene("PR_lab");
            }
        }
    }
    public void mask4()
    {
        State_machine.master_step_count = 36;
        if (State_machine.expose_mask_4_step_count == 3 && Globals.mask_aligned == true)
        {
            State_machine.expose_mask_4_step_count = 4;
            Finished_alignment.SetActive(true);
            Directional_Canvas.SetActive(false);
        }

        if (State_machine.expose_mask_4_step_count == 4 && (Globals.expose_energy >= 30 && Globals.expose_energy <= 60) && (Globals.expose_power >= 5 && Globals.expose_power <= 25) && Globals.expose_time == 3)
        {
            State_machine.expose_mask_4_step_count = 5;
            Expose_Canvas.SetActive(false);
        }
        if (State_machine.expose_mask_4_step_count == 5)
        {
            //Debug.Log("Finished");
            State_machine.master_step_count = 37;

            Globals.expose_energy = 0;
            Globals.expose_power = 0;
            Globals.expose_time = 0;
            Globals.mask_aligned = false;
            maskchoosing.chosen = 0;

            if (Globals.mask_mini_game == true)
            {
                done_canvas.SetActive(true);
                State_machine.expose_mask_4_step_count = 2;
            }
            else if (Globals.mask_mini_game == false)
            {
                State_machine.expose_mask_4_step_count = 1;
                SceneManager.LoadScene("PR_lab");
            }
        }
    }
}

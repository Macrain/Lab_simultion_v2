using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Difficulty_level_canvas_script : Wafer {

    public GameObject difficulty_canvas;
    public Dropdown difficulty_dropdown;

    public GameObject levels_canvas;

    Button levels_button;
    public Button levels_button_field;

    public Button suit_up_level_field;
    public Button mask1_level_field;
    public Button mask2_level_field;
    public Button mask3_level_field;
    public Button mask4_level_field;
    public Button levels_back_field;

    Button suit_up_level;
    Button mask1_level;
    Button mask2_level;
    Button mask3_level;
    Button mask4_level;
    Button levels_back;

    public Button button_control_field;
    public Button control_back;

    public Button button_done_field;
    public Button button_done;

    public GameObject control_text;

    public GameObject initilize_to_zero_obj;
    initilize_to_zero_script initilize_to_zero_obj_script;

    GameObject Wafer_gameObj;
    public GameObject Wafer_og_gameObj;
    Wafer Wafer_script;

    public static bool test_canvas_difficulty;

    private void Start()
    {
        wafer = GameObject.Find("Wafer_temp");

        test_canvas_difficulty = false;
        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_script = Wafer_gameObj.GetComponent<Wafer>();

        Wafer_gameObj = GameObject.Find("Wafer_temp");
        Wafer_og_gameObj = GameObject.Find("Wafer");

        initilize_to_zero_obj_script = initilize_to_zero_obj.GetComponent<initilize_to_zero_script>();

        control_back = button_control_field.GetComponent<Button>();
        control_back.onClick.AddListener(button_control_TaskOnClick);

        button_done = button_done_field.GetComponent<Button>();
        button_done.onClick.AddListener(button_done_TaskOnClick);

        levels_button = levels_button_field.GetComponent<Button>();
        levels_button.onClick.AddListener(levels_canvas_TaskOnClick);

        suit_up_level = suit_up_level_field.GetComponent<Button>();
        suit_up_level.onClick.AddListener(suit_up_level_TaskOnClick);

        mask1_level = mask1_level_field.GetComponent<Button>();
        mask1_level.onClick.AddListener(mask1_level_TaskOnClick);

        mask2_level = mask2_level_field.GetComponent<Button>();
        mask2_level.onClick.AddListener(mask2_level_TaskOnClick);

        mask3_level = mask3_level_field.GetComponent<Button>();
        mask3_level.onClick.AddListener(mask3_level_TaskOnClick);

        mask4_level = mask4_level_field.GetComponent<Button>();
        mask4_level.onClick.AddListener(mask4_level_TaskOnClick);

        levels_back = levels_back_field.GetComponent<Button>();
        levels_back.onClick.AddListener(levels_back_TaskOnClick);

        control_text.SetActive(false); // turn canvas off to begin with.        

        if (Globals.levels_first_scene == true)
        {
            Globals.levels_first_scene = false;
            levels_canvas.SetActive(true);
        }
        else
            levels_canvas.SetActive(false);
    }

    void suit_up_level_TaskOnClick()
    {
        initilize_to_zero_script.initialize_to_zero();
        Globals.main_lab = false;
        SceneManager.LoadScene("Suit_up");
    }
    void drop_wafer()
    {
        Wafer_og_gameObj.transform.parent = null;
        //Wafer_gameObj.transform.parent = null;
        Wafer_gameObj.transform.parent = Wafer_og_gameObj.transform;
        Wafer_gameObj.GetComponent<Rigidbody>().useGravity = true;
        Wafer_gameObj.GetComponent<BoxCollider>().enabled = true;
        Globals.pick_up_wafer = false;
    }
    void mask1_level_TaskOnClick()
    {
        start_script.initialize_to_zero(); // set all values to zero, including the state maching
        drop_wafer();
        if (Globals.main_lab == false) // change scene to main lab if user is not already there
        {
            SceneManager.LoadScene("PR_lab");
            Globals.main_lab = true;
        }
        set_wafer_array_to_zero();

        while (layer_number_wafer >= 0) // remove all layers of material
        {
            remove_entire_layer();
            layer_number_wafer = Wafer_script.layer_number_wafer - 1;
        }

        Create_virtual_layer_on_wafer(8);
        Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer );

        State_machine.master_step_count = 1;
        //Debug.Log(layer_number_wafer);
    }

    void set_wafer_array_to_zero()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < number_of_blocks_across_square; j++)
            {
                for (int k = 0; k < number_of_blocks_across_square; k++)
                    wafer_layers[i, j, k] = 0;
            }
        }
        //Difficulty_level_canvas_script.test_canvas_difficulty = false;
        //Debug.Log("set to zero");       
    }

    void mask2_level_TaskOnClick()
    {
        start_script.initialize_to_zero();
        Globals.last_mask = 1;
        drop_wafer();
        if (Globals.main_lab == false)
        {
            SceneManager.LoadScene("PR_lab");
            Globals.main_lab = true;
        }

        set_wafer_array_to_zero();
        //test_canvas_difficulty = true;

        while (layer_number_wafer >= 0) // remove all layers of material
        {
            remove_entire_layer();
            layer_number_wafer = layer_number_wafer - 1;
        }

        //create silicon dioxide layer
        Create_virtual_layer_on_wafer(8);
        Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer );

        //remove the areas that have been etched away
        Create_virtual_layer_on_wafer(8);
        //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer - 1);
        remove_material(1,8);
        //Wafer_script.layer_number_wafer = Wafer_script.layer_number_wafer + 1;

        State_machine.master_step_count = 13;
        //Debug.Log(layer_number_wafer);
    }

    void mask3_level_TaskOnClick()
    {
        start_script.initialize_to_zero();
        Globals.last_mask = 2;
        drop_wafer();
        if (Globals.main_lab == false)
        {
            SceneManager.LoadScene("PR_lab");
            Globals.main_lab = true;
        }
        set_wafer_array_to_zero();
        while (layer_number_wafer >= 0) // remove all layers of material
        {
            remove_entire_layer();
            layer_number_wafer = layer_number_wafer - 1;
        }
        //Debug.Log("zeroth layer" + Wafer_script.layer_number_wafer);

        //create silicon dioxide layer
        Create_virtual_layer_on_wafer(8);
        Create_physical_layer_on_wafer(layer_number_wafer);
        //Debug.Log("first layer " + Wafer_script.layer_number_wafer);

        //remove the areas that have been etched away
        Create_virtual_layer_on_wafer(8);
        remove_material(1);
        //Debug.Log("second layer " + Wafer_script.layer_number_wafer);


        Create_virtual_layer_on_wafer(8);
        remove_material(2);
        //Debug.Log("third layer " + Wafer_script.layer_number_wafer);

        //remove the areas that have been etched away from first mask
        //Wafer_script.Create_virtual_layer_on_wafer(8);
        //Wafer_script.Create_physical_layer_on_wafer(Wafer_script.layer_number_wafer - 1);
        //Wafer_script.remove_material(2);

        State_machine.master_step_count = 22;
        //Debug.Log(Wafer_script.layer_number_wafer);
    }

    void mask4_level_TaskOnClick()
    {
        start_script.initialize_to_zero();
        Globals.last_mask = 3;
        drop_wafer();
        if (Globals.main_lab == false)
        {
            SceneManager.LoadScene("PR_lab");
            Globals.main_lab = true;
        }
        while (layer_number_wafer >= 0) // remove all layers of material
        {
            remove_entire_layer();
            layer_number_wafer = layer_number_wafer - 1;
        }
        //Debug.Log("zeroth layer" + Wafer_script.layer_number_wafer);

        //create silicon dioxide layer
        Create_virtual_layer_on_wafer(8);
        Create_physical_layer_on_wafer(layer_number_wafer);
        //Debug.Log("first layer " + Wafer_script.layer_number_wafer);

        //remove the areas that have been etched away
        Create_virtual_layer_on_wafer(8);
        remove_material(1);
        //Debug.Log("second layer " + Wafer_script.layer_number_wafer);

        // layer from mask 3
        Create_virtual_layer_on_wafer(8);
        remove_material(2);
        //Debug.Log("third layer " + Wafer_script.layer_number_wafer);

        Create_virtual_layer_on_wafer(8);
        remove_material(4);
        //Debug.Log("fourth layer " + Wafer_script.layer_number_wafer);

        State_machine.master_step_count = 31;
        //Debug.Log(Wafer_script.layer_number_wafer);
    }


    void levels_back_TaskOnClick()
    {
        levels_canvas.SetActive(false); // turn off levels canvas
        Globals.levels_canvas_activate = false;
    }

    void levels_canvas_TaskOnClick()
    {
        if (Globals.levels_canvas_activate == false)
        {
            levels_canvas.SetActive(true);
            Globals.levels_canvas_activate = true;
        }
        else if (Globals.levels_canvas_activate == true)
        {
            levels_canvas.SetActive(false);
            Globals.levels_canvas_activate = false;
        }
    }

    void button_control_TaskOnClick()
    {
        if (Globals.control_text_activate == false)
        {
            control_text.SetActive(true);// turn canvas on when you press control button.
            Globals.control_text_activate = true; // let the rest of the program know that you turned the control on
        }
        else if (Globals.control_text_activate == true)
        {
            control_text.SetActive(false);// turn canvas on when you press control button.
            Globals.control_text_activate = false; // let the rest of the program know that you turned the control on
        }

    }

    void button_done_TaskOnClick()
    {
        control_text.SetActive(false); // turn canvas off when you press "done"
        Globals.control_text_activate = false; // let the rest of the program know that you turned the control off
    }

    void Update ()
    {
        Globals.difficulty = difficulty_dropdown.value; // Constantly update the difficulty
    } 
}
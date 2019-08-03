using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to Wafer_temp

/* This object contains the following functions
 * Create_virtual_layer_on_wafer
 * Create_physical_layer_on_wafer
 * remove_entire_layer
 * remove_material_second_to_top_layer
 * remove_material
 * Cube
 * OnCollisionEnter
 * OnCollisionExit
 */
public class Wafer : MonoBehaviour {

    public GameObject wafer; // This should be the object Wafer_temp in inspector
    float scale_box_x = 0.025f; // Dimension of the squares x that are placed on the wafer
    float scale_box_z = 0.025f; // Dimension of the squares y that are placed on the wafer
    //float scale_box_y = 0.0025f; // Dimension of the squares z that are placed on the wafer
    float scale_box_y = 0.0025f;
    float thickness = 0.025f;

    float wafer_dim_x = 1; // Dimension of the wafer in the x direction
    float wafer_dim_z = 1; // Dimension of the wafer in the z direction
    public static int number_of_blocks_across_square = 40; // Number of blocks accross the square.  Do not change.
    public int layer_number_wafer; // This variable keeps track of the highest layer of the wafer
    public static int [,,] wafer_layers = new int [20, number_of_blocks_across_square+1, number_of_blocks_across_square+1]; // This array keeps track of all layers.  Hard coded toS 20 layers 
    public static Collider m_Collider; // Later assigned to the collider of the blocks to disable collider.  This makes the game easier to load.
    GameObject parent_layer; // keeps all the rows of every layer for organzation
    GameObject row; // rows that correspond to rows of the array and masks, for organization
    public static int[] wafer_cross_section = new int[20];
    
    /* Function of start:
     * Parameters: none
     * Summary: To initialize layer_number_wafer to 0 and to create the first layer of silicon on the wafer.
     */

    public void Start()
    {
        wafer = GameObject.Find("Wafer_temp");
        layer_number_wafer = 0;
        //wafer = GameObject.Find("Wafer_temp");
        /* 
         * Testing
         */


        //Create_virtual_layer_on_wafer(12); // first layer is silicon
        //Create_physical_layer_on_wafer(layer_number_wafer - 1);
        /*
        Create_virtual_layer_on_wafer(8); // second layer is SiO2
        Create_physical_layer_on_wafer(layer_number_wafer - 1);

        Create_virtual_layer_on_wafer(1); // thrid layer is pr
        Create_physical_layer_on_wafer(layer_number_wafer - 1);

        remove_material(1); // rm material from pr layer

        remove_material_second_to_top_layer(1);
        
        Create_virtual_layer_on_wafer(0); // first layer is silicon
        Create_physical_layer_on_wafer(layer_number_wafer - 1);
        Debug.Log(layer_number_wafer);*/
    }

    public void Update()
    {
        if (Globals.pick_up_wafer == true && Globals.wafer_click_microscope == false)
        {
            transform.localPosition = new Vector3(0, 1, 3);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        /*if (Difficulty_level_canvas_script.test_canvas_difficulty)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < number_of_blocks_across_square; j++)
                {
                    for (int k = 0; k < number_of_blocks_across_square; k++)
                        wafer_layers[i, j, k] = 0;
                }
            }
            Difficulty_level_canvas_script.test_canvas_difficulty = false;
            Debug.Log("set to zero");

        }*/
        if (profilometer_canvas_script.draw_graph_bool == true)
        {
            create_wafer_cross_section();
            //profilometer_canvas_script.draw_graph_bool = false;
        }

    }

    public static void create_wafer_cross_section()
    {
        for (int x = 0; x < 20; x++)
            wafer_cross_section[x] = 0;

        int count = 0;
        for (int j = 7; j < 20; j++)// column
        {
            for (int i = 10; i >0 ; i--)//
            {
                if (wafer_layers[i, 12, j] != 0) // 12 is the row; i is the layer; j is left to right
                 {
                    wafer_cross_section[count] = i;
                    //Debug.Log("layer number is " + i);
                    count = count + 1;
                    break;
                }
            }            
        }
        /*
        Debug.Log(wafer_cross_section[0]);
        Debug.Log(wafer_cross_section[1]);
        Debug.Log(wafer_cross_section[2]);
        Debug.Log(wafer_cross_section[3]);
        Debug.Log(wafer_cross_section[4]);
        Debug.Log(wafer_cross_section[5]);
        Debug.Log(wafer_cross_section[6]);
        Debug.Log(wafer_cross_section[7]);
        Debug.Log(wafer_cross_section[8]);
        Debug.Log(wafer_cross_section[9]);
        Debug.Log(wafer_cross_section[10]);
        Debug.Log(wafer_cross_section[11]);
        Debug.Log(wafer_cross_section[12]);
        */
    }

    /* Function of Create_virtual_layer_on_wafer
     * Parameters: int material-  This material number corresponds to the cube object.
     * Summary: This function fills in another layer of the array wafer_layers with a number corresponding to the the material on that layer 
     */
    public void Create_virtual_layer_on_wafer(int material) {
        for(int i = 0; i< number_of_blocks_across_square; i++)
        {
            for (int j = 0; j < number_of_blocks_across_square; j++)
            {
                wafer_layers[layer_number_wafer+1, i, j] = material;
            }
        }
        layer_number_wafer = layer_number_wafer + 1 ;
    }

    /* Function of Create_physical_layer_on_wafer
     * Parameters: layer-  This is the height of the layer that you want to be created
     * Summary: creates a layer with no pattern on the wafer
     */
    public void Create_physical_layer_on_wafer(int layer)
    {
        var next_cube_position = wafer.transform.position;
        next_cube_position.y = next_cube_position.y + .006f + (layer_number_wafer)* .003f; // starting y positon, right above wafer
        next_cube_position.z = wafer.transform.position.z + wafer_dim_z / 2; // starting z position

        for (int i = 0; i<layer_number_wafer; i++) // Iterates through layer_number_wafer to find out how high this next layer needs to be
            next_cube_position.y = next_cube_position.y + scale_box_y;

        parent_layer = new GameObject("Parent" + layer_number_wafer.ToString()); // Organization purposes, assigns entire layer to parrent + number
        parent_layer.transform.parent = wafer.transform;

        for (int count_z = 0; count_z < number_of_blocks_across_square; count_z++)
        {
            row = new GameObject("row" + count_z.ToString()); // Organization purposes, assigns entire layer to row + number
            row.transform.parent = parent_layer.transform;

            next_cube_position.x = wafer.transform.position.x - wafer_dim_x/2; // starting x position

            for (int count_x = 0; count_x < number_of_blocks_across_square; count_x++)
            {

                Wafer.Cube obj = new Wafer.Cube(wafer_layers[layer, count_z, count_x]); // calls object Cube to create new part of the wafer

                //Debug.Log(wafer_layers[layer, count_z, count_x]);
                obj.cube_game_obj.transform.parent = row.transform; // assign it to row for organization
                obj.cube_game_obj.transform.position = next_cube_position; // put it in the correct spot, calculated from above


                Vector3 scale = new Vector3(scale_box_x, scale_box_y, scale_box_z); // Scales the box
                obj.cube_game_obj.transform.localScale = scale;

                if (Globals.entire_wafer[count_z, count_x] == 0)  // Depending on the array entire wafer, the array is deactivated or not.  This creates material only on the wafer.
                {
                    obj.cube_game_obj.SetActive(false);
                    wafer_layers[layer_number_wafer, count_z, count_x] = 0;
                }

                next_cube_position.x += scale_box_x; // assign next position x
            }
            next_cube_position.z -= scale_box_z; // assign next position z
        }
    }

    /* Function of remove_entire_layer
     * Parameters: none
     * Summary: Removes the most recently added layer
     */
    public void remove_entire_layer()
    {
        GameObject layer_to_be_removed = GameObject.Find("Parent" + layer_number_wafer.ToString()); //
        Destroy(layer_to_be_removed);
        for (int count_z = 0; count_z < number_of_blocks_across_square; count_z++)
        {
            for (int count_x = 0; count_x < number_of_blocks_across_square; count_x++)
            {
                wafer_layers[layer_number_wafer, count_z, count_x] = 0;
            }
            
        }
    }

    /*Function of remove_material_second_to_top_layer
     * Parameters: mask_number
     * Summary: removes the material of the second top layer of the wafer according to the mask number
     */
    public void remove_material_second_to_top_layer(int mask_number) 
    {
        layer_number_wafer = layer_number_wafer - 1;
        remove_entire_layer();
        remove_material(mask_number);
        layer_number_wafer = layer_number_wafer + 1;
    }

    /* Function of remove_material
     * Parameters: mask_number
     * Summary: removes the material of the top layer of the wafer according to the mask number
     */
    public void remove_material(int mask_number, int material = 100)
    {
        GameObject top_layer = GameObject.Find("Parent" + layer_number_wafer.ToString()); // Find the top layer
        Destroy(top_layer); //... and destroy it
        int layer =layer_number_wafer;
        //int layer = layer_number_wafer - 1; // increment layer accordingly

        var next_cube_position = wafer.transform.position;
        next_cube_position.y = next_cube_position.y + 0.003f * (layer_number_wafer); // set origninal y corrdinate above wafer
        next_cube_position.z = wafer.transform.position.z + wafer_dim_z / 2; // set x corrdinate

        for (int i = 0; i < layer_number_wafer; i++) // change the y corrdinate (height) based on the layer
            next_cube_position.y = next_cube_position.y + scale_box_y;

        parent_layer = new GameObject("Parent" + layer_number_wafer.ToString()); // sets all blocks created for this layer under parent+number
        parent_layer.transform.parent = wafer.transform;

        for (int count_z = 0; count_z < number_of_blocks_across_square; count_z++) // create rows
        {
            next_cube_position.x = wafer.transform.position.x - wafer_dim_x / 2; // change the position of the x for the next block

            row = new GameObject("row" + count_z.ToString()); // organization, keep all the blocks in the rows together
            row.transform.parent = parent_layer.transform;

            for (int count_x = 0; count_x < number_of_blocks_across_square; count_x++)
            {
                Wafer.Cube obj = new Wafer.Cube(wafer_layers[layer, count_z, count_x]); // create new object block on wafer
                obj.cube_game_obj.transform.parent = row.transform;
                obj.cube_game_obj.transform.position = next_cube_position; // change position of block

                Vector3 scale = new Vector3(scale_box_x, scale_box_y, scale_box_z); // scale block
                obj.cube_game_obj.transform.localScale = scale;

                // depending on the mask only allow certain blocks to exist
                switch (mask_number)
                {
                    case 0: // entire_wafer
                        if (Globals.entire_wafer[count_x, count_z] == 0)
                        {
                            obj.cube_game_obj.SetActive(false);
                            wafer_layers[layer_number_wafer, count_x, count_z] = 0;
                        }
                        else wafer_layers[layer_number_wafer, count_x, count_z] = material;
                        break;
                    case 1: // mask1
                        if (Globals.mask1[count_x, count_z] == 0)
                        {
                            obj.cube_game_obj.SetActive(false);
                            wafer_layers[layer_number_wafer, count_x, count_z] = 0;
                        }
                        else wafer_layers[layer_number_wafer, count_x, count_z] = material;

                        break;
                    case 2: // mask2
                        if (Globals.mask2[count_x, count_z] == 0)
                        {
                            obj.cube_game_obj.SetActive(false);
                            wafer_layers[layer_number_wafer, count_x, count_z] = 0;
                        }
                        else wafer_layers[layer_number_wafer, count_x, count_z] = material;

                        break;
                    case 3: // mask3
                        if (Globals.mask3[count_x, count_z] == 0)
                        {
                            obj.cube_game_obj.SetActive(false);
                            wafer_layers[layer_number_wafer, count_x, count_z] = 0;
                        }
                        else wafer_layers[layer_number_wafer, count_x, count_z] = material;

                        break;
                    case 4: // mask4
                        if (Globals.mask4[count_x, count_z] == 0)
                        {
                            obj.cube_game_obj.SetActive(false);
                            wafer_layers[layer_number_wafer, count_x, count_z] = 0;
                        }
                        else wafer_layers[layer_number_wafer, count_x, count_z] = material;

                        break;
                }
                next_cube_position.x += scale_box_x; // change the positon in the x direction for the next block
            }
            next_cube_position.z -= scale_box_z; // change the positon in the z direction for the next block
        }
    }

    /* Materials
     * List of what numbers correspond to what material
     * 12-Silicon
     * 1-photoresist
     * 2-adhesive
     * 3-Developer
     * 4-Water
     * 5-Piranha
     * 6-BOE
     * 7-AL-etchant
     * 8- SiO2
     * 9- AL
     * 10- organic materials
     * 11- Dopant
    */
    public class Cube
    {
        public GameObject cube_game_obj;
        public int material;

        // change atributes of the block depending on what it is. Right now just color but this could be changed
        public Cube( int material)
        {
            cube_game_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Wafer.m_Collider = cube_game_obj.GetComponent<Collider>(); 
            Wafer.m_Collider.enabled = false; // Turn off collider to impove frame rate of program

            switch (material)
            {
                case 12: // Silicon
                    cube_game_obj.GetComponent<Renderer> ().material.color = Color.black;
                    break;
                case 1:// PR
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 2:// adhesive
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break;
                case 3:// Developer
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break; 
                case 4:// Water
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break;
                case 5:// Pirana
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break;
                case 6: //BOE
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break;
                case 7: //AL etchat
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.clear;
                    break;
                case 8://SiO2
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.black;
                    break;
                case 9: //AL normally silver .. but oh well
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 10: // green
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 11: // green
                    cube_game_obj.GetComponent<Renderer>().material.color = Color.blue;
                    break;
            }
        }
    }

    /* Function OnCollisionEnter(Collision collision)
     * Parameters: collision of the wafer
     * Summary: Whenever the wafer touches on of these objects, it is set to true
     * This tells me if the wafer has touched something.  This will bring up canvases 
     */
    void OnCollisionEnter(Collision collision)
    {
        string object_wafer_touching = collision.collider.tag;
        //Piranha Clean
        if (object_wafer_touching == "Piranha_Beaker") Globals.wafer_hit_piranha = true;
        if (object_wafer_touching == "Piranha_Water_Beaker") Globals.wafer_hit_piranha_water = true;

        //Dopant BHF
        if (object_wafer_touching == "BHF") Globals.wafer_hit_BHF = true;

        //BOE 
        if (object_wafer_touching == "BOE") Globals.wafer_hit_BOE = true;

        // Al Etchant
        if (object_wafer_touching == "Al_Etchant") Globals.wafer_hit_Al_Etchant = true;

        // Sonicator (PR remove)
        if (object_wafer_touching == "Acetone") Globals.wafer_hit_acetone = true;
        if (object_wafer_touching == "Propanol") Globals.wafer_hit_propanol = true;
        if (object_wafer_touching == "Sonicator_water") Globals.wafer_hit_sonicator_water = true;
        
        // Pipettes
        if (object_wafer_touching == "Pipette_Photo_Resist") Globals.wafer_photo_resist = true;
        if (object_wafer_touching == "Pipette_Adhesive") Globals.wafer_adhesive = true;

        // Spinner
        if (object_wafer_touching == "Spinner_Lid") Globals.wafer_spinner_lid = true;
        if (object_wafer_touching == "Spinner_inside") Globals.wafer_spinner_inside = true;

        // Hot plate
        if (object_wafer_touching == "Hot_plate") Globals.wafer_hit_hot_plate = true;

        //Developer
        if (object_wafer_touching == "Developer_Water_Beaker") Globals.wafer_hit_Developer_water = true;
        if (object_wafer_touching == "Developer_Beaker") Globals.wafer_hit_Developer = true;
    


        // Depreciated
        if (object_wafer_touching == "Sonicator") Globals.wafer_hit_Sonicator = true;

        // Microscope
        if (object_wafer_touching == "Microscope") Globals.wafer_hit_microscope = true;
    }

    /* Fucntion OnCollisionExit(Collision collision)
     * Parameter: Wafer collision state
     * Summary: If the wafer has stopped touching something, the flag will be set to false.
     */
    /*private void OnCollisionExit(Collision collision)
    {
        //spinner
        Globals.wafer_spinner_lid = false;
        Globals.wafer_spinner_inside = false;

        //pirahna
        Globals.wafer_hit_piranha = false;
        Globals.wafer_hit_piranha_water = false;

        // Sonicator (PR remove)
        Globals.wafer_hit_acetone = false;
        Globals.wafer_hit_propanol = false;
        Globals.wafer_hit_sonicator_water = false;

        // Hot plate
        Globals.wafer_hit_hot_plate = false;

        //Developer
       Globals.wafer_hit_Developer_water = false;
       Globals.wafer_hit_Developer = false;

        //BOE 
       Globals.wafer_hit_BOE = false;

        // Al Etchant
       Globals.wafer_hit_Al_Etchant = false;

        //Dopant BHF
        Globals.wafer_hit_BHF = false;
    }*/
}
 
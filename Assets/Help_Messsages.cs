using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO I have not checked mask 0, maks1, and oxide etch.  Also have not checked everything at the same time
public class Help_Messsages : MonoBehaviour {
    public GameObject FPS_Canvas;
    public Text Help_messages;
    public double step_count;
    public double master_step_count;
    public string str;
    public Dropdown difficulty;
    
    void Update () {
        //Debug.Log(difficulty.value);
        //Globals.difficulty = difficulty.value;
        if (Globals.difficulty == 0)
        {
            FPS_Canvas.SetActive(true);
        }
        else if (Globals.difficulty == 1)
        {
            FPS_Canvas.SetActive(false);
        }
        master_state_machine();

        //Debug.Log(str);
        Help_messages.text = str;
    }
    void master_state_machine()
    {
        switch (State_machine.master_step_count)
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
            case 7:
                { expose_mask_1(); break; }
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
            case 18:
                { expose_mask_2(); break; }
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
            case 27:
                { expose_mask_3(); break; }
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
            case 36:
                { expose_mask_4(); break; }
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
        // field_oxidizer
        if (State_machine.field_oxidizer_step_count == 1)
            str = "Go into chemical room with the wafer and click on the furnace with the reticle.";
        if ( State_machine.field_oxidizer_step_count == 2)
            str = "Fill in the settings of the furnace.  Click done to save options.  Solution: gas1=H₂, gas2=O₂, flow rate 1=6SLPM, flow rate 2=3SLPM, temp=1100C, time=90min.";
    }
    void pirahna_clean()
    {
        if ( State_machine.piranha_clean_step_count == 1)
            str = "Put the wafer into the pirahna etchant solution.";
        if ( State_machine.piranha_clean_step_count == 2)
            str = "Fill in the settings of the pirahna etchant solution.  Click done to save options. Solution: 10min.";
        if ( State_machine.piranha_clean_step_count == 3)
            str = "Put the wafer into the distilled water that is in the chemical room.";
        if ( State_machine.piranha_clean_step_count == 4)
            str = "Fill in the settings of the distilled water.  Click done to save options. Solution: 1min.";
    }
    void strip_photoresist()
    {
        //strip_photoresist
        if ( State_machine.strip_photoresist_step_count == 1)
            str = "Put the wafer in the acetone solution that is inside of the sonicator.";
        if ( State_machine.strip_photoresist_step_count == 2)
            str = "Fill in the settings of the acetone.  Click done to save options. Solution: 5min.";
        if ( State_machine.strip_photoresist_step_count == 3)
            str = "Put the wafer in the propanol solution that is inside of the sonicator.";
        if ( State_machine.strip_photoresist_step_count == 4)
            str = "Fill in the settings of the propanol.  Click done to save options. Solution: 5min.";
        if ( State_machine.strip_photoresist_step_count == 5)
            str = "Put the wafer in the distilled water that is inside of the sonicator.";
        if ( State_machine.strip_photoresist_step_count == 6)
            str = "Fill in the settings of the distilled water.  Click done to save options. Solution: 1min.";
    }
    void spin_adhesive()
    {
        // spin_adhesive
        if ( State_machine.spin_adhesive_step_count == 1)
            str = "Pick up the wafer and select the pipette that is hovering over the flask of adhesive with the reticle.";
        if ( State_machine.spin_adhesive_step_count == 3)
            str = "You have applied adhesive!  Open the spinner by selecting the lid with the reticle. Put the wafer into the spinner.";
        if ( State_machine.spin_adhesive_step_count == 4)
            str = "Close the lid of the spinner by selecting the lid of the spinner with the reticle.";
        if ( State_machine.spin_adhesive_step_count == 5)
            str = "Select the white retangular panel that is on the spinner with the reticle.";
        if ( State_machine.spin_adhesive_step_count == 6)
            str = "Fill in the settings of the spinner.  Click done to save options. Solution: Spread time = 5sec, Spread speed = 500rmp, Spin time = 30 sec, Spin speed = 1500 rmp.";
    }
    void spin_photoresist()
    {
        // spin_photoresist
        if ( State_machine.spin_photoresist_step_count == 1)
            str = "Select the pipette that is hovering over the flask of photoresist with the reticle.";
        if ( State_machine.spin_photoresist_step_count == 3)
            str = "You have applied photoresist! Open the spinner by selecting the lid with the reticle. Put the wafer into the spinner.";
        if ( State_machine.spin_photoresist_step_count == 4)
            str = "Close the lid of the spinner by selecting the lid of the spinner with the reticle.";
        if ( State_machine.spin_photoresist_step_count == 5)
            str = "Select the white retangular panel that is on the spinner with the reticle.";
        if ( State_machine.spin_photoresist_step_count == 6)
            str = "Fill in the settings of the spinner.  Click done to save options. Solution: Spread time = 5sec, Spread speed = 500rmp, Spin time = 30 sec, Spin speed = 1500 rmp.";
    }
    void soft_bake()
    {
        // soft_bake
        if ( State_machine.soft_bake_step_count == 1)
            str = "Put the wafer onto the hot plate.";
        if ( State_machine.soft_bake_step_count == 2)
            str = "Select the white retangular panel that is on the hot plate with the reticle.";
        if ( State_machine.soft_bake_step_count == 3)
            str = "Fill in the settings of the hot plate.  Click done to save options. Solution: Temperature = 100degrees, Time = 3min.";
    }
    void expose_mask_1()
    {
        // expose_mask_1
        if (State_machine.expose_mask_1_step_count == 1)
            str = "Select the mask aligner with the reticle.";
        if (State_machine.expose_mask_1_step_count == 2)
            str = "Select mask 1 (top left) with the mouse.  Then wait for the next scene to load in.";
        if (State_machine.expose_mask_1_step_count == 3)
            str = "Wait for the next scene to load in.  Then align the mask with the mask using the alignment marks.";
        if (State_machine.expose_mask_1_step_count == 4)
            str = "Fill in the settings.  Click done to save options. Solution: Time = 3sec, Expose Energy = 45, Power = 15.";
    }
    void expose_mask_2()
    {
        // expose_mask_2
        if (State_machine.expose_mask_2_step_count == 1)
            str = "Select the mask aligner with the reticle.";
        if (State_machine.expose_mask_2_step_count == 2)
            str = "Select mask 2 (top right) with the mouse.  Then wait for the next scene to load in.";
        if (State_machine.expose_mask_2_step_count == 3)
            str = "Wait for the next scene to load in.  Then align the mask with the mask using the alignment marks.";
        if (State_machine.expose_mask_2_step_count == 4)
            str = "Fill in the settings.  Click done to save options. Solution: Time = 3sec, Expose Energy = 45, Power = 15.";
    }
    void expose_mask_3()
    {
        // expose_mask_1
        if (State_machine.expose_mask_3_step_count == 1)
            str = "Select the mask aligner with the reticle.";
        if (State_machine.expose_mask_3_step_count == 2)
            str = "Select mask 3 (bottom left) with the mouse.  Then wait for the next scene to load in.";
        if (State_machine.expose_mask_3_step_count == 3)
            str = "Wait for the next scene to load in.  Then align the mask with the mask using the alignment marks.";
        if (State_machine.expose_mask_3_step_count == 4)
            str = "Fill in the settings.  Click done to save options. Solution: Time = 3sec, Expose Energy = 45, Power = 15.";
    }
    void expose_mask_4()
    {
        // expose_mask_4
        if (State_machine.expose_mask_4_step_count == 1)
            str = "Select the mask aligner with the reticle.";
        if (State_machine.expose_mask_4_step_count == 2)
            str = "Select mask 4 (bottom right) with the mouse.  Then wait for the next scene to load in.";
        if (State_machine.expose_mask_4_step_count == 3)
            str = "Wait for the next scene to load in.  Then align the mask with the mask using the alignment marks.";
        if (State_machine.expose_mask_4_step_count == 4)
            str = "Fill in the settings.  Click done to save options. Solution: Time = 3sec, Expose Energy = 45, Power = 15.";
    }
    void develop_photoresist()
    {
        if (State_machine.develop_photoresist_step_count == 1)
            str = "Put the wafer into the developer solution.";
        if (State_machine.develop_photoresist_step_count == 2)
            str = "Fill in the settings of the developer.  Click done to save options.Solution: Time = 45sec.";
        if (State_machine.develop_photoresist_step_count == 3)
            str = "Put the wafer into the distilled water next to the developer.";
        if (State_machine.develop_photoresist_step_count == 4)
            str = "Fill in the settings of the distilled water.  Click done to save options.Solution: Time = 60sec.";
    }
    void oxide_etch()
    {
        //oxide_etch
        if (State_machine.oxide_etch_step_count == 1)
            str = "Put the wafer into the silicon dioxide etchant solution.";
        if (State_machine.oxide_etch_step_count == 2)
            str = "Fill in the settings of the silicon dioxide etchant.  Click done to save options.Solution: Time = 5min.";
        if (State_machine.oxide_etch_step_count == 3)
            str = "Put the wafer into the distilled water that is in the chemical room.";
        if (State_machine.oxide_etch_step_count == 4)
            str = "Fill in the settings of the distilled water.  Click done to save options.Solution: Time = 1min.";
    }
    void dehydration_bake()
    {
        //dehydration_bake
        if (State_machine.dehydration_bake_step_count == 1)
            str = "Put the wafer onto the hot plate.";
        if (State_machine.dehydration_bake_step_count == 2)
            str = "Select the white retangular panel that is on the hot plate with the reticle.";
        if (State_machine.dehydration_bake_step_count == 3)
            str = "Fill in the settings of the hot plate.  Click done to save options. Solution: Temperature = 200degrees, Time = 5min";
        //"when using a heating pad, be sure to microwave it for 2 minutes, or until scathingly hot"-- Maddy
    }
    void spin_on_dopant()
    {
        // spin
        if (State_machine.spin_on_dopant_step_count == 2)
            str = "Select the pipette that is hovering over the flask of dopant with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 3)
            str = "You have applied dopant! Open the spinner by selecting the lid with the reticle. Put the wafer into the spinner.";
        if (State_machine.spin_on_dopant_step_count == 4)
            str = "Close the lid of the spinner by selecting the lid of the spinner with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 5)
            str = "Select the white retangular panel that is on the spinner with the reticle.";
        if ( (State_machine.spin_on_dopant_step_count == 6) || (State_machine.spin_on_dopant_step_count == 7) )
            str = "Fill in the settings of the spinner.  Click done to save options. Solution: Spread time = 0sec, Spread speed = 0rmp, Spin time = 20sec, Spin speed = 3000rmp.";

        // hot plate
        if (State_machine.spin_on_dopant_step_count == 8)
            str = "Put the wafer onto the hot plate.";
        if (State_machine.spin_on_dopant_step_count == 9)
            str = "Select the white retangular panel that is on the hot plate with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 10)
            str = "Fill in the settings of the hot plate.  Click done to save options. Solution: Temperature = 200degrees, Time = 15min";

        // furnace
        if (State_machine.spin_on_dopant_step_count == 11)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 12)
            str = "Fill in the settings of the furnace for warm-up.  Click done to save options.  Solution: gas1=N2, gas2=O2, flow rate1=10SLPM, flow rate2=3SLPM, temp=1050C,time=5min";

        //BHF
        if (State_machine.spin_on_dopant_step_count == 13)
                str = "Put the wafer into the silicon dioxide etchant solution.";
        if (State_machine.spin_on_dopant_step_count == 14)
            str = "Fill in the settings of the silicon dioxide etchant solution.  Click done to save options. Solution: 5min.";
        if (State_machine.spin_on_dopant_step_count == 15)
            str = "Put the wafer into the distilled water that is in the chemical room.";
        if (State_machine.spin_on_dopant_step_count == 16)
            str = "Fill in the settings of the distilled water.  Click done to save options. Solution: 1min.";
        if (State_machine.spin_on_dopant_step_count == 17)
            str = "Put the wafer into the silicon dioxide etchant solution.";
        if (State_machine.spin_on_dopant_step_count == 18)
            str = "Fill in the settings of the silicon dioxide etchant solution.  Click done to save options. Solution: 10min.";
        if (State_machine.spin_on_dopant_step_count == 19)
            str = "Put the wafer into the distilled water that is in the chemical room.";
        if (State_machine.spin_on_dopant_step_count == 20)
            str = "Fill in the settings of the distilled water.  Click done to save options. Solution: 1min.";

        //Anneal
        if (State_machine.spin_on_dopant_step_count == 21)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 22)
            str = "Fill in the settings of the furnace for pre-loading.  Click done to save options.  Solution: gas=N₂, flow rate=5SLPM, temp=1050C, time=10min";
        if (State_machine.spin_on_dopant_step_count == 23)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 24)
            str = "Fill in the settings of the furnace for oxidation.  Click done to save options.  Solution: gas1=O₂, gas2=H₂, flow rate1=3SLPM, flow rate2=6SLPM, temp=1100C, time=25min";
        if (State_machine.spin_on_dopant_step_count == 25)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.spin_on_dopant_step_count == 26)
            str = "Fill in the settings of the furnace for anneal.  Click done to save options.  Solution:  gas=N2, flow rate=5SLPM, temp=1100C, time=12min";

    }
    void gate_oxidation()
    {
        //gate_oxidation
        if (State_machine.gate_oxidation_step_count == 1)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.gate_oxidation_step_count == 2)
            str = "Fill in the settings of the furnace for warm-up.  Click done to save options.  Solution: gas=N₂, flow rate=5SLPM, temp=1100C, time=5min";
        if (State_machine.gate_oxidation_step_count == 3)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.gate_oxidation_step_count == 4)
            str = "Fill in the settings of the furnace for oxidation.  Click done to save options.  Solution: gas=O₂, flow rate=5SLPM, temp=1100C, time=120min";
        if (State_machine.gate_oxidation_step_count == 5)
            str = "Go into Chemical room with the wafer and click on the furnace with the reticle.";
        if (State_machine.gate_oxidation_step_count == 6)
            str = "Fill in the settings of the furnace for purge.  Click done to save options.  Solution: gas=N₂, flow rate=5SLPM, temp=1100C, time=5min";
    }
    void al_evaporation()
    {
        if (State_machine.evap_step_count == 1)
            str = "Go into Chemical room with the wafer and click on the evaporator with the reticle.";
        if (State_machine.evap_step_count == 2)
            str = "Fill in the settings of the evaporator.  Click done to save options.  Solution: gas=Al, flow rate=5SLPM, temp=1100C, time=5min";
    }
    void al_etch()
    {
        //al_etch
        if (State_machine.al_etch_step_count == 1)
            str = "Put the wafer into the Al etchant solution.";
        if (State_machine.al_etch_step_count == 2)
            str = "Fill in the settings of the Al etchant solution.  Click done to save options.Solution: Time = 4min.";
        if (State_machine.al_etch_step_count == 3)
            str = "Put the wafer into the distilled water that is in the chemical room.";
        if (State_machine.al_etch_step_count == 4)
            str = "Fill in the settings of the distilled water.  Click done to save options.Solution: Time = 1min.";
    }
}
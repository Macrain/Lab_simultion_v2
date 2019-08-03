using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class maskpositioncheck :  MonoBehaviour {

    public GameObject emptywafer;
    public GameObject mask1_glass;
    public GameObject mask2_glass;
    public GameObject mask3_glass;
    public GameObject mask4_glass;

    public GameObject mask1_pattern;
    public GameObject mask2_pattern;
    public GameObject mask3_pattern;
    public GameObject mask4_pattern;

     GameObject chosen_mask; 
	 GameObject wafer;

    //public GameObject Expose_Canvas;
    public GameObject Directional_Canvas;
    public GameObject Finished_alignment;

    public Text mask_alignment_messages;

    float round = .5f;
    float round_angle = .5f;
    bool drop = false; 
	bool dropping = false; 
	bool startdrop = false;
    string mask_name;
    bool flag_angle;
    bool flag_xy;

	void Start () {
        //Globals.mask_mini_game = true;
        Globals.mask_mini_game = false;
        flag_xy = false;
        flag_angle = false;

        if (Globals.mask_mini_game == true)
        {
            Globals.difficulty = 0;
            Globals.last_mask = 1;
            maskchoosing.chosen = 2;
        }

        //Expose_Canvas.SetActive(false);
        Directional_Canvas.SetActive(true);
        Finished_alignment.SetActive(false);
        switch (maskchoosing.chosen)
        {
            case 1:
                mask1_glass.SetActive(true); mask2_glass.SetActive(false); mask3_glass.SetActive(false); mask4_glass.SetActive(false);
                chosen_mask = mask1_glass;
                break;
            case 2:
                mask1_glass.SetActive(false); mask2_glass.SetActive(true); mask3_glass.SetActive(false); mask4_glass.SetActive(false); 
                chosen_mask = mask2_glass;
                break;
            case 3:
                mask1_glass.SetActive(false); mask2_glass.SetActive(false); mask3_glass.SetActive(true); mask4_glass.SetActive(false); 
                chosen_mask = mask3_glass;
                break;
            case 4:
                mask1_glass.SetActive(false); mask2_glass.SetActive(false); mask3_glass.SetActive(false); mask4_glass.SetActive(true); 
                chosen_mask = mask4_glass;
                break;
        }

        switch (Globals.last_mask)
        {
            
            case 0:
                mask1_pattern.SetActive(false); mask2_pattern.SetActive(false); mask3_pattern.SetActive(false); mask4_pattern.SetActive(false);
                wafer = emptywafer;
                break;
            case 1:
                mask1_pattern.SetActive(true); mask2_pattern.SetActive(false); mask3_pattern.SetActive(false); mask4_pattern.SetActive(false);
                wafer = mask1_pattern;
                break;
            case 2:
                mask1_pattern.SetActive(false); mask2_pattern.SetActive(true); mask3_pattern.SetActive(false); mask4_pattern.SetActive(false);
                wafer = mask2_pattern;
                break;
            case 3:
                mask1_pattern.SetActive(false); mask2_pattern.SetActive(false); mask3_pattern.SetActive(true); mask4_pattern.SetActive(false);
                wafer = mask3_pattern;
                break;
            case 4:
                mask1_pattern.SetActive(false); mask2_pattern.SetActive(false); mask3_pattern.SetActive(false); mask4_pattern.SetActive(true);
                wafer = mask4_pattern;
                break;
        }

        Globals.last_mask = maskchoosing.chosen;
        Globals.mask_aligned = false;
    }

	void Update () {
        if (Globals.mask_aligned == false)
        {
            //Debug.Log(Mathf.Abs(chosen_mask.transform.rotation.eulerAngles.x - wafer.transform.rotation.eulerAngles.x));
            if ((maskchoosing.chosen != 1))
            {
                if (((Mathf.Abs(chosen_mask.transform.position.x - wafer.transform.position.x)) < round) && ((Mathf.Abs(chosen_mask.transform.position.y - wafer.transform.position.y)) < round))
                {
                    flag_xy = true;
                    //Debug.Log("x y");
                }
                else
                    flag_xy = false;

                if (Mathf.Abs(chosen_mask.transform.rotation.eulerAngles.x - wafer.transform.rotation.eulerAngles.x) < round_angle)
                {
                    flag_angle = true;
                    //Debug.Log("angle");
                }
                else
                    flag_angle = false;

                if (flag_angle && flag_xy)
                {
                    Globals.mask_aligned = true;
                    //Expose_Canvas.SetActive(true);
                    mask_alignment_messages.text = "Click on the button below to fill in the alignment exposure settings";
                }
            }

            
            else if ((maskchoosing.chosen == 1))
            {
                Globals.mask_aligned = true;
                //Expose_Canvas.SetActive(true);
                mask_alignment_messages.text = "Mask 1 does not need to be aligned because the surface of the wafer has not been changed so there are no alignment marks.  Click on the button below to fill in the alignment exposure settings";

                //Finished_alignment.SetActive(true);
                //Directional_Canvas.SetActive(false);
            }
        }
        else if (Globals.mask_aligned == true)
            if (maskchoosing.chosen != 1)
                mask_alignment_messages.text = "Click on the button below to fill in the alignment exposure settings";
            else if (maskchoosing.chosen == 1)
                mask_alignment_messages.text = mask_alignment_messages.text = "Mask 1 does not need to be aligned because the surface of the wafer has not been changed so there are no alignment marks.  Click on the button below to fill in the alignment exposure settings";

    }
}
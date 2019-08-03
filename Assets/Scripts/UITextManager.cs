using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITextManager : MonoBehaviour {
    // first door to be opened when wiping the booties
    GameObject firstDoor;
    // Inventory
	public Text hoodText;
	public Text hairnetText;
	public Text bootsText;
    public Text glovesText;
    public Text overcoatText;
    public Text bootiesText;
    public Text safetyGogglesText;
    public GameObject next_scene_button;

    //text for messages at bottom of screen
    public Text messageBox;
    // text to display what order
    public Text displayPickupOrder;
    // if player tries to equip an item that cannot be equipped yet
    // make modifier function that takes in string (name of item)
    public Text equipErrorText;
    // for completion of collecting all items 
    public Text allCollectedText;

    // bools for what difficulty
    public bool easymode;
    public bool hardmode;

    //private booleans to determine what is equipped
    private bool doorCanOpen = false;
    public bool floormat = false;
    private bool hood = false;
    private bool hairnet = false;
    private bool booties = false; // shoe coverings at beginning
    private bool boots = false;
    private bool gloves = false;
    private bool overcoat = false;
    private bool safetyGoggles = false;

    public Button button_done;
    public Button button_done_field;

    public static bool finished_mini_game_suit_up;

    public float waitTime = 5; //Seconds to read the text

    // Use this for initialization
    void Start () {
        // set all of the text elements to disabled so they only show up on the UI when enabled
        firstDoor = GameObject.Find("firstdoor");
        hoodText.enabled = false;
		hairnetText.enabled = false;
		bootsText.enabled = false;
        glovesText.enabled = false;
        overcoatText.enabled = false;
        bootiesText.enabled = false;
        safetyGogglesText.enabled = false;
        displayPickupOrder.enabled = false;
        messageBox.enabled = false;
        equipErrorText.enabled = false;
        allCollectedText.enabled = false;
        finished_mini_game_suit_up = false;

        next_scene_button.SetActive(false);
        button_done = button_done_field.GetComponent<Button>();
        button_done.onClick.AddListener(button_done_TaskOnClick);
    }

    public void button_done_TaskOnClick()
    {
        
        if (Globals.suit_up_mini_game == true)
            SceneManager.LoadScene("Suit_up");
        else
        {
            UITextManager.finished_mini_game_suit_up = true;
            SceneManager.LoadScene("PR_lab");

        }
            
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("h") && Globals.debug)
        {
            allCollectedText.enabled = true;
            next_scene_button.SetActive(true);
            finished_mini_game_suit_up = true;
        }
            

        if (Globals.difficulty == 0)
        {
            easymode = true;
            hardmode = false;
        }
        else if (Globals.difficulty == 1)
        {
            easymode = false;
            hardmode = true;
        }

        if (easymode) {
            displayPickupOrder.enabled = true;
        }
        else if (hardmode)
        {
            displayPickupOrder.enabled = false;
        }
        if (doorCanOpen) {
            firstDoor.SetActive(false);
        }

        if (!hardmode) {
            if (booties) {
                bootiesText.enabled = true;
            }
            if (hood) {
                hoodText.enabled = true;
            }
            if (hairnet) {
                hairnetText.enabled = true;
            }
            if (gloves)
            {
                glovesText.enabled = true;
            }
            if (overcoat)
            {
                overcoatText.enabled = true;
            }
            if (boots)
            {
                bootsText.enabled = true;
            }
            if (safetyGoggles)
            {
                safetyGogglesText.enabled = true;
            }
            
        }
        if (isEverythingEquipped()) {
            allCollectedText.enabled = true;
            next_scene_button.SetActive(true);
            finished_mini_game_suit_up = true;
}
    }

    bool isEverythingEquipped() {
        if (booties && hood && hairnet && gloves && overcoat && boots && safetyGoggles) {
            return true;
        } else { return false; }
    }
    public void setErrorMessage(string errorMessage) {
        clearErrorMessage();
        equipErrorText.text = errorMessage;
    }

    public void displayErrorMessage() {
        if (equipErrorText.enabled == false) {
            equipErrorText.enabled = true;
            Invoke("undisplayErrorMessage", waitTime);
        }
    }

    void undisplayErrorMessage() {
        equipErrorText.enabled = false;
    }

    void clearErrorMessage() {
        equipErrorText.text = "";
    }

    public void SetMessageInfo(string message) {
        messageBox.text = message;
    }

    public void DisplayMessageInfo()
    {
        if (messageBox.enabled == false) {
            messageBox.enabled = true;
            Invoke("undisplayPickupInfo", 1);
            Debug.Log("Called display pickupinfo");
        }
    }
    public void undisplayPickupInfo()
    {
        Debug.Log("Called display unpickupinfo");
        messageBox.text = "";
        messageBox.enabled = false;
    }

    /* CHECKS for what has been picked up
    public bool doorCanOpen;
    public bool hood;
    public bool hairnet;
    public bool booties; // shoe coverings at beginning
    public bool boots;
    public bool gloves;
    public bool overcoat;
    public bool safetyGoggles; */

    public void setDoorCanOpen(bool change) {
        doorCanOpen = change;
    }

    public bool isHood()
    {
        return hood;
    }
    public void setHood(bool hood)
    {
        this.hood = hood;
    }
    public bool isHairnet()
    {
        return hairnet;
    }
    public void setHairnet(bool hairnet)
    {
        this.hairnet = hairnet;
    }
    public bool isBooties()
    {
        return booties;
    }
    public void setBooties(bool booties)
    {
        this.booties = booties;
    }
    public bool isBoots()
    {
        return boots;
    }
    public void setBoots(bool boots)
    {
        this.boots = boots;
    }
    public bool isGloves()
    {
        return gloves;
    }
    public void setGloves(bool gloves)
    {
        this.gloves = gloves;
    }
    public bool isOvercoat()
    {
        return overcoat;
    }
    public void setOvercoat(bool overcoat)
    {
        this.overcoat = overcoat;
    }
    public bool isSafetyGoggles()
    {
        return safetyGoggles;
    }
    public void setSafetyGoggles(bool safetyGoggles)
    {
        this.safetyGoggles = safetyGoggles;
    }

}

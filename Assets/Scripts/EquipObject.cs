using System.Collections;
using UnityEngine;

public class EquipObject : MonoBehaviour {

	// Use this for initialization

	public GameObject item; //the cube itself
	public GameObject tempParent;
	public Transform guide;
	public GameObject target;
	private Vector3 playerpos;
	float pickupdist = 3f;
	public string Interact = "f";
	float timer = 1.0f; //This implies a delay of 2 seconds.
    bool itemUsesGravity = true;
    public bool activated = false;
	public AudioSource audio;

    void Start () {
        activated = false;
		item = gameObject;
        if (item.name != "floormat") {
            item.GetComponent<Rigidbody>().useGravity = itemUsesGravity;
        }
		tempParent = GameObject.Find ("Guide");
		guide = GameObject.Find ("Guide").GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		target = raycater_bunnySuit.currObject; //access public variable from Raycaster Script
		playerpos = GameObject.Find("Player").transform.position;
		float dist = Vector3.Distance (item.transform.position, playerpos);

        if (target == item && dist <= pickupdist) {
            // activated isnt being chcked correctly
            if (item.name == "floormat" && !activated) {
                GameObject.Find("UI").GetComponent<UITextManager>().SetMessageInfo("Press " + Interact + " to wipe your shoes on the " + target.name);
            }
            else {
                GameObject.Find("UI").GetComponent<UITextManager>().SetMessageInfo("Press " + Interact + " to pick up " + target.name);
            }
            GameObject.Find("UI").GetComponent<UITextManager>().DisplayMessageInfo();
        }
        

		if (Input.GetKeyDown (Interact) && target == item && dist <= pickupdist) {
            /* Order:
         * booties, DOOR
         * gloves can be put on at any point past here
         * hairnet
         * hood
         * overcoat
         * boots
         * goggles
         */

            switch (item.name)
            {
                case "floormat":
                    GameObject.Find("UI").GetComponent<UITextManager>().floormat = true;
                    break;
                case "Booties":
                    if (GameObject.Find("UI").GetComponent<UITextManager>().floormat)
                    {
                        GameObject.Find("UI").GetComponent<UITextManager>().setBooties(true);
                        GameObject.Find("UI").GetComponent<UITextManager>().setDoorCanOpen(true);
                        deactivateItem();
                    }
                    else {
                        // if floormat has not been activated
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Before you can equip the booties, you must \n" + 
                            "wipe your dirty shoes on the sticky floormat.");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Hairnet":
                    // if booties are equipped
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isBooties()) {
                        GameObject.Find("UI").GetComponent<UITextManager>().setHairnet(true);
                        deactivateItem();
                    }
                    else { // show error message
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip HAIRNET yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Hood":
                    // if hairnet is equipped
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isHairnet())
                    {
                        GameObject.Find("UI").GetComponent<UITextManager>().setHood(true);
                        deactivateItem();
                    }
                    else {
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip HOOD yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Gloves":
                    // if booties
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isBooties()) {
                        GameObject.Find("UI").GetComponent<UITextManager>().setGloves(true);
                        deactivateItem();
                    }
                    else {
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip GLOVES yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Overcoat":
                    // if booties, harinet, HOOD
                    // quick and dirty just check for hood
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isHood()) {
                        GameObject.Find("UI").GetComponent<UITextManager>().setOvercoat(true);
                        deactivateItem();
                    }
                    else { // error message
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip OVERCOAT yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Boots":
                    // if OVERCOAT
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isOvercoat()) {
                        GameObject.Find("UI").GetComponent<UITextManager>().setBoots(true);
                        deactivateItem();
                    }
                    else { // ERROR
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip BOOTS yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                case "Goggles":
                    // if hood and overcoat are on
                    if (GameObject.Find("UI").GetComponent<UITextManager>().isOvercoat()) {
                        GameObject.Find("UI").GetComponent<UITextManager>().setSafetyGoggles(true);
                        deactivateItem();
                    }
                    else { // ERROR
                        GameObject.Find("UI").GetComponent<UITextManager>().setErrorMessage("Cannot equip GOGGLES yet");
                        GameObject.Find("UI").GetComponent<UITextManager>().displayErrorMessage();
                    }
                    break;
                default:
                    break;
            }

            // FIXME THIS BLOODY THING CAUSED THE THINGS TO DESTROY WHY WHY WHY
            // StartCoroutine("ExecuteAfterTime");
		}
			
	}

    void deactivateItem() {
        audio.Play();
        activated = true;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<MeshRenderer>().enabled = false;
        item.GetComponent<PopupText>().popupText.enabled = false; //accessing from Popuptext script
        item.GetComponent<PopupText>().popupImage.enabled = false; //accessing from Popuptext script
        
    }

    IEnumerator ExecuteAfterTime()
	{
		yield return new WaitForSeconds(timer);
		Destroy (gameObject);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Creates floating text when you look at object. Only works on objects that can be seen by raycast

public class PopupText : MonoBehaviour {

	// Use this for initialization
	public string popupString; // renamed to popupstring
	public Text popupText;  // renamed to popup
	public Image popupImage; // renamed to popup
	public float fadeInTime = 5f;
	public float fadeOutTime = 1f;
	public bool displayMessage = false;
	private GameObject item; //the object I want to mouse over
	public bool inRange; //access textcollider script
	public Color customcolor = new Color(0,244,255,255);


	void Start () {
        //myText = GameObject.Find ("Popup").GetComponent<Text> (); //get Text componenent from Popup
        //accessing trigger collider from script PopupTextCollider
        popupText.text = popupString;
        displayMessage = false;
		popupText.color = Color.clear;
		popupImage.color = Color.clear;

	}

	// Update is called once per frame
	void Update () {
		//inRange = GameObject.Find ("PopupCollider").GetComponent<PopupTextCollider>().triggerCollider;
		if(raycater_bunnySuit.currObject == gameObject){
			displayMessage = true;
		}
		else{
			displayMessage = false;
		}
		FadeText();
	}

	void FadeText(){
		if(displayMessage){
			popupText.text = popupString;
			popupText.color = Color.Lerp (popupText.color, Color.white, fadeInTime * Time.deltaTime); //make the text visible
			popupImage.color = Color.Lerp (popupImage.color,customcolor, fadeInTime * Time.deltaTime);
		}
		else{
			popupText.color = Color.Lerp (popupText.color, Color.clear, fadeOutTime * Time.deltaTime); //make the text clear
			popupImage.color = Color.Lerp (popupImage.color, Color.clear, fadeOutTime * Time.deltaTime);
		}
	}
}

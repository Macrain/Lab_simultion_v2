using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finished_Game_canvas_script : MonoBehaviour {

    public Button button_done_field;
    public Button button_done;
    
    public GameObject finsihed_game_Canvas;

    void Start()
    {
        button_done = button_done_field.GetComponent<Button>();
        button_done.onClick.AddListener(button_done_TaskOnClick); // create functions
    }

    void button_done_TaskOnClick() // when you click on the done button
    {
        finsihed_game_Canvas.SetActive(false); // turn the canvas off

        if (Globals.mask_mini_game == true)
            SceneManager.LoadScene("Maskchoose");
        else if (Globals.mask_mini_game == false)
            SceneManager.LoadScene("Suit_up");
    }

}

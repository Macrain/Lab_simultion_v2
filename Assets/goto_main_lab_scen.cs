using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goto_main_lab_scen : MonoBehaviour {

    public Button button_done;
    public Button button_done_field;
    

    void Start () {
        button_done = button_done_field.GetComponent<Button>();
        button_done.onClick.AddListener(button_done_TaskOnClick);
    }
    void button_done_TaskOnClick()
    {
        SceneManager.LoadScene("PR_lab");
    }    
}

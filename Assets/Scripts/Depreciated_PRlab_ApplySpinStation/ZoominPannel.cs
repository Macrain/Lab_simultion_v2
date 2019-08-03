using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoominPannel : MonoBehaviour {
    public int speed = 2;
    public int size;
    public Camera m_OrthographicCamera;
    public static int controlPannel_Clicked;
    // Use this for initialization
    void Start() {
        controlPannel_Clicked = 0;
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnMouseDown()
    {   
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.green);
        controlPannel_Clicked = 1;
    }
}

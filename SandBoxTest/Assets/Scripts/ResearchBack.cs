using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchBack : MonoBehaviour
{
    public Canvas main;
    public Canvas pause;
    public Canvas research;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && research.enabled == true)
        {
            Time.timeScale = 1f;
            main.enabled = true;
            pause.enabled = true;
            research.enabled = false;
        }
        else if(research.enabled == true) 
        {
            Time.timeScale = 0f;
        }
    }
}

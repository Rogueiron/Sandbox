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
        Time.timeScale = 0f;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            main.enabled = true;
            pause.enabled = true;
            research.enabled = false;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Canvas canvas;
    private bool Paused = false;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            Paused = true;
            Time.timeScale = 0f;
            canvas.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            Paused = false;
            Time.timeScale = 1;
            canvas.enabled = false;
        }
    }
}

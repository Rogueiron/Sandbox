using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Canvas canvas;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) 
        {
            
            canvas.enabled = true;
            Time.timeScale = 0f;
        }
        else
        {
            
            canvas.enabled = false;
            Time.timeScale = 1f;
        }

    }
}

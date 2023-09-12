using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) 
        {
            Time.timeScale = 0f;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
        
    }
}

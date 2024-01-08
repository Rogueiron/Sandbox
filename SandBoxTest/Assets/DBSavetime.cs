using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBSavetime : MonoBehaviour
{
    public Canvas main;
    public Canvas pause;
    public Canvas DB;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && DB.enabled == true)
        {
            Time.timeScale = 1f;
            main.enabled = true;
            pause.enabled = true;
            DB.enabled = false;
        }
        else if (DB.enabled == true)
        {
            Time.timeScale = 0f;
        }
    }

}


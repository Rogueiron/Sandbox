using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Storage;

public class CompleteLevel : MonoBehaviour
{
    public void NextLevel()
    {
        Debug.Log("Pressed");
        if (WoodStorage >= 1 && IronStorage >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Not enough");
        }
        
    }
}

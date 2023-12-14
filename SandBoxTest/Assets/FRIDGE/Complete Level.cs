using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Storage;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private int wood;
    [SerializeField] private int iron;

    public void NextLevel()
    {
        Debug.Log("Pressed");
        if (WoodStorage >= wood && IronStorage >= iron)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Not enough");
        }
        
    }
}

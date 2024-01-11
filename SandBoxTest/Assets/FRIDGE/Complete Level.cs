using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Storage;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] public int wood;
    [SerializeField] public int iron;

    // When material cost is met and the button is pressed start next level
    public void NextLevel()
    {
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

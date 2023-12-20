using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    void Update()
    {
        CheckEnd();
    }

    private void CheckEnd()
    {
        
        if(!GameObject.FindWithTag("TownCastle"))
        {
            SceneManager.LoadScene("FailedGame");
        }
    }
}
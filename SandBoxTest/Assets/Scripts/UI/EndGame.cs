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
        // Checks if player lost their castle, sends to failed game if so
        if(GameObject.FindWithTag("TownCastle"))
        {
            SceneManager.LoadScene("FailedGame");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void startonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void newsaveonClick()
    {
        SceneManager.LoadScene("newSave");
    }
    public void loadsaveonClick()
    {
        SceneManager.LoadScene("SaveScene");
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void menuonClick()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}

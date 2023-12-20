using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void startonClick()
    {
        // Goes into the game
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        // Leaves the application
        Application.Quit();
    }
    public void menuonClick()
    {
        // Returns the win or lost to the main menu
        SceneManager.LoadScene("MainMenu");
    }
    public void tutorialonClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour

{
    public GameObject DB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void newsaveonClick()
    {
        SceneManager.LoadScene("newsave");
    }
    public void saveonClick()
    {
        
    }

    public void loadonClick()
    {
        SceneManager.LoadScene("saveselect");
    }
}

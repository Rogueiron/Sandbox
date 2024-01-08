using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;
    public new string name;
    private GameObject Database;


    public void Start()
    {
        GameObject.FindGameObjectWithTag("Database").GetComponent<InsertIntoDB>().Building(this.gameObject);
    }

    private void Update()
    {
        die();
    }

    // Removes gameObject when health becomes zero
    private void die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnSave()
    {
        if(gameObject.tag == "Unit")
        {
            Database = GameObject.FindGameObjectWithTag("Database");
            Database.GetComponent<InsertIntoDB>().Units(gameObject);
        }
        else if (gameObject.tag == "Building")
        {
            Database = GameObject.FindGameObjectWithTag("Database");
            Database.GetComponent<InsertIntoDB>().Building(gameObject);
        }
    }



}

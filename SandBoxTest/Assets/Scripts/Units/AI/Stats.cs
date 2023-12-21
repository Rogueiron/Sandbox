using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;
    public new string name;

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
}

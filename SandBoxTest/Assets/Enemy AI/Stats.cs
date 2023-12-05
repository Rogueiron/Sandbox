using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;

    private void Update()
    {
        die();
    }

    private void die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

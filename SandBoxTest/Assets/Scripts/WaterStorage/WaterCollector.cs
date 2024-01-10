using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaterStorage;

public class WaterCollector : MonoBehaviour
{
    [SerializeField] private float timer;
    // Update is called once per frame
    void FixedUpdate()
    {
        // if a water pump is made start collecting water every second
        if (timer <= 0)
        {
            Waterstorage += 1;
            timer = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

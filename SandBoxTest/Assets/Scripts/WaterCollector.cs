using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class WaterCollector : MonoBehaviour
{
    public float timer = 1f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            WaterStorage += 1;
            Debug.Log(WaterStorage);
            timer = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class Research : MonoBehaviour
{
    private float timer = 2;
    void Update()
    {
        if(timer <= 0)
        {
            researchStorage += 1;
            timer = 2;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }
}

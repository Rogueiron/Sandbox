using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorage : MonoBehaviour
{
    public static int Waterstorage;
    public static int MaxwaterStorage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //used to make water storage and has max storage
        if (Waterstorage > MaxwaterStorage)
        {
            Waterstorage = MaxwaterStorage;
        }
        
    }
}

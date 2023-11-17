using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Storage;
using static WaterStorage;

public class ResourceAdjustmentUI : MonoBehaviour
{
    [SerializeField] int resource;

    // Update is called once per frame
    void Update()
    {
        // wood
        if (resource == 0)
        {
            if (Storage.WoodStorage > 100)
            {
                
            }
        }
        // Iron
        else if(resource == 1)
        {
            if (Storage.IronStorage > 100)
            {

            }
        }
        // water
        else if (resource == 2)
        {
            if (Waterstorage > 100)
            {

            }
        }
        // coal
        else if (resource == 3)
        {
            if (Storage.CoalStorage > 300)
            {

            }
        }
    }
}

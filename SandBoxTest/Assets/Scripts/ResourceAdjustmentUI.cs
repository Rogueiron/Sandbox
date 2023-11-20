using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Storage;
using static WaterStorage;

public class ResourceAdjustmentUI : MonoBehaviour
{
    [SerializeField] int resource;
    [SerializeField] GameObject full;
    [SerializeField] GameObject med;
    [SerializeField] GameObject low;


    // Update is called once per frame
    void Update()
    {
        // wood
        if (resource == 0)
        {
            if (Storage.WoodStorage >= 100)
            {
                full.SetActive(true);
                med.SetActive(false);
                low.SetActive(false);
            }
            else if (Storage.WoodStorage >= 50)
            {
                full.SetActive(false);
                med.SetActive(true);
                low.SetActive(false);
            }
            else if (Storage.WoodStorage >= 25)
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(true);
            }
            else
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(false);
            }
        }
        // Iron
        else if(resource == 1)
        {
            if (Storage.IronStorage >= 100)
            {
                full.SetActive(true);
                med.SetActive(false);
                low.SetActive(false);
            }
            else if (Storage.IronStorage >= 50)
            {
                full.SetActive(false);
                med.SetActive(true);
                low.SetActive(false);
            }
            else if (Storage.IronStorage >= 25)
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(true);
            }
            else
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(false);
            }
        }
        // water
        else if (resource == 2)
        {
            if (Waterstorage >= 100)
            {
                full.SetActive(true);
                med.SetActive(false);
                low.SetActive(false);
            }
            else if (Waterstorage >= 50)
            {
                full.SetActive(false);
                med.SetActive(true);
                low.SetActive(false);
            }
            else if (Waterstorage >= 25)
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(true);
            }
            else
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(false);
            }
        }
        // coal
        else if (resource == 3)
        {
            if (Storage.CoalStorage >= 300)
            {
                full.SetActive(true);
                med.SetActive(false);
                low.SetActive(false);
            }
            else if (Storage.CoalStorage >= 100)
            {
                full.SetActive(false);
                med.SetActive(true);
                low.SetActive(false);
            }
            else if (Storage.CoalStorage >= 25)
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(true);
            }
            else
            {
                full.SetActive(false);
                med.SetActive(false);
                low.SetActive(false);
            }
        }
    }
}

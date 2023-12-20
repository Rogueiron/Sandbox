using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class BuildIng : MonoBehaviour
{
    public GameObject building;
    [SerializeField] private int woodsNeeded;
    [SerializeField] private int ironNeeded;
    Storage storage;
    public void build()
    {
        if (WoodStorage >= woodsNeeded && IronStorage >= ironNeeded)
        {
            Instantiate(building);
            WoodStorage -= woodsNeeded;
            IronStorage -= ironNeeded;
        }
    }
}

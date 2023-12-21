using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class BuildIng : MonoBehaviour
{
    public GameObject building;
    public int woodsNeeded;
    public int ironNeeded;
    Storage storage;
    public void build()
    {
        //when build runs check to see if it has the cost to build then place building
        if (WoodStorage >= woodsNeeded && IronStorage >= ironNeeded)
        {
            Instantiate(building);
            WoodStorage -= woodsNeeded;
            IronStorage -= ironNeeded;
        }
    }
}

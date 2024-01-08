using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;
using static WaterStorage;

public class UnitMaker : MonoBehaviour
{
    public Canvas canvas;

    public void makeunit(int woodsNeeded, int ironNeeded,int waterNeeded, Vector3 spawnLocation, GameObject unitToSpawn, Quaternion spawnRoto)
    {
        WoodStorage -= woodsNeeded;
        IronStorage -= ironNeeded;
        Waterstorage -= waterNeeded;
        Instantiate(unitToSpawn, spawnLocation, spawnRoto);
        Population += 1;

    }
    public void ShowUi()
    {
        canvas.enabled = true;
    }
}

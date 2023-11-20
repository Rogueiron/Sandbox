using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class UnitMaker : MonoBehaviour
{
    public Canvas canvas;

    public void makeunit(int woodsNeeded, int ironNeeded, Vector3 spawnLocation, GameObject unitToSpawn, Quaternion spawnRoto
        )
    {
        WoodStorage -= woodsNeeded;
        IronStorage -= ironNeeded;
        Instantiate(unitToSpawn, spawnLocation, spawnRoto);
    }
    public void ShowUi()
    {
        canvas.enabled = true;
    }
}

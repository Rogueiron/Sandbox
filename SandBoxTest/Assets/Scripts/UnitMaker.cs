using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class UnitMaker : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

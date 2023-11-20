using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class UnitToMake : MonoBehaviour
{
    [SerializeField] int woodCost;
    [SerializeField] int ironCost;
    [SerializeField] Vector3 spawnLocation = new Vector3(0, 0, 0);
    [SerializeField] Quaternion spawnRotations = new Quaternion(0, 0, 0, 0);
    [SerializeField] GameObject unitToSpawn;
    public GameObject maker;

    public int getWoodCost()
    {
        return woodCost;
    }
    public int getIronCost()
    {
        return ironCost;
    }

    public void Make()
    {
        if (ironCost <= IronStorage && woodCost <= WoodStorage)
        {
            spawnLocation = maker.transform.GetChild(1).transform.position;
            maker.GetComponent<UnitMaker>().makeunit(woodCost, ironCost, spawnLocation, unitToSpawn, spawnRotations);
        }
    }

}

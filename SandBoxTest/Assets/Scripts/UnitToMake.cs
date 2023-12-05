using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class UnitToMake : MonoBehaviour
{
    [SerializeField] int woodCost;
    [SerializeField] int ironCost;
    public Vector3 spawnLocation = new Vector3(0, 0, 0);
    [SerializeField] Quaternion spawnRotations = new Quaternion(0, 0, 0, 0);
    [SerializeField] GameObject unitToSpawn;
    [SerializeField] GameObject maker;

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
        if (ironCost <= IronStorage && woodCost <= WoodStorage && Population < PopCapStorage)
        {
            spawnLocation = maker.transform.GetChild(1).transform.position;
            maker.GetComponent<UnitMaker>().makeunit(woodCost, ironCost, spawnLocation, unitToSpawn, spawnRotations);
        }
    }

}

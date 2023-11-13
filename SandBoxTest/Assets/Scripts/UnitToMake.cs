using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitToMake : MonoBehaviour
{
    [SerializeField] int woodCost;
    [SerializeField] int ironCost;
    [SerializeField] Vector3 spawnLocation = new Vector3(2, 2, 0);
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
        spawnLocation = maker.GetComponent<Transform>().transform.position;
        maker.GetComponent<UnitMaker>().makeunit(woodCost, ironCost, spawnLocation, unitToSpawn, spawnRotations);
    }

}

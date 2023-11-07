using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static Storage;

public class GoToNearestResource : MonoBehaviour
{
    public GameObject targetOBJ;
    public GameObject storageManager;

    public int storage;
    public int maxStorage = 2;

    public float harvestTime, harvestTimeReset = 30;

    public bool selected = false;
    public bool resourceWasSelected = false;
    public bool empty = true;

    public NavMeshAgent navigation;

    public string tag;

    private void Update()
    {
        if (storage < maxStorage)
        {
            GetClosestResource();
        }
        else
        {
            Store();
        }
        
    } 

    private void OnTriggerStay(Collider other)
    {
        if(storage < maxStorage && other.gameObject.CompareTag(tag))
        {
            if(navigation.remainingDistance <= 1)
            {
                navigation.destination = this.transform.position;
            }
            harvestTime -= Time.deltaTime;
            if (harvestTime <= 0)
            {
                Destroy(targetOBJ);
                harvestTime = harvestTimeReset;
                storage += 1;
            }
        }
        if (storage >= 1 && other.gameObject.CompareTag("Storage"))
        {
            storage -= 1;
            Wood += 5;

        }
    }

    private void GetClosestResource()
    {
        if (targetOBJ == null || !targetOBJ.gameObject.CompareTag(tag))
        {
            targetOBJ = GameObject.FindGameObjectWithTag(tag);
        }

        navigation.destination = targetOBJ.transform.position;
    }

    private void Store()
    {
        targetOBJ = GameObject.FindGameObjectWithTag("Storage");

        navigation.destination = targetOBJ.transform.position;
    }

}

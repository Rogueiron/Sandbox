using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
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

    List<GameObject> StoreResource = new();

    Queue<GameObject> StoreResourceQueue = new();

    GameObject resorce;

    public string TAG;

    private void Start()
    {
        storageManager = GameObject.FindGameObjectWithTag("StorageManager");
        foreach(GameObject Resoure in GameObject.FindGameObjectsWithTag(TAG))
        {
            StoreResource.Add(Resoure);
        }
    }

    private void Update()
    {
        if (storage < maxStorage)
        {
            resorce = GetClosestResource();
            targetOBJ = resorce;
            navigation.destination = targetOBJ.transform.position;
        }
        else
        {
            Store();
        }
        
    } 

    private void OnTriggerStay(Collider other)
    {
        if(storage < maxStorage && other.gameObject.CompareTag(TAG))
        {
            if(navigation.remainingDistance <= 1)
            {
                navigation.destination = this.transform.position;
            }
            harvestTime -= Time.deltaTime;
            if (harvestTime <= 0)
            {
                Destroy(targetOBJ);
                StoreResourceQueue.Dequeue();
                StoreResource.Remove(targetOBJ);
                harvestTime = harvestTimeReset;
                storage += 1;
            }
        }
        if (storage >= 1 && other.gameObject.CompareTag("Storage"))
        {
            storage -= 1;
            if(TAG == "Wood")
            {
                WoodStorage += 10;
            }
            else if(TAG == "Iron")
            {
                IronStorage += 5;
            }
        }
    }

    private GameObject GetClosestResource()
    {
        List<GameObject> queueitems = StoreResource.OrderBy(storage => Vector3.Distance(transform.position, storage.transform.position)).ToList();
        foreach(GameObject item in queueitems) 
        { 
            StoreResourceQueue.Enqueue(item);
        }
        return StoreResourceQueue.ToArray()[1];
        
    }

    private void Store()
    {
        targetOBJ = GameObject.FindGameObjectWithTag("Storage");

        navigation.destination = targetOBJ.transform.position;
    }

}

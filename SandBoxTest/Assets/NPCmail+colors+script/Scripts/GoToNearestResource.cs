using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

    public GameObject nextResource;

    public int storage;
    public int maxStorage;

    public float harvestTime, harvestTimeReset = 15;

    public NavMeshAgent navigation;

    public List<GameObject> StoreResource = new();

    Queue<GameObject> StoreResourceQueue = new();

    private float timer = 5;

    public string TAG;

    private void Start()
    {
        storageManager = GameObject.FindGameObjectWithTag("StorageManager");
        restart();
        StoreResourceQueue = GetResourceQueue();
        targetOBJ = StoreResourceQueue.Dequeue();
        navigation.destination = targetOBJ.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(storage < maxStorage && other.gameObject.CompareTag(TAG))
        {
            harvestTime -= Time.deltaTime;
            if (harvestTime <= 0 && storage != maxStorage -1)
            {
                Destroy(targetOBJ);
                harvestTime = harvestTimeReset;
                storage += 1;
                restart();
                nextResource = StoreResourceQueue.Dequeue();
                targetOBJ = nextResource;
                StoreResource.Remove(targetOBJ);
                navigation.destination = targetOBJ.transform.position;
            }
            else if(harvestTime <=0)
            {
                Destroy(targetOBJ);
                harvestTime = harvestTimeReset;
                storage += 1;
                if (storage >= maxStorage)
                    Store();

            }
        }
        else if (storage >= 1 && other.gameObject.CompareTag("Storage"))
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
        else if(storage == 0 && targetOBJ == other.gameObject.CompareTag("Storage") && timer <= 0)
        {
            timer = 5;
            restart();
            nextResource = StoreResourceQueue.Dequeue();
            targetOBJ = nextResource;
            StoreResource.Remove(targetOBJ);
            navigation.destination = targetOBJ.transform.position;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(storage >= maxStorage)
            Store();
    }

    private Queue<GameObject> GetResourceQueue()
    {
        Queue<GameObject> resources = new();
        StoreResource.OrderBy(storage => Vector3.Distance(transform.position, storage.transform.position)).ToList().ForEach(obj=>resources.Enqueue(obj));
        return resources;     
    }

    private void Store()
    {
        targetOBJ = GameObject.FindGameObjectWithTag("Storage");

        navigation.destination = targetOBJ.transform.position;
    }
    private void restart()
    {
        foreach (GameObject Resoure in GameObject.FindGameObjectsWithTag(TAG))
        {
            StoreResource.Add(Resoure);
        }
    }
}

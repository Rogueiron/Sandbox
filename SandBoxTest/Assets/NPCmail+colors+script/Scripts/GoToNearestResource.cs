using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using static Storage;
using static Upgrades;

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

    public static List<GameObject> listcheck = new();

    private float timer = 5;

    public string TAG;

    //all upgrade bools
    private bool UpgradedSpeed = false;
    private bool UpgradedAmount = false;

    private int harvestAmountWood = 10;
    private int harvestAmountIron = 5;

    private void Start()
    {
        storageManager = GameObject.FindGameObjectWithTag("StorageManager");
        restart();
        StoreResourceQueue = GetResourceQueue();
        targetOBJ = StoreResourceQueue.Dequeue();
        speration();
    }
    public void FixedUpdate()
    {
        if (targetOBJ == null)
        {
            restart();
            targetOBJ = StoreResourceQueue.Dequeue();
            speration();
        }
        if(Speed == true && UpgradedSpeed == false)
        {
            //Checks to see what type of resource is meant to be deposited
            if(TAG == "Wood")
            {
                harvestTimeReset = 5;
            }
            if (TAG == "Iron")
            {
                harvestTimeReset = 10;
            }
            UpgradedSpeed = true;
        }
        if (Amount == true && UpgradedAmount == false)
        {
            harvestAmountWood = 15;
            harvestAmountIron = 10;
            UpgradedAmount = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(storage < maxStorage && other.gameObject.CompareTag(TAG))
        {
            harvestTime -= Time.deltaTime;
            if (harvestTime <= 0 && storage != maxStorage -1)
            {
                listcheck.Remove(targetOBJ);
                Destroy(targetOBJ);
                harvestTime = harvestTimeReset;
                storage += 1;
                nextResource = StoreResourceQueue.Dequeue();
                targetOBJ = nextResource;
                StoreResource.Remove(targetOBJ);
                speration();
            }
            else if(harvestTime <=0)
            {
                listcheck.Remove(targetOBJ);
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
                WoodStorage += harvestAmountWood;
            }
            else if(TAG == "Iron")
            {
                IronStorage += harvestAmountIron;
            }
        }
        else if(storage == 0 && targetOBJ == other.gameObject.CompareTag("Storage") && timer <= 0)
        {
            timer = 5;
            restart();
            nextResource = StoreResourceQueue.Dequeue();
            targetOBJ = nextResource;
            StoreResource.Remove(targetOBJ);
            speration();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (storage >= maxStorage)
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

    private void speration()
    {
        if(listcheck.Contains(targetOBJ))
        {
            targetOBJ = StoreResourceQueue.Dequeue();
        }
        else
        {
            listcheck.Add(targetOBJ);
        }
        navigation.destination = targetOBJ.transform.position;
    }
}

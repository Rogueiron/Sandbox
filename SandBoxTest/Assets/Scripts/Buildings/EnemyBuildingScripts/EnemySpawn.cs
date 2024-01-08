using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnLength = 180;

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0)
        {
            spawnTime = spawnLength;
            Instantiate(unit, this.transform);
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
}

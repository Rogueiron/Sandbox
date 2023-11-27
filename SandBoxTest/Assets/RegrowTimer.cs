using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrowTimer : MonoBehaviour
{
    [SerializeField] private float timer = 50;
    [SerializeField] private GameObject tree;

    public void time()
    {
        Invoke(nameof(SpawnTree), 50);
    }

    public void SpawnTree()
    {
        Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

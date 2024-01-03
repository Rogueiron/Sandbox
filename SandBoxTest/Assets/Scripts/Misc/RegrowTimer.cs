using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrowTimer : MonoBehaviour
{
    [SerializeField] private float timer = 50;
    [SerializeField] private GameObject Resource;

    public void time()
    {
        //when timer is zero place a new prefab
        Invoke(nameof(SpawnResource), timer);
    }

    public void SpawnResource()
    {
        //makes the new prefab
        Instantiate(Resource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}

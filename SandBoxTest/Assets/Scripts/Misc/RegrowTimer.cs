using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrowTimer : MonoBehaviour
{
    [SerializeField] private float timer = 50;
    [SerializeField] private GameObject Resource;

    public void time()
    {
        Invoke(nameof(SpawnResource), timer);
    }

    public void SpawnResource()
    {
        Instantiate(Resource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}

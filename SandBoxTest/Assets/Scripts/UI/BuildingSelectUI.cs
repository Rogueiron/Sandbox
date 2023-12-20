using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelectUI : MonoBehaviour
{
    RaycastHit hit;
    Vector3 SpawnPoint;
    public GameObject prefab;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    private void Start()
    {
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = SpawnPoint;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.gameObject.GetComponent<UnitMaker>().ShowUi();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineBuild : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public GameObject buildingcanvas;
    private void Start()
    {
        buildingcanvas = GameObject.FindGameObjectWithTag("Buildingmode");
        buildingcanvas.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            movePoint.y += 0.5f;
            transform.position = movePoint;
        }
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            movePoint = hit.point;
            movePoint.y += 0.5f;
            transform.position = movePoint;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }

        if (Input.GetMouseButton(0))
        {
            buildingcanvas.SetActive(true);
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineBuild : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            transform.position = movePoint;
        }
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500 ,layerMask: ~LayerMask.GetMask("Buildings", "Ignore Raycast")))
        {
            movePoint = hit.point;
            movePoint.y += 1f;
            transform.position = movePoint;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }

        if (Input.GetMouseButton(0))
        {
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }
    }
}

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
        if(gameObject.tag == "Waterpump")
        {
            Waterpump();
        }
        else
        {
            Build();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Buildings")
        {
            return;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(prefab, movePoint, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    private void Waterpump()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask: ~LayerMask.GetMask("Buildings", "Ignore Raycast")))
        {
            movePoint = hit.point;
            movePoint.y += 1f;
            transform.position = movePoint;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }
        if (Input.GetMouseButton(0) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Edge"))
        {
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }

    }
    public void Build()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask: ~LayerMask.GetMask("Buildings", "Ignore Raycast")))
        {
            movePoint = hit.point;
            movePoint.y += 1f;
            transform.position = movePoint;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }
        if (Input.GetMouseButton(0) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Edge"))
        {
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }
    }
}

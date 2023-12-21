using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class OutlineBuild : MonoBehaviour
{
    RaycastHit hit;
    public static Vector3 movePoint;
    public GameObject prefab;
    [SerializeField] private Material material;
    private void Start()
    {
        //get the screenpoint and use that to move the outline of the building to that spot
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            transform.position = movePoint;
        }
    }
    private void FixedUpdate()
    {
        //checks to see if waterpump is the building else run normal build
        if(gameObject.tag == "Waterpump")
        {
            Waterpump();
        }
        else
        {
            Build();
        }
    }
    private void Waterpump()
    {
        //gets the point where that mouse is on the map
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask: ~LayerMask.GetMask("Ignore Raycast")))
        {
            movePoint = hit.point;
            movePoint.y += 1f;
            transform.position = movePoint;
        }
        //rotates the buildings when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }
        //checks to make sure the outline is being placed on the edge else it cant be placed
        if (Input.GetMouseButton(0) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Edge"))
        {
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }
        if(hit.transform.gameObject.layer != LayerMask.NameToLayer("Edge"))
        {
            material.color = new Color(1, 0, 0, .3f);
        }
        else
        {
            material.color = new Color(0, 0, 1, .3f);
        }

    }
    public void Build()
    {
        //gets the point where that mouse is on the map
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask: ~LayerMask.GetMask("Ignore Raycast")))
        {
            movePoint = hit.point;
            movePoint.y += 1f;
            transform.position = movePoint;
        }
        //rotates the buildings when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotationToAdd = new Vector3(0, 90, 0);
            transform.Rotate(rotationToAdd);
        }
        //checks to make sure the outline is being placed not on the edge else it cant be placed
        if (Input.GetMouseButton(0) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Edge") && hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(prefab, movePoint, transform.rotation);
            Destroy(gameObject);
        }
        if (hit.transform.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            material.color = new Color(1, 0, 0, .3f);
        }
        else
        {
            material.color = new Color(0, 0, 1, .3f);
        }
    }
}

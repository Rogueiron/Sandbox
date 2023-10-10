using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomlimit : MonoBehaviour
{
    RaycastHit hit;
    CameraController controller;
    Ray ray;
    // Update is called once per frame
    private void Start()
    {
        controller = GetComponentInParent<CameraController>();
    }
    void Update()
    {
        ray = (Camera.main.ScreenPointToRay(new Vector3Int(Screen.width/2, Screen.height/2)));
        if (Physics.Raycast(ray, out hit))
        {
            controller.zoom = hit.distance;
            Debug.Log(controller.zoom);
        }

    }
}

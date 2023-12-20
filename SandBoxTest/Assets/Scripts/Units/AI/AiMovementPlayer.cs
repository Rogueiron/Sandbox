using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class AiMovementPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    public int listnumber;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        else
        {
            agent = GetComponentInParent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                float Xpos = 1f * Mathf.Sqrt(2f * listnumber) * Mathf.Cos(Mathf.Sqrt(2f * listnumber)) + hit.point.x;
                float Ypos = 1f * Mathf.Sqrt(2f * listnumber) * Mathf.Sin(Mathf.Sqrt(2f * listnumber)) + hit.point.z;
                agent.destination = new Vector3(Xpos,transform.position.y,Ypos);
            }
        }
    }
}

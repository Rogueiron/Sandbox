using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Core").transform.position);
    }
}

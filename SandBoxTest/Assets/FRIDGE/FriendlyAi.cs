using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAi : MonoBehaviour
{
    public GameObject targetOBJ;

    public NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsTarget;

    public string targetType;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int strength;

    //States
    public float sightRange, attackRange;
    public bool targetInSightRange, targetInAttackRange;
    private void Start()
    {
        GetComponent<SphereCollider>().radius = sightRange;
    }

    // Update is called once per frame
    void Update()
    {
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsTarget);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTarget);

        if (!targetInSightRange && !targetInAttackRange)
        {
            targetOBJ = null;
        }
        if (targetInSightRange && !targetInAttackRange) ChaseTarget();
        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }

    private void ChaseTarget()
    {
        if (targetOBJ != null)
        {
            agent.SetDestination(targetOBJ.transform.position);
        }
    }

    private void AttackTarget()
    {
        //Make sure this unit doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(targetOBJ.transform);

        if (!alreadyAttacked)
        {
            Debug.Log("ATTACKED");
            targetOBJ.GetComponent<Stats>().health -= strength;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        Debug.Log("RELOADED");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetType) && targetOBJ == null)
        {
            targetOBJ = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetOBJ)
        {
            targetOBJ = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

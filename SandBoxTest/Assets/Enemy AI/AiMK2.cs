using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMK2 : MonoBehaviour
{
    public GameObject targetOBJ;

    public NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsTarget;

    public LayerMask targetType;

    //Patrolling
    public bool patrol = true;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int strength;

    //States
    public float sightRange, attackRange;
    public bool targetInSightRange, targetInAttackRange;

    // Sets the sight collider to the correct size using sightRange
    private void Start()
    {
        GetComponentInChildren<SphereCollider>().radius = sightRange;
    }

    // Update is called once per frame
    void Update()
    {
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsTarget);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTarget);
        
        // Checks if target is within range and acts accordingly
        if (!targetInSightRange && !targetInAttackRange && patrol)
        {
            Patrolling();
            targetOBJ = null;
        }
        if (targetInSightRange && !targetInAttackRange) ChaseTarget();
        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }
    
    //Randomly gets a location in range and moves there and then checks to see if it reaches it
    private void Patrolling()
    {
        // Sets the walk point
        if (!walkPointSet) SearchWalkPoint();
        
        // Sets the destination to the walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < .75f)
        {
            walkPointSet = false;
        }
    }

    // Follows target
    private void ChaseTarget()
    {
        // Sets destination to target
        if (targetOBJ != null)
        {
            agent.SetDestination(targetOBJ.transform.position);
        }
    }

    // Attacks and deals damage to target
    private void AttackTarget()
    {
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(targetOBJ.transform);

        // Deals damage to target equal to strength
        if (!alreadyAttacked)
        {
            targetOBJ.GetComponent<Stats>().health -= strength;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // Gets an applicable destination for walk point
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Makes sure the walk point is permitted
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    // Sets target when an applicable unit or enemy is within range
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == targetType && targetOBJ == null)
        {
            targetOBJ = other.gameObject;
        }
    }
    // When target leaves sight range targetObj becomes blank
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == targetOBJ)
        {
            targetOBJ = null;
        }
    }

    // Only visible in the Scene, and helps to visualize the ranges
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }

}

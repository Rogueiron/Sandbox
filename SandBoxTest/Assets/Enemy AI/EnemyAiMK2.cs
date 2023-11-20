using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiMK2 : MonoBehaviour
{
    public GameObject targetOBJ;

    public NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsTarget;

    public float health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

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
            Patrolling();
            targetOBJ = null;
        }
        if (targetInSightRange && !targetInAttackRange) ChaseTarget();
        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

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

    private void ChaseTarget()
    {
        if (targetOBJ != null)
        {
            agent.SetDestination(targetOBJ.transform.position);
        }
    }

    private void AttackTarget()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(targetOBJ.transform);

        if (!alreadyAttacked)
        {
            Debug.Log("ATTACKED");
            targetOBJ.GetComponent<Stats>().health -= 1;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        Debug.Log("RELOADED");
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Is doing thing");
        if (other.CompareTag("Player") && targetOBJ == null)
        {
            Debug.Log("OOOOOO yay :)");
            targetOBJ = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == targetOBJ)
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

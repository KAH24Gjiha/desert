using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterControll : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10.0f;
    public float attackRange = 2.0f;
    public float moveSpeed = 3.5f;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public float patrolRange = 20.0f;  // Ž�� ����
    public float patrolWaitTime = 3.0f;  // Ž�� ��� �ð�

    private bool isChasing = false;
    private bool isAttacking = false;
    private float distanceToPlayer;
    private Vector3 patrolTarget;
    private float patrolTimer;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        SetNewPatrolTarget();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= chaseRange && !isAttacking)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange)
            {
                isAttacking = true;
                navMeshAgent.isStopped = true;
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= patrolWaitTime)
            {
                SetNewPatrolTarget();
                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
        }
    }

    void SetNewPatrolTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, patrolRange, -1);
        patrolTarget = navHit.position;
        navMeshAgent.SetDestination(patrolTarget);
    }

    IEnumerator AttackPlayer()
    {
        while (isAttacking)
        {
            if (distanceToPlayer > attackRange)
            {
                isAttacking = false;
                navMeshAgent.isStopped = false;
                yield break;
            }

            // ���� ����
            Debug.Log("Attacking player for " + attackDamage + " damage.");

            // �÷��̾ �������� �޴� ����
            // player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

            yield return new WaitForSeconds(attackCooldown);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
    }
}
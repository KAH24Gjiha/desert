using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform player;
    public Transform paticle;
    private float chaseRange = 10.0f;
    private float attackRange = 2.0f;
    private int attackDamage = 10;
    private float attackCooldown = 1.5f;
    private float patrolRange = 20.0f;  // Ž�� ����
    private float patrolWaitTime = 1.0f;  // Ž�� ��� �ð�

    private float moveSpeed = 3f;
    private float walkSpeed = 0.8f;
    private float runSpeed = 2f;

    private bool isChasing = false;
    private bool isAttacking = false;
    private float distanceToPlayer;
    private Vector3 patrolTarget;
    private float patrolTimer;

    public NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.speed = moveSpeed;

        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        SetNewPatrolTarget();
    }

    void Update()
    {
        animator.SetFloat("speed", moveSpeed);
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= chaseRange && !isAttacking)
        {
            if (isChasing == false) StartCoroutine(BigPaticle());
            isChasing = true;

        }
        else
        {
            if (isChasing == true) StartCoroutine(SmallPaticle());
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

        moveSpeed = isChasing ? runSpeed : walkSpeed;


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
    IEnumerator BigPaticle()
    {
        while (paticle.localScale.x <= 5f)
        {
            paticle.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator SmallPaticle()
    {
        while (paticle.localScale.x >= 1f)
        {
            paticle.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.1f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class artificial_intelligence_enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public Collider player1;
    public Animator anim;

    // Patroling = Devriye Gezme
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking = Sald�r�
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    bool olduMu;

    //States = S�n�f vb.
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("myPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
        olduMu = false;
    }

    private void Update()
    {
        // Check for sight and attack range = g�r�� ve sald�r� menzili kontrol�
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        DestroyEnemy();
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


    }

    private void Patroling()
    {
        if (walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
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

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        if (!playerInAttackRange)
        {
            GetComponent<Animator>().SetTrigger("Move");
        }
    }

    private void AttackPlayer()
    {
        float differntZ = player1.transform.position.z - transform.position.z;
        //Make sure enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here

            // if (player.transform.position.x < 0.3f)
            // {
                GetComponent<Animator>().SetTrigger("Attack");

            // }
            // else if (differntZ < 0.3f)
            // {
            //     GetComponent<Animator>().SetTrigger("Attack");

            // }
            // else if (player.transform.position.x < 10)
            // {
            //     GetComponent<Animator>().SetTrigger("Move");
            // }
            // else if (player.transform.position.z < 10)
            // {
            //     GetComponent<Animator>().SetTrigger("Move");
            // }
            // else
            // {
            //     player1.isTrigger = false;
            // }
            //else
            //{
            //    GetComponent<Animator>().SetTrigger("Move");
            //}

            ///


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);

    }

    public void DestroyEnemy()
    {

    }

    IEnumerator DestroyEnemyIEn()
    {
        var score = GetComponent<Score_Script>();

        score.score += 10;

        var Enemy_Health_Bar = GetComponent<Enemy_Health_Bar>();

        GetComponent<Animator>().SetTrigger("Die");



        yield return new WaitForSeconds(2.5f);

        Destroy(gameObject);
    }
    IEnumerator ikiSaniyeBekle()
    {

        olduMu = true;
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


}

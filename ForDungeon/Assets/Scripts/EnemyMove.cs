using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] float attackRadius;
    [SerializeField] float chaseRadius;
    [SerializeField] Animator animator;
    bool isChasing;
    int attackId = -1;

    void Update()
    {
        Vector3 dest = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
/*        print(Vector3.Distance(dest, transform.position));*/
        if(Vector3.Distance(dest, transform.position) < chaseRadius)
        {
            isChasing = true;
            if(Vector3.Distance(dest, transform.position) < attackRadius)
            {
                if(attackId == -1)
                {
                    attackId = Random.Range(0, 2);
                }
                agent.SetDestination(transform.position);
                transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            }
            else
            {
                attackId = -1;
                agent.SetDestination(dest);
            }

        }
        else
        {
            isChasing = false;
            agent.SetDestination(transform.position);
        }

        animator.SetBool("isChasing", isChasing);
        animator.SetBool("CanAttack", Vector3.Distance(dest, transform.position) < attackRadius);
        animator.SetInteger("AttackId", attackId);
        attackId = -1;
    }
    private void OnEnable()
    {
        
    }
}

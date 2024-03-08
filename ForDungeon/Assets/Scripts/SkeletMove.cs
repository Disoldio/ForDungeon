using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] float radius;
    [SerializeField] Animator animator;

    bool canMove = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitToStart());
    }
    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1.5f);
        canMove = true;
    }
    void Update()
    {
        if(!canMove)
        {
            return;
        }
        Vector3 dest = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if(Vector3.Distance(dest, transform.position) < radius)
        {
            agent.SetDestination(transform.position);
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        }
        else
        {
            agent.SetDestination(dest);
        }
        animator.SetBool("CanAttack", Vector3.Distance(dest, transform.position) < radius);

    }
    private void OnEnable()
    {
        
    }
}

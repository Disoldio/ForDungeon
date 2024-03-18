using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkEnemy : Enemy
{
    [SerializeField]
    private float chaseRadius = 10;
    private void Update()
    {
        if (Vector3.Distance(_playerTransform.position, _agent.transform.position) <= chaseRadius)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_playerTransform.position);

            if (Vector3.Distance(_playerTransform.position, _agent.transform.position) <= _agent.stoppingDistance)
            {
                LookAtPlayer();
                if (_canAttack)
                {
                    Attack();
                    StartCoroutine("StartCooldown");
                }
            }
        }
        else
        {
            _agent.isStopped = true;
        }
    }
}

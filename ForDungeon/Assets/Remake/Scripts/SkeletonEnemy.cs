using Remake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonEnemy : Enemy
{
    private bool _isSpawned = false;
    private void OnEnable()
    {
        StartCoroutine("WaitForSpawn");
    }
    private void Update()
    {
        if (!_isSpawned)
        {
            return;
        }

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
    private IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(2);
        _isSpawned = true;
    }
}

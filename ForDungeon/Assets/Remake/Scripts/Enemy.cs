using Remake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float health = 10;

    [SerializeField]
    protected float rotationSpeed = 1;

    [SerializeField]
    protected Transform _playerTransform;

    [SerializeField]
    protected Vector3 rayOffset = Vector3.zero;

    [SerializeField]
    protected Sword currentSword;

    protected float _currentHealth;
    protected EnemySlider _enemySlider;
    protected NavMeshAgent _agent;
    protected Ray _ray;
    protected float _cooldownTime;
    protected bool _canAttack = true;

    private void Start()
    {
        _currentHealth = health;

        _enemySlider = GetComponentInChildren<EnemySlider>();
        _enemySlider.GetSlider().maxValue = health;
        _enemySlider.GetSlider().value = health;

        _agent = GetComponent<NavMeshAgent>();

        _cooldownTime = 1 / currentSword.GetAttackSpeed();
    }

    private void FixedUpdate()
    {
        DebugAttackRay();
    }

    protected void Attack()
    {
        StartCoroutine("StartCooldown");
        _ray = new Ray(transform.position + rayOffset, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, currentSword.GetMaxDistance()))
        {
            if (hit.transform.GetComponent<PlayerAttack>())
            {
                PlayerAttack playerAttack = hit.transform.GetComponent<PlayerAttack>();
                playerAttack.TakeDamage(currentSword.GetStrenght());
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_cooldownTime);
        _canAttack = true;
    }

    protected void LookAtPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(_playerTransform.position - _agent.transform.position);
        _agent.transform.rotation = Quaternion.Slerp(
            _agent.transform.rotation,
            lookRotation,
            Time.deltaTime * rotationSpeed);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _enemySlider.GetSlider().value = _currentHealth;
        print($"{name}'s health: {_currentHealth}");
    }

    private void DebugAttackRay()
    {
        Debug.DrawRay(_ray.origin, _ray.direction * currentSword.GetMaxDistance(), Color.red);
    }
}

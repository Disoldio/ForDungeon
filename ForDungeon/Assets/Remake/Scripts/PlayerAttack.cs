using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Sword currentSword;

    [SerializeField]
    private Vector3 rayOffset = Vector3.zero;

    private float _cooldownTime;
    private bool _canAttack = true;
    private Ray _ray;

    private void Start()
    {
        currentSword.gameObject.SetActive(true);
        _cooldownTime = 1 / currentSword.GetAttackSpeed();
    }

    private void FixedUpdate()
    {
        DebugAttackRay();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _ray = new Ray(transform.position + rayOffset, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, currentSword.GetMaxDistance()))
        {
            print($"{currentSword.name} hit {hit.transform.name}");

            if (hit.transform.GetComponent<Enemy>())
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                enemy.TakeDamage(currentSword.GetStrenght());
            }
        }
        StartCoroutine("StartCooldown");
    }

    private IEnumerator StartCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds( _cooldownTime );
        _canAttack = true;
    }

    private void DebugAttackRay()
    {
        Debug.DrawRay(_ray.origin, _ray.direction * currentSword.GetMaxDistance(), Color.red);
    }
}

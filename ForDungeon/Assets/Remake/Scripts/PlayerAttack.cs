using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Sword currentSword;

    [SerializeField]
    private float health;

    [SerializeField]
    private Vector3 rayOffset = Vector3.zero;

    [SerializeField]
    private Transform swordHand;

    [SerializeField]
    private Slider healthBar;

    private float _cooldownTime;
    private bool _canAttack = true;
    private Ray _ray;
    private SwordManager _swordManager;
    private int _currentSwordHashCode = -1;
    private float _currentHealth;

    private void Start()
    {
        _swordManager = FindObjectOfType<SwordManager>();

        _currentSwordHashCode = PlayerPrefs.GetInt("swordHashCode", -1);
        if (_currentSwordHashCode != -1)
        {
            currentSword = Instantiate(_swordManager.GetSwordByHashCode(_currentSwordHashCode), swordHand).GetComponent<Sword>();
        }
        else
        {
            currentSword = Instantiate(_swordManager.GetDefaultSword(), swordHand).GetComponent<Sword>();
        }


        _cooldownTime = 1 / currentSword.GetAttackSpeed();

        _currentHealth = health;
        healthBar.maxValue = health;
        healthBar.value = health;
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

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        healthBar.value = _currentHealth;
        print($"Player's health: {_currentHealth}");
    }

    private void DebugAttackRay()
    {
        Debug.DrawRay(_ray.origin, _ray.direction * currentSword.GetMaxDistance(), Color.red);
    }
}

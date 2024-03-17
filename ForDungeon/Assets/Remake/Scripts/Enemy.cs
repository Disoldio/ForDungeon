using Remake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 10;

    private float _currentHealth;
    private EnemySlider _enemySlider;

    private void Start()
    {
        _currentHealth = health;
        _enemySlider = GetComponentInChildren<EnemySlider>();
        _enemySlider.GetSlider().maxValue = health;
        _enemySlider.GetSlider().value = health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _enemySlider.GetSlider().value = _currentHealth;
        print($"{name}'s health: {_currentHealth}");
    }
}

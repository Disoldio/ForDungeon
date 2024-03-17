using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private float _strenght;

    [SerializeField]
    private float _attackSpeed;

    [SerializeField]
    private float _maxDistance;

    public float GetStrenght()
    {
        return _strenght;
    }
    public float GetAttackSpeed()
    {
        return _attackSpeed;
    }
    public float GetMaxDistance()
    {
        return _maxDistance;
    }
}

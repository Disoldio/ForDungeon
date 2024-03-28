using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword
{
    private int _id;
    private string _name;
    private float _strength;
    private float _attackSpeed;
    private float _maxDistance;

    public Sword (int id, string name, float strenght, float attackSpeed, float maxDistance)
    {
        _id = id;
        _name = name;
        _strength = strenght;
        _attackSpeed = attackSpeed;
        _maxDistance = maxDistance;
    }

    public int GetId()
    {
        return _id;
    }
    public string GetName()
    {
        return _name;
    }
    public float GetStrength()
    {
        return _strength;
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

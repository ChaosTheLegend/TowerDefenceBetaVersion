using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    
    public float Scale { get; private set; }

    private void Awake()
    {
        Scale = transform.localScale.magnitude;
    }

    public void ApplyDamage(float damage) => _health -= damage;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    public float Scale { get; private set; }

    private void Awake() => Scale = transform.localScale.magnitude;

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Castle castle))
        {
            castle.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}
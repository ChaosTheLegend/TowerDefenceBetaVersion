using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    
    public float Health => _health;
    
    public event UnityAction<float> ChangedHealthPoint;
    
    public float Scale { get; private set; }

    private void Awake() => Scale = transform.localScale.magnitude;

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        ChangedHealthPoint?.Invoke(_health);

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent(out Castle castle)) return;
        
        castle.ApplyDamage(_damage);
        Destroy(gameObject);
    }
}
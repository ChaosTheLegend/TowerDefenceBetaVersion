using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    private Tower _tower;

    private Vector3 Target;

    private void Awake()
    {
        _tower = FindObjectOfType<Tower>();
    }

    private void FixedUpdate()
    {
        Target = _tower.Target;
        transform.position = Vector3.Lerp(transform.position, Target,
            _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_tower.Damage);
            Destroy(gameObject);
        }
    }
}
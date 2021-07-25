using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public abstract class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 Target;

    protected Tower Tower { get; private set; }
    public float Speed => _speed;

    private void Awake() => Tower = FindObjectOfType<Tower>();

    private void FixedUpdate()
    {
        Target = Tower.Finder.Target.Position;
        transform.position = Vector3.Lerp(transform.position, Target,
            _speed * Time.fixedDeltaTime);
    }
}
using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

[SelectionBase]
public class Tower : MonoBehaviour
{
    [SerializeField, Range(10f, 20f)] private float _targetingRange = 10f;
    [SerializeField] private float _damage;
    
    [Header("Shooting Settings")] 
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private Arrow _arrow;
    
    public Vector3 Target { get; private set; }
    public float Damage => _damage;

    private Human _human;
    private float _timeAfterShoot;
    private TargetPoint _target;

    private const int ENEMY_LAYER_MASK = 1 << 9;
    
    private void Awake() => _human = GetComponentInChildren<Human>();

    private void FixedUpdate()
    {
        if (IsTargetTracked() || IsAcquireTarget()) 
            Shoot();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private bool IsAcquireTarget()
    {
        var targets = Physics.OverlapSphere(transform.localPosition, _targetingRange, ENEMY_LAYER_MASK);
        
        if (targets.Length > 0)
        {
            _target = targets[0].GetComponent<TargetPoint>();
            return true;
        }

        _target = null;
        return false;
    }

    private bool IsTargetTracked()
    {
        if (_target == null)
            return false;

        var myPos = transform.localPosition;
        var targetPos = _target.Position;

        if (Vector3.Distance(myPos, targetPos) > _targetingRange)
        {
            _target = null;
            return false;
        }

        return true;
    }

    private void Shoot()
    {
        var point = _target.Position;
        _human.transform.LookAt(point);
        
        Target = point;
        
        _timeAfterShoot += Time.deltaTime;

        if (_timeAfterShoot > _delayBetweenShoots)
        {
            Instantiate(_arrow, _human.transform.position, Quaternion.identity);
            
            _timeAfterShoot = 0;
        }
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.localPosition;
        position.y += 0.01f;
        Gizmos.DrawWireSphere(position, _targetingRange);

        if (_target == null) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, _target.Position);
    }*/
}
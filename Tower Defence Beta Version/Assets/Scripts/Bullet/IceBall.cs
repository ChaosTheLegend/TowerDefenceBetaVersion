using System.Collections;
using UnityEngine;

public class IceBall : Arrow
{
    [SerializeField] private float _freezeDelay;
    [SerializeField] private float _freezeSpeed;

    private Coroutine _freeze;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Enemy enemy) && ArrowType is ArrowType.IceBall) return;
        enemy.ApplyDamage(Tower.Shooter.Damage);
        _freeze = StartCoroutine(Freeze(enemy));
        Destroy(gameObject);
    }

    private IEnumerator Freeze(Enemy enemy)
    {
        var defaultSpeed = enemy.Movement.Agent.speed;

        enemy.Movement.Agent.speed = _freezeSpeed;
        yield return new WaitForSeconds(_freezeDelay);
        
        // ReSharper disable once Unity.InefficientPropertyAccess
        enemy.Movement.Agent.speed = defaultSpeed;
    }
}
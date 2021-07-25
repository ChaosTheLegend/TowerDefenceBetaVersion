using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleArrow : Arrow
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Enemy enemy)) return;
        enemy.ApplyDamage(Tower.Shooter.Damage);
        Destroy(gameObject);
    }
}
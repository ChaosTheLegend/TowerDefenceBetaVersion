using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class EnemyHealthPoint : HealthBar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable() => _enemy.ChangedHealthPoint += OnChangeHealth;

    private void OnDisable() => _enemy.ChangedHealthPoint -= OnChangeHealth;

    //TODO UI FOR ENEMY
    public override void OnChangeHealth()
    {
        Slider.DOValue(100, 100);
    }
}

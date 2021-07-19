using System;
using DG.Tweening;
using UnityEngine;
public class EnemyHealthPoint : HealthBar
{
    [SerializeField] private Enemy _enemy;
    
    private void OnEnable() => _enemy.ChangedHealthPoint += OnChangeHealth;

    private void OnDisable() => _enemy.ChangedHealthPoint -= OnChangeHealth;

    public override void OnChangeHealth(int health) => Slider.DOValue(health, FillDuration);
}

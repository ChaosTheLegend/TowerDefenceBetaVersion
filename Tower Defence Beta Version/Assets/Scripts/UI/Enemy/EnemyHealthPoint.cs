using DG.Tweening;
using UnityEngine;
public class EnemyHealthPoint : HealthBar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable() => _enemy.ChangedHealthPoint += OnChangeHealth;

    private void OnDisable() => _enemy.ChangedHealthPoint -= OnChangeHealth;

    //TODO UI FOR ENEMY
    public override void OnChangeHealth(float health) => Slider.DOValue(health, FillDuration);
}

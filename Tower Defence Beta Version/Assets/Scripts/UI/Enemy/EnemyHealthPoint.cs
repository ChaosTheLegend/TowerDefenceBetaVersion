using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthPoint : HealthBar
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Image[] _imagesForColor;
    [SerializeField] private float _showDuration;

    private Color _healthBarColor;
    
    private void OnEnable() => _enemy.ChangedHealthPoint += OnChangeHealth;

    private void OnDisable() => _enemy.ChangedHealthPoint -= OnChangeHealth;

    private void Start()
    {
        const int index = 0;
        _healthBarColor = _imagesForColor[index].color;
        ChangeTransparencyOfHealthBar(index);
    }

    public override void OnChangeHealth(int health) => StartCoroutine(HealthBarInTimeCoroutine(health));
    
    //BUG HEALTH BAR COLOUR BUG
    private IEnumerator HealthBarInTimeCoroutine(int health)
    {
        Slider.DOValue(health, FillDuration);
        ChangeTransparencyOfHealthBar(255);
        yield return new WaitForSeconds(_showDuration);
        ChangeTransparencyOfHealthBar(0);
    }

    private void ChangeTransparencyOfHealthBar(float transparency)
    {
        foreach (var image in _imagesForColor) 
            image.color = new Color(_healthBarColor.r, _healthBarColor.g, _healthBarColor.b, transparency);
    }
}

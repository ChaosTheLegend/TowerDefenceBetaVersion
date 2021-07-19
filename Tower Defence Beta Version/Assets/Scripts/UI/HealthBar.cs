using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private float _fillDuration;
    protected Slider Slider { get; private set; }
    
    private void Awake() => Slider = GetComponent<Slider>();

    protected float FillDuration => _fillDuration;
    
    public abstract void OnChangeHealth(int health);
}

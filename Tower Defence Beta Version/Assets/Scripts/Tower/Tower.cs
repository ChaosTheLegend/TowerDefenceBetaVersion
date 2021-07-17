using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

[SelectionBase]
public class Tower : MonoBehaviour
{
    public TowerTargetFinder Finder { get; private set; }
    public TowerShooter Shooter { get; private set; }

    private Human _human;

    private void Awake()
    {
        Finder = GetComponent<TowerTargetFinder>();
        Shooter = GetComponent<TowerShooter>();
        _human = GetComponentInChildren<Human>();
    }

    private void FixedUpdate()
    {
        if (Finder.IsAcquireTarget() || Finder.IsTargetTracked()) 
            Shooter.Shoot(Finder.Target, _human);
    }
}
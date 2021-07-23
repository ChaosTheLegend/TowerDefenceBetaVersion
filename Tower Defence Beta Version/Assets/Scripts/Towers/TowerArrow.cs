using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase, RequireComponent(typeof(TowerTargetFinder), typeof(TowerShooter))]
public class TowerArrow : Tower
{
    private void Awake() => InitRequiredComponents();
}

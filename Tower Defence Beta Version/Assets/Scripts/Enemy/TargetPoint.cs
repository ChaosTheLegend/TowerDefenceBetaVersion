using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private Enemy Enemy { get; set; }
    
    public Vector3 Position => transform.position;

    private void Awake() => Enemy = transform.root.GetComponent<Enemy>();
}

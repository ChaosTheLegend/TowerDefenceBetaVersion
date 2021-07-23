using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private Castle _endPosition;

    public NavMeshAgent Agent { get; private set; }
    
    private void Awake()
    {
        _endPosition = FindObjectOfType<Castle>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start() => Agent.SetDestination(_endPosition.transform.position);
}

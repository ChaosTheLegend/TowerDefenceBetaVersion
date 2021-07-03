using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private EndPosition _endPosition;
    
    private NavMeshAgent _agent;
    
    private void Awake()
    {
        _endPosition = FindObjectOfType<EndPosition>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start() => _agent.SetDestination(_endPosition.transform.position);
}

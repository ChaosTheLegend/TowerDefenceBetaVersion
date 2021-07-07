using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private Castle _endPosition;
    
    private NavMeshAgent _agent;
    
    private void Awake()
    {
        _endPosition = FindObjectOfType<Castle>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start() => _agent.SetDestination(_endPosition.transform.position);
}

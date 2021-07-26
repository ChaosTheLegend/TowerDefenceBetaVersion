using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Spawn Options")] 
    [SerializeField] private Transform _spawnPosition;

    [Header("Main Options")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _countOfEnemy;
    
    private void Start() => Spawn();

    private void Spawn() => StartCoroutine(SpawnEnemy());

    private IEnumerator SpawnEnemy()
    {
        for (var i = 0; i < _countOfEnemy; i++)
        {
            Instantiate(_enemy, _spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }
}
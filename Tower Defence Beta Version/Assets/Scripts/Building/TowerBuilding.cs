using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class TowerBuilding : MonoBehaviour
{
    [SerializeField] private Vector2Int _size = Vector2Int.one;

    private void OnDrawGizmosSelected()
    {
        for (var x = 0; x < _size.x; x++)
        {
            for (var y = 0; y < _size.y; y++)
            {
                Gizmos.color = (x+y)%2 == 0 ? new Color(0.78f, 0f, 1f, 0.36f) 
                    : new Color(1f, 0.18f, 0f, 0.36f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), 
                    new Vector3(10,1f,10));
            }
        }
    }
}

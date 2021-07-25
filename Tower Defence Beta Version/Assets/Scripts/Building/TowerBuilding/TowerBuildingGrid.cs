using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingGrid : MonoBehaviour
{
    [SerializeField] private TowerBuilding _towerPrefab;
    
    private Vector2Int _gridSize = Vector2Int.one;
    
    private TowerBuilding[,] _grid;
    private TowerBuilding _flyingBuilding;
    private Camera _mainCamera;

    private void Awake()
    {
        _grid = new TowerBuilding[_gridSize.x, _gridSize.y];
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out var position))
            {
                var worldPosition =  ray.GetPoint(position);

                var x = Mathf.RoundToInt(worldPosition.x);
                var z = Mathf.RoundToInt(worldPosition.z);

                _flyingBuilding.transform.position = new Vector3(x, 0, z);

                if (Input.GetMouseButtonDown(0)) 
                    _flyingBuilding = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.M)) 
            StartPlacingBuilding(_towerPrefab);
    }

    public void StartPlacingBuilding(TowerBuilding buildingPrefab)
    {
        if (_flyingBuilding != null) 
            Destroy(_flyingBuilding);

        _flyingBuilding = Instantiate(buildingPrefab);
    }
}
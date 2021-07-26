using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.ButtonEditor;
using UnityEngine;

public class BuildPlatformSystem : MonoBehaviour
{
    [SerializeField] private BuildPlatform _platformPrefab;
    private List<BuildPlatform> _platforms = new List<BuildPlatform>();

    public BuildPlatform PlatformPrefab => _platformPrefab;

#if UNITY_EDITOR

    [EditorButton("Add Platform")]
    public void AddPlatform()
    {
        Transform systemTransform;
        _platforms.Add(Instantiate(_platformPrefab, (systemTransform = transform).position,
            Quaternion.identity, systemTransform));
    }

    [EditorButton("Delete All Platforms")]
    public void DeletePlatform()
    {
        foreach (var t in _platforms) Destroy(t.gameObject);
    }
    
#endif
}
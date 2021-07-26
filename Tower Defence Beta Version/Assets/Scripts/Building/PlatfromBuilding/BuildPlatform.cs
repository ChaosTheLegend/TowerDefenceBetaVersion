using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildPlatform : MonoBehaviour
{
   private BuildPlatformSystem _system;

   private void Awake() => _system = GetComponentInParent<BuildPlatformSystem>();

   public bool IsValid { get; private set; }

   private void Start() => IsValid = true;

   private void OnMouseDown()
   {
      if (!IsValid) return;
      
      Instantiate(_system.PlatformPrefab,transform.position, Quaternion.identity);
      IsValid = false;
   }
}

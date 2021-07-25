using System;
using System.Collections;
using System.Collections.Generic;
using CustomAttributeEditor.ButtonEditor;
using UnityEngine;

public class BuildPlatformSystem : MonoBehaviour
{
    private List<BuildPlatform> _platforms;
    
    [EditorButton("Some")]
    public void Some()
    {}

}

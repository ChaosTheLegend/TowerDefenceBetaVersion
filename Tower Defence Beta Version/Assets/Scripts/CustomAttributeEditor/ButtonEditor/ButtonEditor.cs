using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(Object), true, isFallback = false)]
namespace CustomAttributeEditor.ButtonEditor
{
    [CanEditMultipleObjects]
    public class ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var t in targets)
            {
                var methodInfos= t.GetType().GetMethods().Where(m => m.GetCustomAttributes()
                    .Any(a => a.GetType() == typeof(EditorButtonAttribute)));

                foreach (var mi in methodInfos)
                {
                    {
                        var attribute = (EditorButtonAttribute) mi.GetCustomAttribute(typeof(EditorButtonAttribute));
                        if (GUILayout.Button(attribute.Name))
                        {
                            mi.Invoke(t, null);
                        }
                    }
                }
            }
        }
    }
}
using System;

namespace Plugins.ButtonEditor
{
    /// <summary>
    /// Attribute from method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class EditorButtonAttribute : Attribute
    {
        /// <summary>
        /// Button text
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Add Button to Inspector
        /// </summary>
        /// <param name="name">Button text</param>
        public EditorButtonAttribute(string name) => Name = name;
    }
}
using UnityEditor;
using UnityEngine;
using Utilities;

namespace Editor
{
    [CustomEditor(typeof(ChildrenRenamer))]
    public class ChildrenRenamerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var script = (ChildrenRenamer)target;
            
            if (GUILayout.Button("Rename"))
                script.RenameChildren();
        }
    }
}
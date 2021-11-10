using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Level level = (Level) target;
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Map", GUILayout.Height(45)))
        {
            level.GenerateMap();
        }
    }
}

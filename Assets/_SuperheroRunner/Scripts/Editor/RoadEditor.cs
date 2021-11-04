using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Road))]
public class RoadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Road road = (Road) target;
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Road", GUILayout.Height(45)))
        {
            road.GenerateRoad();
        }
    }
}

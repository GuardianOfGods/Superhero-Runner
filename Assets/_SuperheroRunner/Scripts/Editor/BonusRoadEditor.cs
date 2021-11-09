using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BonusRoad))]
public class BonusRoadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BonusRoad bonusRoad = (BonusRoad) target;
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Boss", GUILayout.Height(45)))
        {
            bonusRoad.GenerateRoad();
        }
    }
}

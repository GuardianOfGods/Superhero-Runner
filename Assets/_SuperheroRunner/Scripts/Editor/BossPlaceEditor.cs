using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BossPlace))]
public class BossPlaceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BossPlace bossPlace = (BossPlace) target;
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Boss", GUILayout.Height(45)))
        {
            bossPlace.GenerateBoss();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
public class GameBase : EditorWindow
{
    void OnGUI()
    {
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.EndHorizontal();
    }
    
    [MenuItem("GameBase/OPEN SCENE/Loading Scene %F1")]
    public static void PlayFromLoadingScene(){
        EditorSceneManager.OpenScene("Assets/_SuperheroRunner/Scenes/LoadingScene.unity");
    }

    [MenuItem("GameBase/OPEN SCENE/Gameplay Scene %F2")]
    public static void PlayFromGamePlayScene(){
        EditorSceneManager.OpenScene("Assets/_SuperheroRunner/Scenes/GamePlayScene.unity");
    } 

    [MenuItem("GameBase/DATA/Add 100k Diamonds")]
    public static void Add100kDiamond()
    {
        Data.DiamondTotal += 100000;
    }
    
    [MenuItem("GameBase/DATA/CLEAR ALL DATA")]
    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
}

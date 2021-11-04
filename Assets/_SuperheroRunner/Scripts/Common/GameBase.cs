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
    
    [MenuItem("GameBase/OPEN SCENE/Lobby Scene %F2")]
    public static void PlayFromLobbyScene(){
        EditorSceneManager.OpenScene("Assets/_SuperheroRunner/Scenes/LobbyScene.unity");
    } 
    
    [MenuItem("GameBase/OPEN SCENE/Gameplay Scene %F3")]
    public static void PlayFromGamePlayScene(){
        EditorSceneManager.OpenScene("Assets/_SuperheroRunner/Scenes/GamePlayScene.unity");
    } 

    [MenuItem("GameBase/CLEAR DATA/CLEAR ALL DATA")]
    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
}

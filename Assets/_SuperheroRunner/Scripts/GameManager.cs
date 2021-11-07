using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public LevelController LevelController;
    public GameState GameState;
    
    // Start is called before the first frame update
    void Start()
    {
        PopupController.Instance.Show<PopupHome>();
        LevelController.PrepareLevel();
    }

    public void StartGame()
    {
        GameState = GameState.PlayingGame;
        LevelController.PlayerStart();
    }

    public bool IsPlayerCanMove()
    {
        return GameState == GameState.PlayingGame && LevelController.CurrentLevel.LevelState == LevelState.Running;
    }
}

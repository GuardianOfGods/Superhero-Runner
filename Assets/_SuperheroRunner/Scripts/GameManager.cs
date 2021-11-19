using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public LevelController LevelController;
    public GameState GameState;
    
    // Start is called before the first frame update
    void Start()
    {
        ReturnHome();
    }

    public void ReturnHome()
    {
        SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
        
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupHome>();
        PopupController.Instance.Show<PopupInGame>();
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

    public void OnWinGame()
    {
        GameState = GameState.EndGame;
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            PopupController.Instance.Hide<PopupInGame>();
            PopupController.Instance.Show<PopupWin>();
        });
    }
    
    public void OnLoseGame()
    {
        GameState = GameState.EndGame;
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            PopupController.Instance.Hide<PopupInGame>();
            PopupController.Instance.Show<PopupLose>();
        });
    }
}

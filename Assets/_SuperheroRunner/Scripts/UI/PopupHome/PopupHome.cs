using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : Popup
{
    public GameObject SoundOffImg;
    public GameObject VibrationOffImg;
    public ButtonUpgradeLevel ButtonUpgradeLevel;
    public ButtonUpgradePower ButtonUpgradePower;

    protected override void BeforeShow()
    {
        base.BeforeShow();
        Setup();
    }

    public void Setup()
    {
        SoundOffImg.SetActive(!Data.SoundState);
        VibrationOffImg.SetActive(!Data.VibrateState);
        ButtonUpgradeLevel.Setup();
        ButtonUpgradePower.Setup();
    }

    public void OnClickSound()
    {
        SoundController.Instance.PauseBackground();
        Data.SoundState = !Data.SoundState;
        Setup();
        SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
    }
    
    public void OnClickVibrate()
    {
        Data.VibrateState = !Data.VibrateState;
        Setup();
    }
    
    public void OnClickStart()
    {
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
        GameManager.Instance.StartGame();
    }

    public void OnClickLevelUpgrade()
    {
        int cost = ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1);
        if (Data.DiamondTotal >= cost)
        {
            Data.DiamondTotal -= cost;
            Data.PlayerLevel++;
            LevelController.Instance.CurrentLevel.Player.UpdatePlayerLevel();
        }
        ButtonUpgradeLevel.Setup();
    }
    
    public void OnClickPowerUpgrade()
    {
        int cost = ConfigController.Game.GetCostToUpgradePower(Data.PlayerPower + 1);
        if (Data.DiamondTotal >= cost)
        {
            Data.DiamondTotal -= cost;
            Data.PlayerPower++;
        }
        ButtonUpgradePower.Setup();
    }

    public void OnClickNext()
    {
        Data.CurrentLevel++;
        GameManager.Instance.ReturnHome();
    }
}

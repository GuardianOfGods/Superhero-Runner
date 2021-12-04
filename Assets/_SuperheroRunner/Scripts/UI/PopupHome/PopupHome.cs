using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : Popup
{
    public GameObject SoundOffImg;
    public GameObject VibrationOffImg;
    public GameObject Tutorial;
    public GameObject SettingBar;
    public ButtonUpgradeLevel ButtonUpgradeLevel;
    public ButtonUpgradePower ButtonUpgradePower;
    public ProgressLevel ProgressLevel;

    private bool isOpenSetting = false;

    public void Start()
    {
        EventController.DiamondTotalChanged += SetupUpgradeBtns;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        Setup();
        ProgressInGame.Instance.gameObject.SetActive(false);
    }
    public void Setup()
    {
        SoundOffImg.SetActive(!Data.SoundState);
        VibrationOffImg.SetActive(!Data.VibrateState);
        ProgressLevel.Setup();
        Tutorial.SetActive(true);
        SetupUpgradeBtns();
    }

    public void SetupUpgradeBtns()
    {
        int costlevel = ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1);
        ButtonUpgradeLevel.Setup(Data.DiamondTotal<costlevel);
        int costPower = ConfigController.Game.GetCostToUpgradePower(Data.PlayerPower + 1);
        ButtonUpgradePower.Setup(Data.DiamondTotal<costPower);
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
        Tutorial.SetActive(false);
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
        ProgressInGame.Instance.gameObject.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void OnClickLevelUpgrade()
    {
        int cost = ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1);
        if (Data.DiamondTotal >= cost)
        {
            if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
            Data.DiamondTotal -= cost;
            Data.PlayerLevel++;
            LevelController.Instance.CurrentLevel.Player.UpdatePlayerLevel();
        }

        SetupUpgradeBtns();
    }
    
    public void OnClickPowerUpgrade()
    {
        if (Data.PlayerPower == 12) return;
        int cost = ConfigController.Game.GetCostToUpgradePower(Data.PlayerPower + 1);
        if (Data.DiamondTotal >= cost)
        {
            if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
            Data.DiamondTotal -= cost;
            Data.PlayerPower++;
            LevelController.Instance.CurrentLevel.Player.UpdatePlayerPower();
        }

        SetupUpgradeBtns();
    }

    public void OnClickNext()
    {
        Data.CurrentLevel++;
        GameManager.Instance.ReturnHome();
    }

    public void OnClickAddDiamond()
    {
        Data.DiamondTotal += 500;
    }

    public void OnChangSizeSettingBar()
    {
        if (!isOpenSetting)
        {
            SettingBar.GetComponent<RectTransform>().sizeDelta = new Vector2(113,454);
        }
        else
        {
            SettingBar.GetComponent<RectTransform>().sizeDelta = new Vector2(113,140);
        }

        isOpenSetting = !isOpenSetting;
    }
}

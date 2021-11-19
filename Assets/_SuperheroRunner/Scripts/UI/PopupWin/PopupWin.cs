using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : Popup
{
    [Header("Component")]
    public DiamondGeneration DiamondGeneration;
    public TextMeshProUGUI TotalDiamondWinText;

    //Data
    private Level currentLevel;
    private int diamondValue;
    private int levelDiamondGather;
    private float bonusPoint;
    private int totalDiamondWin;

    protected override void BeforeShow()
    {
        base.BeforeShow();
        currentLevel = LevelController.Instance.CurrentLevel;
        Setup();
    }

    protected override void AfterShown()
    {
        base.AfterShown();
        bool IsFirstCoinMoved = false;
        DiamondGeneration.GenerateCoin(() =>
        {
            if (!IsFirstCoinMoved)
            {
                IsFirstCoinMoved = true;
                Data.DiamondTotal += totalDiamondWin;
                Data.CurrentLevel++;
            }
        },null);
    }

    public void SetupData()
    {
        if (currentLevel.LevelType == LevelType.Normal)
        {
            diamondValue = ConfigController.Game.DiamondWinValueNormal;
        }
        else
        {
            diamondValue = ConfigController.Game.DiamondWinValueSpecial;
        }

        levelDiamondGather = currentLevel.DiamondGather;
        bonusPoint = currentLevel.BonusPoint;
        totalDiamondWin = (int) (diamondValue * bonusPoint) + levelDiamondGather;
    }

    public void SetupUI()
    {
        TotalDiamondWinText.text = $"+{totalDiamondWin}";
    }

    public void Setup()
    {
        SetupData();
        SetupUI();
    }

    public void OnClickNext()
    {
        GameManager.Instance.ReturnHome();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradeLevel : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI Cost;

    public void Setup()
    {
        SetupData();
        SetupUI();
    }

    public void SetupData()
    {
    }

    public void SetupUI()
    {
        LevelText.text = $"Lv. {Data.PlayerLevel + 1}";
        Cost.text = $"{ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1)}";
    }
}
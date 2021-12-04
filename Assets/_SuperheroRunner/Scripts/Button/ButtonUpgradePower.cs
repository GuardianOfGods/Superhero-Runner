using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradePower : MonoBehaviour
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
        if (Data.PlayerPower == 12)
        {
            LevelText.text = "Max level";
            return;
        }
        LevelText.text = $"X {2.2f + (Data.PlayerPower + 1) * 0.3f}";
        Cost.text = $"{ConfigController.Game.GetCostToUpgradePower(Data.PlayerPower + 1)}";
    }
}
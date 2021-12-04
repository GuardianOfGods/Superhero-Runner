using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradeLevel : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI Cost;
    public GameObject NormalBtn;
    public GameObject VideoBtn;

    public void Setup(bool isVideo)
    {
        NormalBtn.SetActive(!isVideo);
        VideoBtn.SetActive(isVideo);
        if (!isVideo)
        {
            LevelText.text = $"Lv. {Data.PlayerLevel + 1}";
            Cost.text = $"{ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1)}";
        }
        else
        {
            
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradePower : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI Cost;
    public GameObject NormalBtn;
    public GameObject VideoBtn;

    public void Setup(bool isVideo)
    {
        if (Data.PlayerPower == 12)
        {
            NormalBtn.SetActive(true);
            VideoBtn.SetActive(false);
            LevelText.text = "Max level";
            return;
        }
        NormalBtn.SetActive(!isVideo);
        VideoBtn.SetActive(isVideo);
        if (!isVideo)
        {
            LevelText.text = $"X {2.2f + (Data.PlayerPower + 1) * 0.3f}";
            Cost.text = $"{ConfigController.Game.GetCostToUpgradePower(Data.PlayerPower + 1)}";
        }
        else
        {
            
        }
    }
}
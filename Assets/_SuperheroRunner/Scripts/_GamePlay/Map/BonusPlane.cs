using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusPlane : MonoBehaviour
{
    [Header("Data")]
    public float BonusValue;
    public int LevelToReach;

    [Header("Components")]
    public List<Rigidbody> Bricks;
    public GameObject Canvas;
    public TextMeshProUGUI ValueText;

    private bool isBreak;

    public void TurnOnPhysicWall()
    {
        if (isBreak) return;
        isBreak = true;
        SoundController.Instance.PlayFX(SoundType.WallCrush);
        Bricks.ForEach(item=>item.isKinematic=false);
        Bricks[0].gameObject.SetActive(false);
        Canvas.SetActive(false);
    }

    public void SetupData(float bonusValue, int levelToReach)
    {
        BonusValue = bonusValue;
        LevelToReach = levelToReach;
    }

    public void SetupUI()
    {
        ValueText.text = $"X {BonusValue}";
    }

    public void Setup(float bonusValue, int levelToReach)
    {
        SetupData(bonusValue, levelToReach);
        SetupUI();
    }
        
}

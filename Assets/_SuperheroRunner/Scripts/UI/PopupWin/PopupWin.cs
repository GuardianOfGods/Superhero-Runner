using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : Popup
{
    [Header("Component")] 
    public TextMeshProUGUI TotalDiamondWinText;
    public GameObject OverLay;
    public List<Image> DiamondImages;
    public Transform DestinationPos;
    
    //Data
    private Level currentLevel => LevelController.Instance.CurrentLevel;
    private int diamondValue;
    private float bonusPoint;
    private int totalDiamondWin;
    public void OnEnable()
    {
        Setup();
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
        bonusPoint = currentLevel.BonusPoint;
        totalDiamondWin = (int) (diamondValue * bonusPoint);
    }

    public void SetupUI()
    {
        OverLay.SetActive(true);
        TotalDiamondWinText.text = totalDiamondWin.ToString();
        DiamondImages.ForEach(item=>item.transform.DOMove(DestinationPos.position,1f));
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            OverLay.SetActive(false);
        });
    }

    public void Setup()
    {
        SetupData();
        SetupUI();
    }

    public void OnClickNext()
    {
        
    }
}

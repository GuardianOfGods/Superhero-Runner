using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DiamondTotal : MonoBehaviour
{
    public TextMeshProUGUI DiamondTotalText;

    private int saveDiamond;
    private Sequence sequence;
    
    private void Start()
    {
        EventController.SaveDiamondTotal += SaveDiamondTotal;
        EventController.CurrentPlayerLevelChanged += UpdateCurrentTotalDiamond;

        UpdateCurrentTotalDiamond();
    }

    public void SaveDiamondTotal()
    {
        saveDiamond = Data.DiamondTotal;
    }

    public void UpdateDiamondTotalText()
    {
        DiamondTotalText.text = $"{Data.DiamondTotal + LevelController.Instance.CurrentLevel.DiamondAmount}";
    }

    public void UpdateCurrentTotalDiamond()
    {
        sequence = DOTween.Sequence().AppendCallback(()=>
        {
            DOTween.To(() => saveDiamond, x => saveDiamond = x, Data.DiamondTotal, 0.3f).OnUpdate(() =>
            {
                DiamondTotalText.text = saveDiamond.ToString();
            });
        });
    }
}

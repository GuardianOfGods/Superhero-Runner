using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DiamondTotal : MonoBehaviour
{
    public TextMeshProUGUI DiamondTotalText;
    private int currentTotalCoin;

    void Start()
    {
        currentTotalCoin = Data.DiamondTotal;
    }

    private void OnEnable()
    {
        DiamondTotalText.text = Data.DiamondTotal.ToString();
    }

    public void UpdateDiamondTotalText()
    {
        DiamondTotalText.text = $"{Data.DiamondTotal + LevelController.Instance.CurrentLevel.DiamondAmount}";
    }
}

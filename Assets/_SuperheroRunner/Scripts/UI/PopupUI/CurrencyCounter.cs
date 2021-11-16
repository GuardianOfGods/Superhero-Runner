using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CurrencyCounter : MonoBehaviour
{
    public TextMeshProUGUI CurrencyAmountText;
    public int StepCount = 10;
    public float DelayTime = .01f;

    private void Start()
    {
        EventController.diamondTotalChanged += UpdateCurrencyAmountText;
        CurrencyAmountText.text = Data.DiamondTotal.ToString();
    }
    
    private void UpdateCurrencyAmountText()
    {
        int currentCurrencyAmount = int.Parse(CurrencyAmountText.text);//100
        int nextAmount = (Data.DiamondTotal - currentCurrencyAmount)/StepCount;//(200 - 100)/10 = 10
        int step = StepCount;
        CurrencyTextCount(currentCurrencyAmount, nextAmount,step);
    }

    private void CurrencyTextCount(int currentCurrencyValue,int nextAmountValue,int stepCount)
    {
        if (stepCount == 0)
        {
            CurrencyAmountText.text = Data.DiamondTotal.ToString();
            return;
        }
        int totalValue = (currentCurrencyValue + nextAmountValue);
        DOTween.Sequence().AppendInterval(DelayTime).AppendCallback(() =>
        {
            CurrencyAmountText.text = totalValue.ToString();
        }).AppendCallback(()=>
        {
            CurrencyTextCount(totalValue, nextAmountValue, stepCount - 1);
        });
    }
}

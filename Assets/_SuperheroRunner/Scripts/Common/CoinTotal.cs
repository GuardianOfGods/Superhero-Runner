using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinTotal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinTotal;
    private int currentTotalCoin;
    public Sequence Sequence;
    
    void Start()
    {
        currentTotalCoin = Data.CoinTotal;
        coinTotal.text = Data.CoinTotal.ToString();
        EventController.SaveTotalCoin += SaveTotalCoin;
        EventController.CoinTotalChanged += UpdateCoinText;
    }

    private void OnEnable()
    {
        coinTotal.text = Data.CoinTotal.ToString();
    }

    public void SaveTotalCoin()
    {
        currentTotalCoin = Data.CoinTotal;
    }

    private void UpdateCoinText()
    {
        Sequence = DOTween.Sequence().AppendCallback(()=>
        {
            DOTween.To(() => currentTotalCoin, x => currentTotalCoin = x, Data.CoinTotal, 0.3f).OnUpdate(() =>
            {
                coinTotal.text = currentTotalCoin.ToString();
            });
        });
    }

    private void OnDisable()
    {
        if (Sequence != null)
        {
            Sequence.Kill();
        }
    }
}

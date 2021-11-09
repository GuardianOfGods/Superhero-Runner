using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public Image ProgressBar;
    public TextMeshProUGUI LoadingText;
    void Start()
    {
#if UNITY_EDITOR
        ProgressBar.DOFillAmount(1, 1f);
        DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
        {
            SceneManager.LoadScene(Constant.GAMEPLAY_SCENE);
        });
        return;
#endif
        
        ProgressBar.DOFillAmount(1, 5f);
        DOTween.Sequence().AppendInterval(5).AppendCallback(() =>
        {
            SceneManager.LoadScene(Constant.GAMEPLAY_SCENE);
        });
    }

    private void Update()
    {
        LoadingText.text = $"Loading {(int)(ProgressBar.fillAmount*100)}%";
    }
}

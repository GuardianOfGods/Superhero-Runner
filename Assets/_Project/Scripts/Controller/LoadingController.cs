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
            SceneManager.LoadScene(Constant.LOBBY_SCENE);
            PopupController.Instance.Show<PopupUI>();
            PopupController.Instance.Show<PopupHome>();
            return;
        #endif
        ProgressBar.DOFillAmount(1, 5f);
        DOTween.Sequence().AppendInterval(5).AppendCallback(() =>
        {
            SceneManager.LoadScene(Constant.LOBBY_SCENE);
            PopupController.Instance.Show<PopupUI>();
            PopupController.Instance.Show<PopupHome>();
        });
    }

    private void Update()
    {
        LoadingText.text = $"Loading {(int)(ProgressBar.fillAmount*100)}%";
    }
}

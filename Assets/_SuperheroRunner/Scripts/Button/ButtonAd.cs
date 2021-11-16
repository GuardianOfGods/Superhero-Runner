using System;
using UnityEngine;

public class ButtonAd : MonoBehaviour
{
    public ButtonCustom ButtonCustom;
    public GameObject LoadingImage;

    private void Start()
    {
        // if (AdController.Instance.IsRewardLoaded)
        // {
        //     HideLoading();
        // }
        // else
        // {
        //     ShowLoading();
        // }
    
    }
    
    private void ShowLoading()
    {
        LoadingImage.SetActive(true);
        ButtonCustom.canClick = false;
    }
    
    private void HideLoading()
    {
        LoadingImage.SetActive(false);
        ButtonCustom.canClick = true;
    }

    private void Update()
    {
        if (LoadingImage.activeSelf)
        {
            LoadingImage.transform.Rotate(Vector3.forward, -90f * Time.deltaTime);
        }
    }
}

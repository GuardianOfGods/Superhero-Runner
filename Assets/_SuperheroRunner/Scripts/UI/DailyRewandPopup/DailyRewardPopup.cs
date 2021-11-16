using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardPopup : Popup
{
    public DailyRewardItem CurrentItem;
    public GameObject X5VideoButton;
    public TextMeshProUGUI X5CoinText;
    public GameObject ClaimButton;
    public Image SkinIconImage;
    public List<DailyRewardItem> DailyRewardItems;

    public SkinData SkinData;
    
    protected override void BeforeShow()
    {
        base.BeforeShow();
        UpdateContent();
    }

    private void UpdateContent()
    {
        SetUpStateItems();

        if (CurrentItem.DayIndex == 7)
        {
            SkinIconImage.gameObject.SetActive(false);
            X5VideoButton.SetActive(false);
        }
        else
        {
            SkinData = ConfigController.SkinConfig.GetDailySkin();
            if (SkinData != null)
            {
                SkinIconImage.sprite = SkinData.Icon;
            }
            else
            {
                SkinIconImage.gameObject.SetActive(false);
            }
        }
        
        if (!Data.IsClaimedDailyReward())
        {
            X5CoinText.text = (CurrentItem.CoinValue * 5).ToString();
        }
        else
        {
            X5VideoButton.SetActive(false);
            ClaimButton.SetActive(false);
        }
    }

    private bool IsCurrentItem(int index)
    {
        return Data.DailyRewardDayIndex == index;
    }

    private void SetUpStateItems()
    {
        for (int i = 0; i < 7; i++)
        {
            DailyRewardItem item = DailyRewardItems[i];
            item.SetUp(i);
            if (IsCurrentItem(item.DayIndex))
            {
                CurrentItem = item;
            }
        }
    }

    public void OnClickX5CoinButton()
    {
        // AdController.Instance.ShowRewardedAd(() =>
        // {
        //     Data.LastDailyRewardClaim = DateTime.Now.ToString();
        //     Data.diamondTotal += CurrentItem.CoinValue * 5;
        // });
        UpdateContent();
    }

    public void OnClickClaimButton()
    {
        Data.LastDailyRewardClaim = DateTime.Now.ToString();
        Data.DiamondTotal += CurrentItem.CoinValue;
        if (CurrentItem.DayIndex == 7)
        {
            SkinData.IsUnlocked = true;
        }
        UpdateContent();
    }

    public void OnClickBack()
    {
        //PopupController.Instance.Show<HomePopup>();
        Hide();
    }
}
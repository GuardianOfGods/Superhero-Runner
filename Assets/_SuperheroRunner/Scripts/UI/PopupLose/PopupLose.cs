using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class PopupLose : Popup
{
    protected override void AfterShown()
    {
        base.AfterShown();
        Setup();
    }
    
    public void SetupData()
    {
       
    }

    public void SetupUI()
    {
        
    }

    public void Setup()
    {
        SetupData();
        SetupUI();
    }

    public void OnClickRetry()
    {
        if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
        GameManager.Instance.ReturnHome();
    }
}

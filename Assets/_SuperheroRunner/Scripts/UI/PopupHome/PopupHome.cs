using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : Popup
{
    public ButtonUpgradeLevel ButtonUpgradeLevel;

    protected override void BeforeShow()
    {
        base.BeforeShow();
        Setup();
    }

    public void Setup()
    {
        ButtonUpgradeLevel.Setup();
    }
    
    public void OnClickStart()
    {
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
        GameManager.Instance.StartGame();
    }

    public void OnClickLevelUpgrade()
    {
        int cost = ConfigController.Game.GetCostToUpgradeLevel(Data.PlayerLevel + 1);
        if (Data.DiamondTotal >= cost)
        {
            Data.DiamondTotal -= cost;
            
            
            
            
            
            
            
            
            
            
            
            
            Data.PlayerLevel++;
            LevelController.Instance.CurrentLevel.Player.UpdatePlayerLevel();
        }
        ButtonUpgradeLevel.Setup();
    }
}

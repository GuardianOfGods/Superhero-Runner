using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : Popup
{
    public void OnClickStart()
    {
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
        GameManager.Instance.StartGame();
    }
    
    public void Debugging()
    {
        
    }
}

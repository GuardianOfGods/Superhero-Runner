using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : Popup
{
    public void OnClickStart()
    {
        SceneManager.LoadScene(Constant.GAMEPLAY_SCENE);
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
    }
    
    public void Debugging()
    {
        
    }
}

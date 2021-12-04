using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLevel : MonoBehaviour
{
    public Image Progress;
    
    public void Setup()
    {
        Progress.fillAmount = (Data.CurrentLevel-1)%5 / 4f;
    }
}

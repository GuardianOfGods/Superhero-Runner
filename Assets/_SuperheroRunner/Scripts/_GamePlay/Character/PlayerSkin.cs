using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [Header("Dev Only")] 
    public PlayerController PlayerController;
    
    public GameObject LeftLeg;
    public GameObject RightLeg;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject Body;
    public GameObject Head;

    public void Start()
    {
        LeftLeg.SetActive(false);
        RightLeg.SetActive(false);
        LeftArm.SetActive(false);
        RightArm.SetActive(false);
        Body.SetActive(false);
        Head.SetActive(false);
        
        UpdateArmorParts();
    }

    public void UpdateArmorParts()
    {
        if (PlayerController.Level >= 10)
        {
            LeftLeg.SetActive(true);
            RightLeg.SetActive(true);
        }
        if (PlayerController.Level >= 20)
        {
            LeftArm.SetActive(true);
            RightArm.SetActive(true);
        }
        if (PlayerController.Level >= 50)
        {
            Body.SetActive(true);
        }
        if (PlayerController.Level >= 100)
        {
            Head.SetActive(true);
        }
    }
}

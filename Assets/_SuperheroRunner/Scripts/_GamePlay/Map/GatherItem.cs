using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class GatherItem : MonoBehaviour
{
    [Header("GD only")]
    public CodeAnimType CodeAnimType;
    [Header("Dev only")]
    public GatherItemType GatherItemType;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
            switch (GatherItemType)
            {
                case GatherItemType.Gem:
                    SoundController.Instance.PlayFX(SoundType.CollectGold);
                    DiamondSpawn.Instance.SpawnDiamond(transform);
                    break;
                case GatherItemType.Shield:
                    SoundController.Instance.PlayFX(SoundType.CollectArmor);
                    player.SuperPowerUp();
                    break;
                case GatherItemType.LevelUp:
                    
                    SoundController.Instance.PlayFX(SoundType.CollectArmor);
                    player.LevelUp(1);
                    break;
            }
            
            gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if (gameObject.activeSelf && CodeAnimType==CodeAnimType.RotateY)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        }
    }
}

public enum GatherItemType
{
    Gem,
    Shield,
    LevelUp
}

public enum CodeAnimType
{
    None,
    RotateY,
    Jump,
}
using System;
using System.Collections;
using System.Collections.Generic;
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
            switch (GatherItemType)
            {
                case GatherItemType.Gem:
                    SoundController.Instance.PlayFX(SoundType.CollectGold);
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
}

public enum CodeAnimType
{
    None,
    RotateY,
    Jump,
}
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Mallet : MonoBehaviour
{
    public GameObject Base;
    [Range(0.5f,3f)] public float time = 0.5f;

    private void Start()
    {
        DoRotateX();
    }

    public void DoRotateX()
    {
        Base.transform.DOLocalRotate(new Vector3(0, 0, 0), time).SetEase(Ease.Linear).OnComplete(() =>
        {
            Base.transform.DOLocalRotate(new Vector3(-90, 0, 0), time).SetEase(Ease.Linear).OnComplete(() =>
            {
                DoRotateX();
            });
        });
    }

    private void OnDestroy()
    {
        Base.transform.DOKill();
    }
}
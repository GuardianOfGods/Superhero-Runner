using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 2f;
    public float bounceTime = 3f;
    public float timePerScale = 0.05f;
        
    private float forceLose;

    private void Start()
    {
        forceLose = force / bounceTime;
    }

    public void DoBounce(float force)
    {
        Debug.Log(force);
        if (force <= 0)
        {
            transform.DOScale(new Vector3(3f, 3f, 3f), timePerScale);
            return;
        }
        float diff = force / 2;
        
        transform.DOScale(new Vector3(3f + diff, 3f - diff, 3f + diff), timePerScale).OnComplete(() =>
        {
            force -= forceLose;
            diff = force / 2;
            transform.DOScale(new Vector3(3f - diff, 3f + diff, 3f), timePerScale).OnComplete(() =>
            {
                DoBounce(force);
            });
            
        });
    }
    
    private void OnCollisionEnter(Collision other)
    {
        DoBounce(force);
    }
}

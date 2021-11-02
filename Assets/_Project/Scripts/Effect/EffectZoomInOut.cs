using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

public class EffectZoomInOut : MonoBehaviour
{
    public Vector3 CurrentScale;
    [Range(0,2f)]public float TimeDelay;
    [Range(.1f,2f)]public float SizeScale = .1f;
    [Range(0,2f)]public float TimeScale = .7f;

    public void OnEnable()
    {
        CurrentScale = transform.localScale;
        DoEffect(SizeScale,false);
    }

    public void DoEffect(float sizeScale, bool delay)
    {
        DOTween.Sequence().AppendInterval(TimeDelay*(delay ? 1 : 0)).AppendCallback(() =>
        {
            transform.DOScale(
                new Vector3(transform.localScale.x + sizeScale, transform.localScale.y + sizeScale,
                    transform.localScale.z),
                TimeScale).SetEase(Ease.Linear).OnComplete(() =>
            {
                DoEffect(-sizeScale,!delay);
            });
        });

    }
}

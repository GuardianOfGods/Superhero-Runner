using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TutorialGO : MonoBehaviour
{
    public GameObject Hand;
    private void OnEnable()
    {
        Hand.transform.localPosition = new Vector3(300,Hand.transform.localPosition.y,Hand.transform.localPosition.z);
        MoveHandX(-300, 300);
    }

    private void MoveHandX(float value1, float value2)
    {
        Hand.transform.DOLocalMoveX(value1, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveHandX(value2, value1);
        });
    }

    private void OnDisable()
    {
        Hand.transform.DOKill();
    }
}

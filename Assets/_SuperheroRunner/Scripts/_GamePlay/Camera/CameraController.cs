using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public GameObject RotationCamera;
    public GameObject Target;

    private LevelController LevelController => GameManager.Instance.LevelController;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeTarget(GameObject target)
    {
        Target = target;
    }
    
    private void LateUpdate()
    {
        if (Target!=null)
        {
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y+0.7f, Target.transform.position.z-1);
        }
    }

    public void MoveToTargetByTime(GameObject target, float time)
    {
        Target = null;
        Vector3 destinationPos = new Vector3(target.transform.position.x, target.transform.position.y + 0.7f,
            target.transform.position.z - 1);
        transform.DOMove(destinationPos, time).OnComplete(()=>Target = target);
    }
}

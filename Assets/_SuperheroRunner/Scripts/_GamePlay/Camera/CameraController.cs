using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject RotationCamera;

    private LevelController LevelController => GameManager.Instance.LevelController;

    private void LateUpdate()
    {
        if (LevelController.CurrentLevel!=null)
        {
            PlayerController player = LevelController.CurrentLevel.Player;
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-1);
        }
    }
}

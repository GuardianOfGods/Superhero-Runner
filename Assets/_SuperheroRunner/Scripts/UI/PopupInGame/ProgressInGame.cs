using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressInGame : Singleton<ProgressInGame>
{
    public Image Progress;
    public Image ChaseIcon;
    public void FixedUpdate()
    {
        if (LevelController.Instance.CurrentLevel)
        {
            float totalDistance = LevelController.Instance.CurrentLevel.Boss.transform.position.z;
            float playerZ = LevelController.Instance.CurrentLevel.Player.transform.position.z;
            Progress.fillAmount = playerZ / totalDistance;
            RectTransform rect = ChaseIcon.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(-230 + Progress.fillAmount * 500, 0, 0);
        }
    }
}
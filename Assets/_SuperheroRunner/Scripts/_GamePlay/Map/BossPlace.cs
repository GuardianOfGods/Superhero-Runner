using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlace : MonoBehaviour
{
    [Header("GD Only")] 
    public BossType ChoseBossType;

    [Header("Dev only")]
    public List<BossController> Bosses;
    public Transform PlayerPos;
    public Transform BossPos;

    private BossController CurrentBoss;
    public BossController GetBossByTypeChosen()
    {
        return Bosses.Find(boss => boss.BossType == ChoseBossType);
    }
    
    public void GenerateBoss()
    {
        Utility.Clear(BossPos.transform);
        BossController boss = GetBossByTypeChosen();
        GetComponentInParent<Level>().Boss = Instantiate(boss, BossPos);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.MoveToAPoint(PlayerPos.position);
            GameManager.Instance.LevelController.CurrentLevel.LevelState = LevelState.FinalCombat;
            CameraController.Instance.MoveToTargetByTime(GameManager.Instance.LevelController.CurrentLevel.Boss.transform.GetChild(0).gameObject,1f);
        }
    }
}

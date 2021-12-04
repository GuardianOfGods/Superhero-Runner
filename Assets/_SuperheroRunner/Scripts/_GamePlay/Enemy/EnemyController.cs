using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("GD only")]
    [Range(1,1000)]public int Level;

    [Header("Dev only")]
    public EnemyAnim EnemyAnim;
    public TextMeshProUGUI LevelText;
    public SphereCollider MainCollider;

    private void Start()
    {
        LevelText.text = $"Level {Level}";
    }
    
    public void OnDrawGizmos()
    {
        LevelText.text = $"Level {Level}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MainCollider.enabled = false;
            PlayerController player = other.GetComponent<PlayerController>();
            bool isPlayerRightSide = player.transform.position.x > transform.position.x;
            
            // Player Inviolable when gather shield
            if (player.PlayerState == PlayerState.Inviolable)
            {
                if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
                if (isPlayerRightSide)
                {
                    EnemyAnim.PlayDieLeft();
                }
                else
                {
                    EnemyAnim.PlayDieRight();
                }
                player.LevelUp(Level);
                return;
            }
            
            // Enemy win
            if (player.Level < Level)
            {
                if (isPlayerRightSide)
                {
                    EnemyAnim.PlayPunchLeft();
                    
                }
                else
                {
                    EnemyAnim.PlayPunchRight();
                }
                
                player.DieNormal(true);
            }
            // Player Win
            else
            {
                if (Data.VibrateState) MMVibrationManager.Haptic (HapticTypes.LightImpact);
                player.PlayerState = PlayerState.Attacking;
                player.LevelUp(Level);
                if (isPlayerRightSide)
                {
                    player.PunchRight();
                    EnemyAnim.PlayDieLeft();
                }
                else
                {
                    player.PunchLeft();
                    EnemyAnim.PlayDieRight();
                }
            }

            
        }
    }
}

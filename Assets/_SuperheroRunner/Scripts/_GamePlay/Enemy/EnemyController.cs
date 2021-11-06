using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("GD only")]
    [Range(1,1000)]public int Level;

    [Header("Dev only")]
    public EnemyAnim EnemyAnim;
    public TextMeshProUGUI LevelText;

    
    public void OnDrawGizmos()
    {
        LevelText.text = $"Level {Level}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            bool isPlayerRightSide = player.transform.position.x > transform.position.x;
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
                player.PlayerAnim.PlayDie();
            }
            // Player Win
            else
            {
                player.PlayerState = PlayerState.Attacking;
                player.LevelUp(Level);
                if (isPlayerRightSide)
                {
                    player.PlayerAnim.PlayPunchRight();
                    EnemyAnim.PlayDieLeft();
                }
                else
                {
                    player.PlayerAnim.PlayPunchLeft();
                    EnemyAnim.PlayDieRight();
                }
            }
        }
    }
}

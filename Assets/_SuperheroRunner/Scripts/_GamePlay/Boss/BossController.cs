using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("GD only")]
    [Range(1,1000)]public int Level;

    [Header("Dev only")] 
    public BossType BossType;
    public BossAnim BossAnim;
    public Rigidbody Rigid;
    public TextMeshProUGUI LevelText;

    public void DoHitedAway(float force)
    {
        Rigid.velocity = Vector3.forward*force;
        BossAnim.PlayHitAway();
    }

    public void DoRagDoll()
    {
        Rigid.constraints = RigidbodyConstraints.None;
        Rigid.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, .5f, LayerMask.GetMask("Wall")))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.red);
            BonusPlane bonusPlane = hit.transform.gameObject.GetComponent<BonusPlane>();
            bonusPlane.TurnOnPhysicWall();
            if (bonusPlane.LevelToReach+10 > GameManager.Instance.LevelController.CurrentLevel.Player.Level)
            {
                DoRagDoll();
            }
        }
    }
}

public enum BossType
{
    GoldThanos
}

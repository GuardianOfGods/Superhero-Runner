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

    public void DoHitAway(float force)
    {
        Rigid.velocity = Vector3.forward*force;
        BossAnim.PlayHitAway();
    }
    
}

public enum BossType
{
    GoldThanos
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public Collider MainCollider;
    public List<Collider> ListCol;
    public List<Rigidbody> ListRid;

    public void Start()
    {
        ListCol.AddRange(transform.GetChild(0).GetChild(0).GetComponentsInChildren<Collider>());
        ListRid.AddRange(transform.GetChild(0).GetChild(0).GetComponentsInChildren<Rigidbody>());
        Setup();
    }

    public void Setup()
    {
        for (int i = 0; i < ListCol.Count-1; i++)
        {
            for (int j = i + 1; j < ListCol.Count; j++)
            {
                Physics.IgnoreCollision(ListCol[i],ListCol[j]);
            }
        }
        for (int i = 0; i < ListCol.Count; i++)
        {
            ListRid[i].isKinematic = true;
        }
    }
    
    
    public void DoHitedAway(float force)
    {
        Rigid.velocity = Vector3.forward*force;
        BossAnim.PlayHitAway();
    }

    public void DoRagDoll()
    {
        Rigid.velocity = Vector3.zero;
        BossAnim.Animacer.Animator.enabled = false;
        ListCol.ForEach(item=>
        {
            item.enabled = false;
            item.enabled = true;
            //item.attachedRigidbody.velocity = Vector3.zero;
            //item.attachedRigidbody.angularVelocity = Vector3.zero;
        });
        ListRid.ForEach(item=>
        {
            item.isKinematic = false;
            //item.AddForce(Vector3.down);
        });
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Rigid.transform.position, Rigid.transform.TransformDirection(Vector3.back), out hit, .5f, LayerMask.GetMask("Wall")))
        {
            Debug.DrawRay(Rigid.transform.position, Rigid.transform.TransformDirection(Vector3.back) * hit.distance, Color.red);
            BonusPlane bonusPlane = hit.transform.gameObject.GetComponent<BonusPlane>();
            bonusPlane.TurnOnPhysicWall();
            if (bonusPlane.LevelToReach == Data.PlayerPower)
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

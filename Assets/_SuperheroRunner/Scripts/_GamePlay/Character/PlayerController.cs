using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("GD only")]
    [Range(1,100)] public float Speed;
    [Range(1, 10)] public float SpeedUpMultiple=1.5f;

    [Header("Dev only")] 
    [Range(1,10000)] public int Level;
    [Range(1,10000)] public float PunchForce = 10f;
    public PlayerState PlayerState;
    public PlayerSkin PlayerSkin;
    public PlayerAnim PlayerAnim;
    public Rigidbody Rigid;
    public TextMeshProUGUI LevelText;
    public bool IsOnTheAir;
    public List<Collider> ListCol;
    public List<Rigidbody> ListRid;
    public SphereCollider SphereCollider;
    
    private float _currentSpeed;
    private float _xPosFence = 0.49f;
    private PopupInGame popupInGame;

    public void Start()
    {
        popupInGame = PopupController.Instance.GetComponentInChildren<PopupInGame>();
        Level = Data.PlayerLevel;

        SetupRagdoll();
        _currentSpeed = Speed;
        LevelText.text = $"Level {Level}";
        PlayerState = PlayerState.Idle;
    }
    
    public void SetupRagdoll()
    {
        ListCol.AddRange(transform.GetChild(0).GetChild(1).GetComponentsInChildren<Collider>());
        ListRid.AddRange(transform.GetChild(0).GetChild(1).GetComponentsInChildren<Rigidbody>());
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
    
      
    public void DoRagDoll()
    {
        Rigid.velocity = Vector3.zero;
        PlayerAnim.Animacer.Animator.enabled = false;
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

    void FixedUpdate()
    {
        if (PlayerState == PlayerState.Idle )
        {
            PlayerAnim.PlayIdle();
        }
        if (!GameManager.Instance.IsPlayerCanMove()  || PlayerState == PlayerState.Landing || PlayerState==PlayerState.Die)
        {
            return;
        }    
        
        // Check grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, .1f, LayerMask.GetMask("Sea")))
        {
            DieRagdoll();
            return;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, .1f, LayerMask.GetMask("Ground")))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            if (IsOnTheAir) PlayerState = PlayerState.Landing;
            IsOnTheAir = false;
            if (PlayerState == PlayerState.Running)
            {
                PlayerAnim.PlayRun();
            }
            else if (PlayerState == PlayerState.Landing)
            {
                PlayerAnim.PlayLand();
                return;
            }
        }
        else
        {
            IsOnTheAir = true;
            PlayerState = transform.position.y > 0 ? PlayerState.Jumping : PlayerState.Falling; 
            if (PlayerState == PlayerState.Jumping)
            {
                PlayerAnim.PlayJump();
            }
            else
            {
                PlayerAnim.PlayFalling();
            }
        }

        
        float _hor = popupInGame.DaiDynamicJoystick.Horizontal;
        float _ver = popupInGame.DaiDynamicJoystick.Vertical;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _hor = Input.GetAxisRaw("Horizontal");
            _ver = Input.GetAxisRaw("Vertical");
        }
        else
        {
             if (popupInGame.DaiDynamicJoystick.isPointedDown)
            _ver = 1f;
        }
        
            _ver = 1f;
            Vector3 _moveDirection = new Vector3(_hor, 0.0f, 1);
            _moveDirection = _moveDirection.normalized;
            Move(_moveDirection);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xPosFence, _xPosFence),
                    transform.position.y, transform.position.z);
    }
  

    public void OnDrawGizmos()
    {
        LevelText.text = $"Level {Level}";
    }

    void Move(Vector3 moveDirection)
    {
        if(IsOnTheAir)
             moveDirection.y = Rigid.velocity.y - 0.01f * Time.deltaTime;

        Rigid.velocity = new Vector3(moveDirection.x*_currentSpeed*1.2f,moveDirection.y,_currentSpeed);
    }

    public void Jump(Vector3 forceAmount)
    {
        if (IsOnTheAir)
            return;
        SoundController.Instance.PlayFX(SoundType.Jump);
        Rigid.velocity = Vector3.zero;
        Rigid.AddForce(forceAmount, ForceMode.Impulse);
    }

    public void PunchLeft()
    {
        SoundController.Instance.PlayFX(SoundType.Punch);
        PlayerAnim.PlayPunchLeft();
    }

    public void PunchRight()
    {
        SoundController.Instance.PlayFX(SoundType.Punch);
        PlayerAnim.PlayPunchRight();
    }

    public void DieNormal()
    {
        if (PlayerState==PlayerState.Die) return;
        SoundController.Instance.PlayFX(SoundType.PlayerDie);
        PlayerAnim.PlayDie();
        GameManager.Instance.OnLoseGame();
    }

    public void DieRagdoll()
    {
        if (PlayerState==PlayerState.Die) return;
        SoundController.Instance.PlayFX(SoundType.PlayerDie);
        DoRagDoll();
        GameManager.Instance.OnLoseGame();
    }

    public void Flying()
    { 
        PlayerAnim.PlayFlying();
    }

    public void SuperPowerUp()
    {
        float currentSpeed = Speed;
        float currentRadius = SphereCollider.radius;
        SphereCollider.radius = 0.3f;
        Speed *= SpeedUpMultiple;
        Flying();
        DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
        {
            PlayerAnim.PlayRun();
            Speed = currentSpeed;
            SphereCollider.radius = currentRadius;
        });
    }

    public void LevelUp(int levelIncrease)
    {
        Level += levelIncrease;
        LevelText.text = $"Level {Level}";
        PlayerSkin.UpdateArmorParts();
        FxSpawnController.Instance.SpawnFX(FxType.LevelUp,transform.position,transform);
    }

    public void UpdatePlayerLevel()
    {
        Level = Data.PlayerLevel;
        LevelText.text = $"Level {Level}";
        PlayerSkin.UpdateArmorParts();
        FxSpawnController.Instance.SpawnFX(FxType.LevelUp,transform.position,transform);
    }

    public void MoveToAPoint(Vector3 pos) 
    {
        transform.DOMove(pos, .5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            PlayerAnim.PlayPunch();
        });
    }

    public void PunchBoss()
    {
        SoundController.Instance.PlayFX(SoundType.Punch);
        GameManager.Instance.LevelController.CurrentLevel.Boss.DoHitedAway(PunchForce);
    }
}

public enum PlayerState
{
    Idle,
    Die,
    Running,
    Attacking,
    Jumping,
    Falling,
    Landing,
    Inviolable,
}
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

    [Header("Dev only")] 
    [Range(1,10000)] public int Level;
    [Range(1,10000)] public float PunchForce = 10f;
    public PlayerState PlayerState;
    public PlayerAnim PlayerAnim;
    public Rigidbody Rigid;
    public TextMeshProUGUI LevelText;
    public bool IsOnTheAir;
    
    private float _currentSpeed;
    private float _xPosFence = 0.49f;
    private PopupInGame popupInGame;

    public void Start()
    {
        popupInGame = PopupController.Instance.GetComponentInChildren<PopupInGame>();
        Level = Data.PlayerLevel;
        
        _currentSpeed = Speed;
        LevelText.text = $"Level {Level}";
        PlayerState = PlayerState.Idle;
    }

    void FixedUpdate()
    {
        if (PlayerState == PlayerState.Idle)
        {
            PlayerAnim.PlayIdle();
        }
        if (!GameManager.Instance.IsPlayerCanMove()  || PlayerState == PlayerState.Landing)
        {
            return;
        }    
        
        // Check grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, .1f, LayerMask.GetMask("Sea")))
        {
            PlayerAnim.PlayDie();
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
            Vector3 _moveDirection = new Vector3(_hor, 0.0f, _ver);
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
        
        moveDirection = moveDirection.z * Vector3.forward + moveDirection.x * Vector3.right;
        moveDirection *= _currentSpeed;

        if(IsOnTheAir)
             moveDirection.y = Rigid.velocity.y - 0.01f * Time.deltaTime;

        Rigid.velocity = moveDirection;
    }
    
    public void Jump(Vector3 forceAmount)
    {
        if (IsOnTheAir)
            return;
        Rigid.velocity = Vector3.zero;
        Rigid.AddForce(forceAmount, ForceMode.Impulse);
    }

    public void LevelUp(int levelIncrease)
    {
        Level += levelIncrease;
        LevelText.text = $"Level {Level}";
    }

    public void UpdatePlayerLevel()
    {
        Level = Data.PlayerLevel;
        LevelText.text = $"Level {Level}";
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
}
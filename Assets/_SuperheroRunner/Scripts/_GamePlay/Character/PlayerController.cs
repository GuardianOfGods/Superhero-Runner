using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("GD only")]
    [Range(1,100)] public float Speed;

    [Header("Dev only")] 
    [Range(1,10000)] public int Level;
    public PlayerState PlayerState;
    public PlayerAnim PlayerAnim;
    public Rigidbody Rigid;
    public TextMeshProUGUI LevelText;
    
    private float _currentSpeed;
    //private bool _allowToMove { get { return (GameManager.Instance.currentGameState == GameState.PLAYING && state == LivingObjectState.LIVING); } }

    public void Start()
    {
        _currentSpeed = Speed;
        LevelText.text = $"Level {Level}";
    }

    void FixedUpdate()
    {
        if (PlayerState == PlayerState.Die || PlayerState == PlayerState.Idle)
        {
            return;
        }

            float _hor = PopupController.Instance.GetComponentInChildren<PopupInGame>().DaiDynamicJoystick.Horizontal;
        float _ver = PopupController.Instance.GetComponentInChildren<PopupInGame>().DaiDynamicJoystick.Vertical;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _hor = Input.GetAxisRaw("Horizontal");
            _ver = Input.GetAxisRaw("Vertical");
        }
        else
        {
             if (PopupController.Instance.GetComponentInChildren<PopupInGame>().DaiDynamicJoystick.isPointedDown)
            _ver = 1f;
        }
        
        if (_hor != 0 || _ver > 0)
        {
            _ver = 1f;
            Vector3 _moveDirection = new Vector3(_hor, 0.0f, _ver);
            _moveDirection = _moveDirection.normalized;
            Move(_moveDirection);
            
        }
    }

    public void OnDrawGizmos()
    {
        LevelText.text = $"Level {Level}";
    }

    void Move(Vector3 moveDirection)
    {
        // if (_animator != null)
        //     _animator.SetFloat("move", moveDirection.magnitude, smoothBlend, Time.deltaTime);
        
        PlayerAnim.PlayRun();
        moveDirection = moveDirection.z * Vector3.forward + moveDirection.x * Vector3.right;
        moveDirection *= _currentSpeed;

        // if(_isOnAir)
        //     moveDirection.y = _rigid.velocity.y - fallingSpeed * Time.deltaTime;

        Rigid.velocity = moveDirection;
    }

    public void LevelUp(int levelIncrease)
    {
        Level += levelIncrease;
        LevelText.text = $"Level {Level}";
    }
}

public enum PlayerState
{
    Idle,
    Die,
    Running,
    Attacking,
}
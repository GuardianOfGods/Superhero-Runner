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
    public bool IsOnTheAir;
    
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
        
        // Check grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, .05f, LayerMask.GetMask("Ground")))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            if (IsOnTheAir) PlayerState = PlayerState.Running;
            IsOnTheAir = false;
            if (PlayerState == PlayerState.Running)
            {
                PlayerAnim.PlayRun();
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
        
            _ver = 1f;
            Vector3 _moveDirection = new Vector3(_hor, 0.0f, _ver);
            _moveDirection = _moveDirection.normalized;
            Move(_moveDirection);
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
}

public enum PlayerState
{
    Idle,
    Die,
    Running,
    Attacking,
    Jumping,
    Falling,
}
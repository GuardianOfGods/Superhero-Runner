using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    
    public Animator Animator;
    public Rigidbody Rigid;
    
    
    private float _currentSpeed;
    //private bool _allowToMove { get { return (GameManager.Instance.currentGameState == GameState.PLAYING && state == LivingObjectState.LIVING); } }

    public void Start()
    {
        _currentSpeed = Speed;
    }

    void FixedUpdate()
    {
        
        // if (!_allowToMove)
        //     return;

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
        else
        {
            Move(Vector3.zero);
        }
    }
    
    void Move(Vector3 moveDirection)
    {
        // if (_animator != null)
        //     _animator.SetFloat("move", moveDirection.magnitude, smoothBlend, Time.deltaTime);

        moveDirection = moveDirection.z * Vector3.forward + moveDirection.x * Vector3.right;
        moveDirection *= _currentSpeed;

        // if(_isOnAir)
        //     moveDirection.y = _rigid.velocity.y - fallingSpeed * Time.deltaTime;

        Rigid.velocity = moveDirection;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnim : MonoBehaviour
{
    public PlayerController PlayerController;
    public AnimancerComponent Animacer;
    
    public AnimationClip Idle;
    public AnimationClip Run;
    public AnimationClip Die;
    public AnimationClip Fall;
    public AnimationClip Fly;
    public AnimationClip Jump;
    public AnimationClip Land;
    public ClipTransition _Punch;
    public AnimationClip PunchLeft;
    public AnimationClip PunchRight;
    
    
    public void PlayIdle()
    {
        if (!Animacer.IsPlaying(Idle))
        {
            Animacer.Play(Idle);
            PlayerController.PlayerState = PlayerState.Idle;
        }
    }
    
    public void PlayRun()
    {
        if (!Animacer.IsPlaying(Run) && PlayerController.PlayerState != PlayerState.Attacking)
        {
            Animacer.Play(Run);
            PlayerController.PlayerState = PlayerState.Running;
        }
    }
    
    public void PlayJump()
    {
        if (!Animacer.IsPlaying(Jump))
        {
            Animacer.Play(Jump);
            PlayerController.PlayerState = PlayerState.Jumping;
        }
    }
    
    public void PlayLand()
    {
        if (!Animacer.IsPlaying(Land))
        {
            PlayerController.PlayerState = PlayerState.Landing;
            var state = Animacer.Play(Land);
            state.Events.OnEnd = () =>
            {
                PlayerController.PlayerState = PlayerState.Running;
            };
            
        }
    }
    
    public void PlayFalling()
    {
        if (!Animacer.IsPlaying(Fall))
        {
            Animacer.Play(Fall);
            PlayerController.PlayerState = PlayerState.Falling;
        }
    }

    public void PlayDie()
    {
        Animacer.Play(Die);
        PlayerController.PlayerState = PlayerState.Die;
    }

    public void PlayPunch()
    {
        var state = Animacer.Play(_Punch);
        PlayerController.PlayerState = PlayerState.Attacking;
    }
    
    public void PlayPunchLeft()
    {
        var state = Animacer.Play(PunchLeft);
        PlayerController.PlayerState = PlayerState.Attacking;
        state.Events.OnEnd = () =>
        {
            PlayerController.PlayerState = PlayerState.Running;
        };
    }
    
    public void PlayPunchRight()
    {
       var state = Animacer.Play(PunchRight);
       PlayerController.PlayerState = PlayerState.Attacking;
       state.Events.OnEnd = () =>
       {
           PlayerController.PlayerState = PlayerState.Running;
       };
    }
}

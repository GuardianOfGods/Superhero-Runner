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
    public AnimationClip Punch;
    public AnimationClip PunchLeft;
    public AnimationClip PunchRight;

    public void PlayIdle()
    {
        Animacer.Play(Idle);
    }
    
    public void PlayRun()
    {
        if (!Animacer.IsPlaying(Run) && PlayerController.PlayerState!=PlayerState.Attacking) Animacer.Play(Run);
    }

    public void PlayDie()
    {
        Animacer.Play(Die);
    }

    public void PlayPunchLeft()
    {
        var state = Animacer.Play(PunchLeft);
        state.Events.OnEnd = () =>
        {
            PlayRun();
            PlayerController.PlayerState = PlayerState.Running;
        };
    }
    
    public void PlayPunchRight()
    {
       var state = Animacer.Play(PunchRight);
       state.Events.OnEnd = () =>
       {
           PlayRun();
           PlayerController.PlayerState = PlayerState.Running;
       };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnim : MonoBehaviour
{
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
        Animacer.Play(Run);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class EnemyAnim : MonoBehaviour
{
    public AnimancerComponent Animacer;
    
    public AnimationClip Idle;
    public AnimationClip DieLeft;
    public AnimationClip DieRight;
    public ClipTransition PunchLeft;
    public ClipTransition PunchRight;
    public void PlayIdle()
    {
        Animacer.Play(Idle);
    }
    
    public void PlayDieLeft()
    {
        Animacer.Play(DieLeft);
    }

    public void PlayDieRight()
    {
        Animacer.Play(DieRight);
    }

    public void PlayPunchLeft()
    {
        Animacer.Play(PunchLeft);
    }

    public void PlayPunchRight()
    {
        Animacer.Play(PunchRight);
    }
}

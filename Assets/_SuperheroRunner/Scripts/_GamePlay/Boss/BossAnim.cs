using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    public AnimancerComponent Animacer;
    
    public AnimationClip Idle;
    public AnimationClip HitAway;
    public AnimationClip Die;

    public void PlayIdle()
    {
        Animacer.Play(Idle);
    }
    
    public void PlayHitAway()
    {
        if (!Animacer.IsPlaying(HitAway)) Animacer.Play(HitAway);
    }

    public void PlayDie()
    {
        Animacer.Play(Die);
    }
}

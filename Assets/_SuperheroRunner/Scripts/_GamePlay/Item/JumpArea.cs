using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArea : MonoBehaviour
{
    [Header("GD only")] 
    [Range(.1f,100f)] public float Force = .1f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Jump(Vector3.up*Force);
        }
    }
}

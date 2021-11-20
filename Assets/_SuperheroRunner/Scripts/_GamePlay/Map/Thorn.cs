using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public GameObject Base;
    [Range(.1f,3f)]public float Speed = 1f;

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f * Speed);
    }
}

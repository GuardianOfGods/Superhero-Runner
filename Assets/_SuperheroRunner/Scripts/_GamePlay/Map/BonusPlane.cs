using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlane : MonoBehaviour
{
    public float value;
    
    public List<Rigidbody> Bricks;
    public GameObject Canvas;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Bricks.ForEach(item=>item.isKinematic=false);
            Bricks[0].gameObject.SetActive(false);
            Canvas.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject MainPoly;
    public List<Rigidbody> ListRigid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.PlayerState == PlayerState.Inviolable)
            {
                SoundController.Instance.PlayFX(SoundType.WallCrush);
                WallBroken();
                return;
            }
            if (player.Level >= 10)
            {
                if (player.transform.position.x > transform.position.x)
                {
                    player.PunchRight();
                }
                else
                {
                    player.PunchLeft();
                }
                SoundController.Instance.PlayFX(SoundType.WallCrush);
                WallBroken();
            }
            else
            {
                player.DieNormal(false);
            }
        }
    }

    public void WallBroken()
    {
        MainPoly.SetActive(false);
        ListRigid.ForEach(item=>
        {
            item.isKinematic = false;
            item.AddForce(Vector3.back * 20f);
            Destroy(item.gameObject,1f);
        });
    }
}

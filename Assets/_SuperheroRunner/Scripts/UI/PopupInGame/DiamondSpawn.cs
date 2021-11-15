using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DiamondSpawn : Singleton<DiamondSpawn>
{
    public GameObject DiamondPrefab;
    public Transform DestinationPos;
    
    public void SpawnDiamond(Transform spawnPos)
    {
        GameObject diamond = Instantiate(DiamondPrefab, UICamera.Instance.Camera.WorldToScreenPoint(spawnPos.position),Quaternion.identity,transform);
        diamond.transform.DOMove(DestinationPos.position, 1f).OnComplete(() => Destroy(DiamondPrefab));
    }
}

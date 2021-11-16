using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DiamondSpawn : Singleton<DiamondSpawn>
{
    public PopupInGame PopupInGame;
    public GameObject DiamondPrefab;
    public Transform DestinationPos;

    public void SpawnDiamond(Transform spawnPos)
    {
        Debug.Log(spawnPos);
        GameObject diamond = Instantiate(DiamondPrefab, spawnPos.position,Quaternion.identity,transform);
        diamond.transform.DOMove(DestinationPos.position, 1f).OnComplete(() =>
        {
            LevelController.Instance.CurrentLevel.DiamondAmount += ConfigController.Game.DiamondPerGather;
            PopupInGame.diamondTotal.UpdateDiamondTotalText();
            Destroy(DiamondPrefab);
        });
    }
}

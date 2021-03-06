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
        GameObject diamond = Instantiate(DiamondPrefab, spawnPos.position,Quaternion.identity,transform);
        diamond.transform.DOMove(DestinationPos.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            LevelController.Instance.CurrentLevel.DiamondGather += ConfigController.Game.DiamondPerGather;
            PopupInGame.diamondTotal.UpdateDiamondTotalText();
            DestroyImmediate(diamond);
        });
    }
}

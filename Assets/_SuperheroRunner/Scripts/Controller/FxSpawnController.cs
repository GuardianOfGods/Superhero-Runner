using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawnController : Singleton<FxSpawnController>
{
    public List<FxData> FxDatas;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public FxData GetFxByType(FxType type)
    {
        return FxDatas.Find(item => item.FxType == type);
    }

    public void SpawnFX(FxType fxType, Vector3 position, Transform parent)
    {
        FxData fxData = GetFxByType(fxType);
        GameObject obj = Instantiate(fxData.FxPrefab, parent, false);
        obj.transform.position = position;
        Destroy(obj, 3f);
    }
}

[Serializable]
public class FxData
{
    public FxType FxType;
    public GameObject FxPrefab;
    public AudioClip FxSound;
}

public enum FxType
{
    LevelUp,
}

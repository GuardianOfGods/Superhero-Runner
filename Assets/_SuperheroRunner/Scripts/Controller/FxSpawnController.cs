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

    public void SpawnFX(FxType fxType, Vector3 position, Transform parent, float destroyTime = 3f)
    {
        FxData fxData = GetFxByType(fxType);
        GameObject obj = Instantiate(fxData.FxPrefab, parent, false);
        obj.transform.position = position;
        Destroy(obj, destroyTime);
    }
    
    public void SpawnFX(FxType fxType, Transform parent, float destroyTime = 3f)
    {
        FxData fxData = GetFxByType(fxType);
        GameObject obj = Instantiate(fxData.FxPrefab, parent, false);
        Destroy(obj, destroyTime);
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
    SpeedUp,
    Punch,
    LeftFlameThrowback,
    RightFlameThrowback,
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Level CurrentLevel;
    public Level NextLevel;

    
    public void GenerateLevel(int indexLevel)
    {
        if (CurrentLevel != null)
        {
            Destroy(CurrentLevel.gameObject);
        }

        Level level = GetLevelByIndex(indexLevel);
        
        CurrentLevel = Instantiate(level);
        //NextLevel = GetLevelByIndex(indexLevel + 1);
    }

    public Level GetLevelByIndex(int indexLevel)
    {
        GameObject levelGO = Resources.Load($"Levels/Level_{indexLevel}") as GameObject;
        return levelGO.GetComponent<Level>();
    }
}

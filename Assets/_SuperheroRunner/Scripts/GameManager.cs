using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelController LevelController;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelController.GenerateLevel(Data.CurrentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("GD only")]
    [Range(1, 99)] public int NumberPlane = 1;
    public float PlaneDistance;
    
    [Header("DEV only")]
    public GameObject PlanePrefab;
    public GameObject FinalCombatPlacePrefab;
    public List<GameObject> RoadList;
    public GameObject BonusRoadPrefab;

    public void GenerateRoad()
    {
        RoadList.Clear();
        Utility.Clear(gameObject.transform);
        for (int i = 0; i < NumberPlane; i++)
        {
            GameObject plane = Instantiate(PlanePrefab, transform);
            plane.transform.position = new Vector3(0, 0, PlaneDistance * i);
            RoadList.Add(plane);
        }
        
        GameObject finalPlace = Instantiate(FinalCombatPlacePrefab, transform);
        finalPlace.transform.position = new Vector3(finalPlace.transform.position.x, finalPlace.transform.position.y, PlaneDistance * NumberPlane-0.93f);
        
        Instantiate(BonusRoadPrefab,new Vector3(BonusRoadPrefab.transform.position.x,BonusRoadPrefab.transform.position.y,finalPlace.transform.position.z+2), Quaternion.identity, transform);
    }
}
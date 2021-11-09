using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRoad : MonoBehaviour
{
    [Header("GD only")]
    [Range(1, 99)] public int NumberPlane = 1;
    public float PlaneDistance;
    
    [Header("DEV only")]
    public GameObject PlanePrefab;

    public List<GameObject> RoadList;
    
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
    }
}

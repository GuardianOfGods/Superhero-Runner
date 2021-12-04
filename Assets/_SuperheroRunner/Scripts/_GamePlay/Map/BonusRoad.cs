using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRoad : MonoBehaviour
{
    [Header("GD only")]
    [Range(1, 99)] public int NumberPlane = 1;
    public float PlaneDistance;
    [Range(1f, 100f)] public float ValueBonus = 1f;
    [Range(0.1f, 2f)] public float DistanceValueBonus = 0.3f;
    [Range(1, 100)] public int PowerToReach = 1;
    [Header("DEV only")]
    public BonusPlane PlanePrefab;
    public BonusPlane MaxPlanePrefab;

    public List<BonusPlane> RoadList;
    
    public void GenerateRoad()
    {
        RoadList.Clear();
        Utility.Clear(gameObject.transform);
        for (int i = 0; i < NumberPlane; i++)
        {
            BonusPlane plane = Instantiate(PlanePrefab, transform);
            plane.Setup(ValueBonus+DistanceValueBonus*i,i*PowerToReach);
            plane.transform.localPosition = new Vector3(0, 0, PlaneDistance * i);
            RoadList.Add(plane);
            if (i == NumberPlane - 1)
            {
                BonusPlane planeMax = Instantiate(MaxPlanePrefab, transform);
                planeMax.Setup(ValueBonus+DistanceValueBonus*(i+1),(i+1)*PowerToReach);
                planeMax.transform.localPosition = new Vector3(0, 0, PlaneDistance * (i+1));
                RoadList.Add(planeMax);
            }
        }
        
    }
}

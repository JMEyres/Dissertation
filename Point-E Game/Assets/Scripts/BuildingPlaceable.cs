using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour
{
    public bool IsPlaceable { get; private set; } = true;
    public List<GameObject> pointClouds;
    public List<GameObject> meshs;
    [Header("Required")] 
    public BuildingStats buildingStats;

    private void Awake()
    {
        buildingStats = GetComponent<BuildingStats>();
    }

    void OnTriggerStay(Collider _other)
    {
        IsPlaceable = false;
    }

    void OnTriggerExit(Collider _other)
    {
        IsPlaceable = true;
    }
}
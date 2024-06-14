using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour
{
    public bool IsPlaceable { get; private set; } = true;
    public List<GameObject> pointClouds;
    public Color placeable;
    public Color unPlaceable;
    
    public List<GameObject> meshs;
    [Header("Required")] 
    public BuildingStats buildingStats;

    private void Awake()
    {
        buildingStats = GetComponent<BuildingStats>();
    }

    void OnTriggerStay(Collider _other)
    {
        foreach (var pc in pointClouds)
        {
            pc.GetComponent<ParticleSystemRenderer>().material.color = unPlaceable;
        }
        IsPlaceable = false;
    }

    void OnTriggerExit(Collider _other)
    {
        foreach (var pc in pointClouds)
        {
            pc.GetComponent<ParticleSystemRenderer>().material.color = placeable;
        }
        IsPlaceable = true;
    }
}
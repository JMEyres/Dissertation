using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : MonoBehaviour
{
    public BuildingBase buildingBase;
    
    public GameObject buildingPrefab;
    public float buildingRange;
    public float buildingDamage;
    public float buildingFireRate;
    public float buildingBulletSpeed;
    public int buildingCost;

    private void Awake()
    {
        if(buildingBase != null)
        {
            buildingPrefab = buildingBase.buildingPrefab;
            buildingRange = buildingBase.buildingRange;
            buildingDamage = buildingBase.buildingDamage;
            buildingFireRate = buildingBase.buildingFireRate;
            buildingBulletSpeed = buildingBase.buildingBulletSpeed;
            buildingCost = buildingBase.buildingCost;
        }
    }
}

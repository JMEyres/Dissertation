using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : MonoBehaviour
{
    public List<BuildingBase> buildingBase;
    public BuildingBase startingBuildingBase;
    
    public GameObject buildingPrefab;
    public float buildingRange;
    public float buildingDamage;
    public float buildingFireRate;
    public float buildingBulletSpeed;
    public int buildingIncome;
    public int buildingCost;
    public float buildingXP;

    private int buildingLevel;

    private void Awake()
    {
        if(buildingBase != null)
        {
            startingBuildingBase = buildingBase[0];
            buildingPrefab = startingBuildingBase.buildingPrefab;
            buildingRange = startingBuildingBase.buildingRange;
            buildingDamage = startingBuildingBase.buildingDamage;
            buildingFireRate = startingBuildingBase.buildingFireRate;
            buildingBulletSpeed = startingBuildingBase.buildingBulletSpeed;
            buildingIncome = startingBuildingBase.buildingIncome;
            buildingCost = startingBuildingBase.buildingCost;
        }
    }

    private void Update()
    {
        if (buildingXP >= 10)
        {
            if (buildingLevel != buildingBase.Count) buildingLevel++;
            buildingXP = 0;
        }

        if(buildingBase != null)
        {
            buildingRange = buildingBase[buildingLevel].buildingRange;
            buildingDamage = buildingBase[buildingLevel].buildingDamage;
            buildingFireRate = buildingBase[buildingLevel].buildingFireRate;
            buildingBulletSpeed = buildingBase[buildingLevel].buildingBulletSpeed;
            buildingIncome = buildingBase[buildingLevel].buildingIncome;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeBuilding : MonoBehaviour
{
    private BuildingStats buildingStats;
    private float incomeCountdown = 0f;

    public bool enable = false;
    
    private void Awake()
    {
        if(buildingStats == null) buildingStats = GetComponent<BuildingStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable)
            return;
        incomeCountdown -= Time.deltaTime;

        if (incomeCountdown <= 0f)
        {
            GenerateIncome();
            incomeCountdown = 1f / buildingStats.buildingFireRate;
        }
    }

    private void GenerateIncome()
    {
        PlayerStats.money += buildingStats.buildingIncome;
        buildingStats.buildingXP++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingBase", order = 2)]

public class BuildingBase : ScriptableObject
{
    public GameObject buildingPrefab;
    public Material buildingMaterial;
    public float buildingRange;
    public float buildingDamage;
    public float buildingFireRate;
    public float buildingBulletSpeed;
    public int buildingIncome;
    public int buildingCost;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [Header("Building Prefabs")] 
    [SerializeField] private List<BuildingPlaceable> buildingList = new List<BuildingPlaceable>();

    private Dictionary<string, BuildingPlaceable> buildingPrefabs;

    private static BuildingManager instance;
    private static BuildingPlaceable placeableInstance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        buildingPrefabs = new Dictionary<string, BuildingPlaceable>();
        foreach (BuildingPlaceable BP in buildingList)
        {
            buildingPrefabs.Add(BP.gameObject.name, BP);
        }
        buildingList.Clear();
    }
    public static BuildingPlaceable CreateBuilding(string _buildingName)
    {
        var building = Instantiate(instance.buildingPrefabs[_buildingName]);
        building.transform.parent = instance.transform;
        return building;
    }

    public static BuildingPlaceable PlaceBuilding(string _buildingName)
    {
        if (PlayerStats.money >= instance.buildingPrefabs[_buildingName].price)
        {
            var building = CreateBuilding(_buildingName);
            PlayerStats.money -= building.price;
            //var buildingStats;
            building.enabled = false;
            foreach (var mesh in building.meshs)
                mesh.SetActive(true);
            foreach (var pointCloud in building.pointClouds)
                pointCloud.SetActive(false);
            return building;
        }
        else 
            return null;
    }
}

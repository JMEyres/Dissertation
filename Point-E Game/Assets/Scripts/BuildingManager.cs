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
        var building = CreateBuilding(_buildingName);
        //var buildingStats;
        building.enabled = false;
        //building.gameObject.SetActive(true);
        building.mesh.SetActive(true);
        building.pointCloud.SetActive(false);
        return building;
    }
}

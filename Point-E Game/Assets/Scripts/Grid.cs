using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("Grid Settings")] 
    [SerializeField] private float gridLerpTime;
    [SerializeField] private float gridOpacity;

    [Header("Required References")]
    [SerializeField] private Camera cam;
    [SerializeField] private Vector2 gridCellSize; // Should be equal to placeable size - i.e. 1x1 cube
    [SerializeField] private int gridW;
    [SerializeField] private int gridH;

    [Header("Colors")] 
    [SerializeField] private Color placeable;
    [SerializeField] private Color unPlaceable;

    [Header("Placeables")] 
    [SerializeField] private string selectedBuilding;
    
    private BuildingPlaceable placeableObject;
    private List<GameObject> placeableObjectModel;
    private List<GameObject> placeableObjectPointCloud;
    
    float placeableObjectRotation = 0;
    
    private bool buildingSelected; 
    private bool buildingPlaceable; 
    
    float gridLerpTimer;
    float lerpDirection;

    // Singleton
    static Grid instance;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    void OnDestroy()
    {
        instance = null;
    }

    private void Update()
    {
        ShowBuildingPreview();
        PlaceBuilding();
    }

    private void FixedUpdate()
    {
        if (placeableObject != null) 
            UpdatePreview();
    }

    void SetSelectedBuilding(string _buildingName)
    {
        selectedBuilding = _buildingName;
    }

    void ShowBuildingPreview()
    {
        if (placeableObject != null)
        {
            placeableObject.gameObject.SetActive(true);
            foreach (var mesh in placeableObject.meshs)
            {
                mesh.SetActive(false);
            }
        }
        else
        {
            if(selectedBuilding != "")
                placeableObject = BuildingManager.CreateBuilding(selectedBuilding);
        }
    }

    void UpdatePreview()
    {
        Ray cursorToGrid = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit cursorHit;
        
        if (Physics.Raycast(cursorToGrid, out cursorHit, 5000, 1 << 6))
        {
            var snappedPos = new Vector3(Mathf.Round(cursorHit.point.x / gridCellSize.x) * gridCellSize.x, cursorHit.point.y,
                Mathf.Round(cursorHit.point.z / gridCellSize.y) * gridCellSize.y);
            placeableObject.transform.position = snappedPos;
        }
    }

    void PlaceBuilding()
    {
        if (Input.GetMouseButtonDown(0) && placeableObject != null && buildingSelected && placeableObject.IsPlaceable)
        {
            var building = BuildingManager.PlaceBuilding(selectedBuilding);
            if(building != null)
            {
                building.transform.position = placeableObject.transform.position;
                building.transform.localRotation = placeableObject.transform.localRotation;

                Destroy(placeableObject.gameObject);
                buildingSelected = false;
                selectedBuilding = "";
            }
            else
            {
                Destroy(placeableObject.gameObject);
                buildingSelected = false;
                selectedBuilding = "";
            }
        }
    }

    public static void SelectBuilding(string _buildingName)
    {
        instance.SetSelectedBuilding(_buildingName);
        instance.buildingSelected = true;
    }
}

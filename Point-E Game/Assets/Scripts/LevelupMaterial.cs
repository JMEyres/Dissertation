using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelupMaterial : MonoBehaviour
{
    [SerializeField] private BuildingStats buildingStats;
    [SerializeField] private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        buildingStats = GetComponentInParent<BuildingStats>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material = buildingStats.buildingMaterial;
    }
}

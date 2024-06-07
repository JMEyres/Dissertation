using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour
{
    public bool IsPlaceable { get; private set; } = true;
    public GameObject pointCloud;
    public GameObject mesh;

    void OnTriggerStay(Collider _other)
    {
        var length = (transform.position - _other.transform.position).magnitude;
        var size = Mathf.Max(transform.localScale.x, _other.transform.localScale.x);

        if (length > size * 0.9f) return;
        IsPlaceable = !(length <= size * 0.9f);
    }

    void OnTriggerExit(Collider other)
    {
        IsPlaceable = true;
    }
}
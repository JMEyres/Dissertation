using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour
{
    public bool IsPlaceable { get; private set; } = true;

    void OnTriggerStay(Collider other)
    {
        var length = (transform.position - other.transform.position).magnitude;
        var size = Mathf.Max(transform.localScale.x, other.transform.localScale.x);

        if (length > size * 0.9f) return;
        IsPlaceable = !(length <= size * 0.9f);
    }

    void OnTriggerExit(Collider other)
    {
        IsPlaceable = true;
    }
}
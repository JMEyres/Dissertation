using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (target == null) target = GameObject.Find("Destination");
        HeadForDestination();
    }

    private void HeadForDestination()
    {
        Vector3 destination = target.transform.position;
        navAgent.SetDestination(destination);
    }
}

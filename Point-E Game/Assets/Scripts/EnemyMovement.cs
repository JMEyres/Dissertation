using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private GameObject target;
    //[SerializeField] private PlayerStats stats;

    private NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            target = GameObject.Find("Base");
        }
        
        HeadForDestination();
    }

    private void HeadForDestination()
    {
        Vector3 destination = target.transform.position;
        navAgent.SetDestination(destination);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Base")
        {
            PlayerStats.health-= 10;
            Destroy(gameObject);
        }

    }
}

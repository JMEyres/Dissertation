using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private GameObject target;

    private NavMeshAgent navAgent;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Base");
        }
        
        if(navAgent == null) navAgent = GetComponent<NavMeshAgent>();
        if(enemyStats == null) enemyStats = GetComponent<EnemyStats>();
        navAgent.speed = enemyStats.enemySpeed;

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

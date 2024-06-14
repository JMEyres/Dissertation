using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject waypointParent;
    [SerializeField] public List<GameObject> waypoints;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private GameObject target;
    [SerializeField] private AudioSource hitSound;
    private int targetIndex;

    private NavMeshAgent navAgent;

    void Start()
    {
        waypointParent = GameObject.Find("WaypointParent");
        if (hitSound == null) hitSound = GetComponent<AudioSource>();
        
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            waypoints.Add(waypointParent.transform.GetChild(i).gameObject);
        }
        
        if(navAgent == null) navAgent = GetComponent<NavMeshAgent>();
        if(enemyStats == null) enemyStats = GetComponent<EnemyStats>();
        navAgent.speed = enemyStats.enemySpeed;
        navAgent.acceleration = enemyStats.enemySpeed;
    }

    private void Update()
    {
        if (targetIndex >= waypoints.Count) target = GameObject.FindWithTag("Base");
        else target = waypoints[targetIndex];

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
            hitSound.Play();
            PlayerStats.health-= enemyStats.enemyDamage;
            Destroy(gameObject);
        }
        else
        {
            targetIndex++;
        }

    }
}

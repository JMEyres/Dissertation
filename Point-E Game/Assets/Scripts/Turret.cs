using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Attributes")]
    private float fireCountdown = 0f;
    
    [Header("Required Fields")]
    public string enemyTag = "Enemy";
    
    public Transform pivot;
    public float rotationSpeed = 10f;
    
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public BuildingStats buildingStats;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // repeat function 2 times a second
    }

    private void Awake()
    {
        if(buildingStats == null) buildingStats = GetComponent<BuildingStats>();
    }

    // Update is called once per frame
    void Update()
    {
       if(target == null)
           return;

       Vector3 dir = target.position - transform.position;
       Quaternion lookAt = Quaternion.LookRotation(dir);
       Vector3 rotation = Quaternion.Lerp(pivot.rotation, lookAt, Time.deltaTime * rotationSpeed).eulerAngles;

       pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);

       if (fireCountdown <= 0f)
       {
           Shoot();
           fireCountdown = 1f / buildingStats.fireRate;
       }

       fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance <= buildingStats.range)
            target = closestEnemy.transform;
        else
            target = null;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null) bullet.SetTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, buildingStats.range);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public List<EnemyBase> enemyBase;

    public int enemyType;
    public GameObject prefab;
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;
    public int enemyReward;

    private void Start()
    {
        if(enemyBase[enemyType] != null)
        {
            prefab = enemyBase[enemyType].prefab;
        }
        
        Instantiate(prefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyBase enemyBase;

    public GameObject prefabName;
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;
    
    void Awake()
    {
        if(enemyBase != null)
        {
            prefabName = enemyBase.prefabName;
            enemyHealth = enemyBase.enemyHealth;
            enemyDamage = enemyBase.enemyDamage;
            enemySpeed = enemyBase.enemySpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

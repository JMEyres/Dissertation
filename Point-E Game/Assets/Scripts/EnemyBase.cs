using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyBase", order = 1)]
public class EnemyBase : ScriptableObject
{
    public GameObject prefab;
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;
}

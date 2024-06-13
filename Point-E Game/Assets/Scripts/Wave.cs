using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Wave", order = 3)]

public class Wave : ScriptableObject
{
    [Header("Robot")]
    public int robotCount;
    public int robotHealth;
    public int robotDamage;
    public int robotSpeed;
    public int robotReward;
    public float robotSpawnInterval;
    
    [Header("Alien")]
    public int alienCount;
    public int alienHealth;
    public int alienDamage;
    public int alienSpeed;
    public int alienReward;
    public float alienSpawnInterval;
    
    [Header("Wolf")]
    public int wolfCount;
    public int wolfHealth;
    public int wolfDamage;
    public int wolfSpeed;
    public int wolfReward;
    public float wolfSpawnInterval;
}

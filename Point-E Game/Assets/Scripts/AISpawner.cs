using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3.5f;
    private float timer;
    
    void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            spawnEnemy(enemyPrefab);
            timer = 0;
        }
    }

    private void spawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, gameObject.transform);
    }
}

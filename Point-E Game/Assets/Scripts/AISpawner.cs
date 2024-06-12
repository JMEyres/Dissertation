using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3.5f;
    [SerializeField] private Vector2 spawnBoundsX;
    [SerializeField] private Vector2 spawnBoundsZ;
    [SerializeField] private List<EnemyBase> enemyTypes;
    private float timer = 0;

    private bool waveStart = false;
    private int waveCounter = 1;

    private int enemyCount;

    void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) && enemyCount == 0)
        {
            waveStart = true;
        }

        if (waveStart)
        {
            enemyCount = 5 * (waveCounter * 2);
            waveStart = false;
        }

        if (enemyCount > 0)
        {
            if (timer >= spawnInterval)
            {
                Debug.Log("SPAWN");
                spawnEnemy(enemyPrefab);
                timer = 0;
                enemyCount--;
            }

            if (enemyCount == 0)
            {
                waveCounter++;
            }
        }
    }

    private void spawnEnemy(GameObject _enemy)
    {
        GameObject newEnemy = Instantiate(_enemy, transform);
        var tempPos = newEnemy.transform.position;
        tempPos.x += UnityEngine.Random.Range(spawnBoundsX.x, spawnBoundsX.y);
        tempPos.z += UnityEngine.Random.Range(spawnBoundsZ.x, spawnBoundsZ.y);
        newEnemy.transform.position = tempPos;
    }
}

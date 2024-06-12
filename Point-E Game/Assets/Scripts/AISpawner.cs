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

    private void spawnEnemy(GameObject _enemy)
    {
        GameObject newEnemy = Instantiate(_enemy, transform);
        var tempPos = newEnemy.transform.position;
        tempPos.x += UnityEngine.Random.Range(spawnBoundsX.x, spawnBoundsX.y);
        tempPos.z += UnityEngine.Random.Range(spawnBoundsZ.x, spawnBoundsZ.y);
        newEnemy.transform.position = tempPos;
    }
}

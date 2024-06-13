using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float robotTimer = 0;
    private float alienTimer = 0;
    private float wolfTimer = 0;

    private bool waveOngoing = false;
    private bool waveFinished = false;
    private int waveCounter = 0;

    private int enemyCount;
    private int robotCount;
    private int alienCount;
    private int wolfCount;
    
    [SerializeField] private List<Wave> waves;
    void Start()
    {
        robotTimer = 0;
        alienTimer = 0;
        wolfTimer = 0;
    }

    private void Update()
    {
        if (robotCount != 0) robotTimer += Time.deltaTime;
        if (alienCount != 0) alienTimer += Time.deltaTime;
        if (wolfCount != 0) wolfTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) && enemyCount == 0 && waveCounter <= waves.Count)
        {
            waveOngoing = true;
            initWave(waveCounter);
        }

        if (waveOngoing)
        {
            spawnWave(waveCounter);
        }

        if (waveFinished)
        {
            waveOngoing = false;
            waveCounter++;
            waveFinished = false;
        }

    }

    private void spawnEnemy(GameObject _enemy, int _enemyType, float _enemyDamage, float _enemyHealth, float _enemySpeed, int _enemyReward)
    {
        GameObject newEnemy = Instantiate(_enemy, transform);
        EnemyStats ES = newEnemy.GetComponent<EnemyStats>();
        
        ES.enemyType = _enemyType;
        ES.enemyDamage = _enemyDamage;
        ES.enemyHealth = _enemyHealth;
        ES.enemySpeed = _enemySpeed;
        ES.enemyReward = _enemyReward;
    }

    private void initWave(int wave)
    {
        robotCount = waves[wave].robotCount;
        alienCount = waves[wave].alienCount;
        wolfCount = waves[wave].wolfCount;
        
    }

    private void spawnWave(int _wave)
    {
        var wave = waves[_wave];
        enemyCount = robotCount + alienCount + wolfCount;
        if (robotCount > 0)
        {
            if (robotTimer >= wave.robotSpawnInterval)
            {
                spawnEnemy(enemyPrefab, 0, wave.robotDamage, wave.robotHealth, wave.robotSpeed, wave.robotReward);
                robotTimer = 0;
                robotCount--;
            }
        }
        if (alienCount > 0)
        {
            if (alienTimer >= wave.alienSpawnInterval)
            {
                spawnEnemy(enemyPrefab, 1, wave.alienDamage, wave.alienHealth, wave.alienSpeed, wave.alienReward);

                alienTimer = 0;
                alienCount--;
            }
        }
        if(wolfCount > 0)
        {
            if (wolfTimer >= wave.wolfSpawnInterval)
            {
                spawnEnemy(enemyPrefab, 2, wave.wolfDamage, wave.wolfHealth, wave.wolfSpeed, wave.wolfReward);
                wolfTimer = 0;
                wolfCount--;
            }
        }
        
        if(enemyCount == 0) waveFinished = true;
    }
}

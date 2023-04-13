using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetupFacade : MonoBehaviour
{
    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Timer timer;

    public void SetupLevel()
    {
        coinSpawner.SpawnCoins();
        coinSpawner.StartBouncing();

        enemySpawner.SpawnEnemies();
        enemySpawner.StartPatrolling();

        timer.StartTimer();
    }

    public void CompleteLevel()
    {
        coinSpawner.DespawnCoins();

        enemySpawner.DespawnEnemies();

        timer.DisplayEndTime();
    }
} 

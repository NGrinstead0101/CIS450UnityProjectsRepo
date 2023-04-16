/*
* Nick Grinstead
* LevelSetupFacade
* Assignment 11
* This class acts as a facade for a subsystem that sets up and clears out a level
* when it is opened or completed.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetupFacade : MonoBehaviour
{
    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Timer timer;

    bool isSetup = false;

    /// <summary>
    /// Called to spawn coins and enemies into a level, and to start the level timer
    /// </summary>
    public void SetupLevel()
    {
        if (!isSetup)
        {
            isSetup = true;

            coinSpawner.SpawnCoins();
            coinSpawner.StartBouncing();

            enemySpawner.SpawnEnemies();
            enemySpawner.StartPatrolling();

            timer.StartTimer();
        }
    }

    /// <summary>
    /// Called to despawn all coins and enemies, as well as to display the final
    /// time
    /// </summary>
    public void CompleteLevel()
    {
        if (isSetup)
        {
            isSetup = false;

            coinSpawner.DespawnCoins();

            enemySpawner.DespawnEnemies();

            timer.DisplayEndTime();
        }
    }
} 

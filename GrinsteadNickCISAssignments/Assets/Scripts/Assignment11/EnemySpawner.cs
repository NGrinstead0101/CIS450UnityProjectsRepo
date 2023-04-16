/*
* Nick Grinstead
* Enemy Spawner
* Assignment 11
* This class handles spawning and despawning enemies into a level, and can also
* make those enemies start patrolling.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Vector2> spawnPositions;
    ObjectPooler objectPool;
    private List<GameObject> enemyList = new List<GameObject>();
    private List<IEnumerator> enemyCoroutines = new List<IEnumerator>();

    /// <summary>
    /// Sets reference to the ObjectPooler
    /// </summary>
    private void Awake()
    {
        objectPool = ObjectPooler.uniqueInstance;
    }

    /// <summary>
    /// Spawns enemies at a list of specific points
    /// </summary>
    public void SpawnEnemies()
    {
        foreach (Vector2 spawnPoint in spawnPositions)
        {
            enemyList.Add(objectPool.SpawnFromPool("Enemy", spawnPoint, Quaternion.identity));
        }
    }

    /// <summary>
    /// Starts each enemy's Patrol() coroutine
    /// </summary>
    public void StartPatrolling()
    {
        foreach (GameObject enemy in enemyList)
        {
            IEnumerator temp = enemy.GetComponent<EnemyBehavior>().Patrol();
            enemyCoroutines.Add(temp);
            StartCoroutine(temp);
        }
    }

    /// <summary>
    /// Sends enemies back to the pool and stops their coroutines
    /// </summary>
    public void DespawnEnemies()
    {
        GameObject temp;

        for (int i = enemyList.Count - 1; i >= 0; --i)
        {
            temp = enemyList[i];
            enemyList.Remove(enemyList[i]);
            StopCoroutine(enemyCoroutines[i]);
            enemyCoroutines.Remove(enemyCoroutines[i]);
            objectPool.ReturnObjectToPool("Enemy", temp);
        }
    }
}

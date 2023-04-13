using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Vector2> spawnPositions;
    [SerializeField] GameObject enemyPrefab;
    private List<GameObject> enemyList;

    public void SpawnEnemies()
    {
        foreach (Vector2 spawnPoint in spawnPositions)
        {
            enemyList.Add(Instantiate(enemyPrefab, spawnPoint, Quaternion.identity));
        }
    }

    public void StartPatrolling()
    {
        foreach (GameObject enemy in enemyList)
        {
            //enemy.GetComponent<EnemyBehavior>().StartCoroutine(Patrol());
        }
    }

    public void DespawnEnemies()
    {
        GameObject temp;

        for (int i = enemyList.Count - 1; i >= 0; --i)
        {
            temp = enemyList[i];
            enemyList.Remove(enemyList[i]);
            Destroy(temp);
        }
    }
}

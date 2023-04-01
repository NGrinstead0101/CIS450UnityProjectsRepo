using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    private void Awake()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        Vector2 spawnPos;
        spawnPos.x = 10;

        while (true)
        {
            spawnPos.y = Random.Range(-3.5f, 3.5f);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}
/*
* Nick Grinstead
* ObstacleSpawner.cs
* Assignment 9
* This class handles spawning obstacles in random positions at a random time interval.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] CarContext carContext;

    /// <summary>
    /// Starts obstacle spawning coroutine
    /// </summary>
    private void Awake()
    {
        StartCoroutine(SpawnObstacle());
    }

    /// <summary>
    /// Spawns a new obstacle with a random y position every 0.5 to 1 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObstacle()
    {
        Vector2 spawnPos;
        spawnPos.x = 10;
        float seconds;

        while (true)
        {
            // Prevents obstacles from piling up if the player is stopped
            if (carContext.currentState != CarContext.stoppedState)
            {
                spawnPos.y = Random.Range(-3.5f, 3.5f);
                Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            }

            seconds = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(seconds);
        }
    }
}
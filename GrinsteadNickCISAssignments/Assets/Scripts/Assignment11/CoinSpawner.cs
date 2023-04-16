/*
* Nick Grinstead
* CoinSpawner
* Assignment 11
* This class handles spawning and despawning coins into a level, and can also 
* make those coins start bouncing up and down.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] List<Vector2> spawnPositions;
    ObjectPooler objectPool;
    private List<GameObject> coinList = new List<GameObject>();
    private List<IEnumerator> coinCoroutines = new List<IEnumerator>();

    /// <summary>
    /// Sets reference to the ObjectPooler
    /// </summary>
    private void Awake()
    {
        objectPool = ObjectPooler.uniqueInstance;
    }

    /// <summary>
    /// Spawns coins at a list of specific points
    /// </summary>
    public void SpawnCoins()
    {
        foreach (Vector2 spawnPoint in spawnPositions)
        {
            coinList.Add(objectPool.SpawnFromPool("Coin", spawnPoint, Quaternion.identity));
        }
    }

    /// <summary>
    /// Starts each coin's Bounce() coroutine
    /// </summary>
    public void StartBouncing()
    {
        foreach (GameObject coin in coinList)
        {
            IEnumerator temp = coin.GetComponent<CoinBehavior>().Bounce();
            coinCoroutines.Add(temp);
            StartCoroutine(temp);
        }
    }

    /// <summary>
    /// Sends coins back to the pool and stops their coroutines
    /// </summary>
    public void DespawnCoins()
    {
        GameObject temp;

        for (int i = coinList.Count - 1; i >= 0; --i)
        {
            temp = coinList[i];
            coinList.Remove(coinList[i]);
            StopCoroutine(coinCoroutines[i]);
            coinCoroutines.Remove(coinCoroutines[i]);
            objectPool.ReturnObjectToPool("Coin", temp);
        }
    }
}

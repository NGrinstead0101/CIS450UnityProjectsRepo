using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] List<Vector2> spawnPositions;
    [SerializeField] GameObject coinPrefab;
    private List<GameObject> coinList;

    public void SpawnCoins()
    {
        foreach (Vector2 spawnPoint in spawnPositions)
        {
            coinList.Add(Instantiate(coinPrefab, spawnPoint, Quaternion.identity));
        }
    }

    public void StartBouncing()
    {
        foreach (GameObject coin in coinList)
        {
            //coin.GetComponent<CoinBehavior>().StartCoroutine(Bounce());
        }
    }

    public void DespawnCoins()
    {
        GameObject temp;

        for (int i = coinList.Count - 1; i >= 0; --i)
        {
            temp = coinList[i];
            coinList.Remove(coinList[i]);
            Destroy(temp);
        }
    }
}

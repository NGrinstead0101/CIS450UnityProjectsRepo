/*
 * Nick Grinstead
 * SimpleProjectileFactory.cs
 * Assignment 5
 * This class is a simple factory that instantiates a projectile prefab based 
 * on a string input.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectileFactory : MonoBehaviour
{
    [SerializeField] GameObject[] projectilePrefabs = new GameObject[3];

    /// <summary>
    /// Handles instantiation of projectile objects
    /// </summary>
    /// <param name="type">The type of projectile to instantiate</param>
    public void SpawnProjectile(string type)
    {
        if (type == "Boulder")
        {
            Instantiate(projectilePrefabs[0], transform.position, Quaternion.identity);
        }
        else if (type == "Arrow")
        {
            Instantiate(projectilePrefabs[1], transform.position, Quaternion.Euler(0 , 0, -90));
        }
        else if (type == "Pebble")
        {
            Instantiate(projectilePrefabs[2], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Invalid type given");
        }
    }
}

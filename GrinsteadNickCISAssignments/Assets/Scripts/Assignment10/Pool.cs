/*
 * Nick Grinstead
 * Pool.cs
 * Assignment 10
 * This class is used by an ObjectPooler to create a pool of prefab GameObjects.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolTag;
    public GameObject prefab;
    public int poolSize;
}

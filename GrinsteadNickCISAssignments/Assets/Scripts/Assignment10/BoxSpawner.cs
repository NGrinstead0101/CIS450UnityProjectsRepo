/*
 * Nick Grinstead
 * BoxSpawner.cs
 * Assignment 10
 * This class calls an ObjectPooler to spawn and despawn box objects.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    GameObject activeBox;

    /// <summary>
    /// Sets reference to ObjectPooler and spawns a box
    /// </summary>
    private void Start()
    {
        objectPooler = ObjectPooler.uniqueInstance;

        activeBox = objectPooler.SpawnFromPool("Box", transform.position, Quaternion.identity);
    }

    /// <summary>
    /// If an input is given, despawn the current box and spawn a new one
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeBox != null)
            {
                DespawnBox();
            }

            activeBox = objectPooler.SpawnFromPool("Box", transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Called to despawn the active box
    /// </summary>
    public void DespawnBox()
    {
        objectPooler.ReturnObjectToPool("Box", activeBox);

        activeBox = null;
    }
}

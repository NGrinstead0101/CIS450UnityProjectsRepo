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
    public List<GameObject> activeBoxes = new List<GameObject>();

    /// <summary>
    /// Sets reference to ObjectPooler and spawns a box
    /// </summary>
    private void Start()
    {
        objectPooler = ObjectPooler.uniqueInstance;

        activeBoxes.Add(objectPooler.SpawnFromPool("Box", transform.position, Quaternion.identity));
    }

    /// <summary>
    /// If an input is given, despawn the current box and spawn a new one
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (activeBox != null)
            //{
            //    DespawnBox();
            //}

            GameObject tempBox = objectPooler.SpawnFromPool("Box", transform.position, Quaternion.identity);

            if (tempBox == null)
            {
                DespawnBox(activeBoxes[0]);

                tempBox = objectPooler.SpawnFromPool("Box", transform.position, Quaternion.identity);
            }

            activeBoxes.Add(tempBox);
        }
    }

    /// <summary>
    /// Called to despawn the active box
    /// </summary>
    public void DespawnBox(GameObject returnBox)
    {
        objectPooler.ReturnObjectToPool("Box", returnBox);

        activeBoxes.Remove(returnBox);
    }
}

/*
 * Nick Grinstead
 * KillPlane.cs
 * Assignment 10
 * This class is to be attached to a GameObject that will despawn any boxes that
 * touch it and send the player back to their initial position.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    [SerializeField] BoxSpawner boxSpawner;

    /// <summary>
    /// Despawns object if it's a box or respawns the player
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;

        if (temp.CompareTag("Box"))
        {
            boxSpawner.DespawnBox();
        }
        else if (temp.CompareTag("Player"))
        {
            temp.GetComponent<PlayerRespawn>().RespawnPlayer();
        }
    }
}

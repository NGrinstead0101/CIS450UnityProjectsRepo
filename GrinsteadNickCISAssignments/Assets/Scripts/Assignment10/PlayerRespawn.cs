/*
 * Nick Grinstead
 * PlayerRespawn.cs
 * Assignment 10
 * This class stores the player's initial position in order to respawn them there
 * if needed.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector2 spawnPos;

    /// <summary>
    /// Stores the player's initial position
    /// </summary>
    private void Awake()
    {
        spawnPos = transform.position;
    }

    /// <summary>
    /// Called by a KillPlane to return the player to their initial position
    /// </summary>
    public void RespawnPlayer()
    {
        transform.position = spawnPos;
    }
}

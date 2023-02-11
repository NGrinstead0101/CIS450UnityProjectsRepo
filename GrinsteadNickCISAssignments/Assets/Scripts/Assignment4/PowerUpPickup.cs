/*
 * Nick Grinstead
 * PowerUpPickup.cs
 * Assignment 4
 * This class will be attached to power-ups and give the player a new decorator
 * when collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    // Should be 0 for jump and 1 for dash
    [SerializeField] int powerUpType;

    [SerializeField] InputManager playerInputManager;

    /// <summary>
    /// If the player collides with the trigger, call GainPowerUp()
    /// </summary>
    /// <param name="collision">Data related to the collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInputManager.GainPowerUp(powerUpType);
        }
    }
}

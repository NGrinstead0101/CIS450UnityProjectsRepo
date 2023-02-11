/*
 * Nick Grinstead
 * Player.cs
 * Assignment 4
 * This class is the concrete player component that can be decorated.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerComponent
{
    /// <summary>
    /// Returns the player's base movement stats
    /// </summary>
    /// <returns>A Vector2 where x is dash force and y is jump force</returns>
    public override Vector2 GetStats()
    {
        return new Vector2(5, 5);
    }

    /// <summary>
    /// Returns the base for a string that will list a player's power-ups
    /// </summary>
    /// <returns>The initial string to be displayed as text</returns>
    public override string GetDescription()
    {
        return "Power-Ups Aquired: ";
    }
}

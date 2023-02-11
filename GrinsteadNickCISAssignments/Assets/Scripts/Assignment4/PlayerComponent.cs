/*
 * Nick Grinstead
 * PlayerComponent.cs
 * Assignment 4
 * This abstract class defines a player that can be decorated with stat modifying
 * power-ups.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent
{
    /// <summary>
    /// Retrieves the movement force for the player's abilities, dash and jump
    /// </summary>
    /// <returns>A Vector2 where x is dash force and y is jump force</returns>
    public abstract Vector2 GetStats();

    /// <summary>
    /// Retrieves a description of what power-ups the player has
    /// </summary>
    /// <returns>A string to be displayed as text</returns>
    public abstract string GetDescription();
}

/*
 * Nick Grinstead
 * JumpBoost.cs
 * Assignment 4
 * This class is a concrete decorator that acts as a jump height boosting 
 * power-up.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : PowerUpDecorator
{
    /// <summary>
    /// Constructor to initialize a JumpBoost decorating a PlayerComponent
    /// </summary>
    /// <param name="wrapObject">The object to be decorated</param>
    public JumpBoost(PlayerComponent wrapObject)
    {
        wrappedPlayerObj = wrapObject;
    }

    /// <summary>
    /// Adds a y value to the movement stats before returning them
    /// </summary>
    /// <returns>A Vector2 where x is dash force and y is jump force</returns>
    public override Vector2 GetStats()
    {
        return new Vector2(0, 3) + wrappedPlayerObj.GetStats();
    }

    /// <summary>
    /// Returns the power-up description plus "Jump Boost, "
    /// </summary>
    /// <returns>The string to be displayed as text</returns>
    public override string GetDescription()
    {
        return wrappedPlayerObj.GetDescription() + "Jump Boost, ";
    }
}

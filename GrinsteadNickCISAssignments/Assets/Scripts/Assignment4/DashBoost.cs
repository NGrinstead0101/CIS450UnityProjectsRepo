/*
 * Nick Grinstead
 * DashBoost.cs
 * Assignment 4
 * This class is a concrete decorator that acts as a dash distance boosting 
 * power-up.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoost : PowerUpDecorator
{
    /// <summary>
    /// Constructor to initialize a DashBoost decorating a PlayerComponent
    /// </summary>
    /// <param name="wrapObject">The object to be decorated</param>
    public DashBoost(PlayerComponent wrapObject)
    {
        wrappedPlayerObj = wrapObject;
    }

    /// <summary>
    /// Adds a x value to the movement stats before returning them
    /// </summary>
    /// <returns>A Vector2 where x is dash force and y is jump force</returns>
    public override Vector2 GetStats()
    {
        return new Vector2(3, 0) + wrappedPlayerObj.GetStats();
    }

    /// <summary>
    /// Returns the power-up description plus "Dash Boost, "
    /// </summary>
    /// <returns>The string to be displayed as text</returns>
    public override string GetDescription()
    {
        return wrappedPlayerObj.GetDescription() + "Dash Boost, ";
    }
}

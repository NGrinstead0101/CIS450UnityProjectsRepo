/*
 * Nick Grinstead
 * Pepperoni.cs
 * Assignment 6
 * This class represents a pepperoni topping to be instantiated.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperoni : Topping
{
    /// <summary>
    /// Picks a random position
    /// </summary>
    public override void ChoosePosition()
    {
        float xPos = Random.Range(-posParemeters.x, posParemeters.x);
        float yPos = Random.Range(-posParemeters.y, posParemeters.y);

        transform.position = new Vector2(xPos, yPos);
    }
}

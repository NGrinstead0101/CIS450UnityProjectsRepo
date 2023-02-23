/*
 * Nick Grinstead
 * Sausage.cs
 * Assignment 6
 * This class represents a sausage topping to be instantiated.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : Topping
{
    /// <summary>
    /// Picks a random position and scale
    /// </summary>
    public override void ChoosePosition()
    {
        float xPos = Random.Range(-posParemeters.x, posParemeters.x);
        float yPos = Random.Range(-posParemeters.y, posParemeters.y);

        transform.position = new Vector2(xPos, yPos);

        float randomScale = Random.Range(0.4f, 0.8f);
        transform.localScale = new Vector2(randomScale, randomScale);
    }
}

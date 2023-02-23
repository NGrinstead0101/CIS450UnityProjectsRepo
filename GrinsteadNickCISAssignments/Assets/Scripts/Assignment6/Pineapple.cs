/*
 * Nick Grinstead
 * Pineapple.cs
 * Assignment 6
 * This class represents a pineapple topping to be instantiated.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : Topping
{
    /// <summary>
    /// Picks a random position and rotation
    /// </summary>
    public override void ChoosePosition()
    {
        float xPos = Random.Range(-posParemeters.x, posParemeters.x);
        float yPos = Random.Range(-posParemeters.y, posParemeters.y);

        transform.position = new Vector2(xPos, yPos);

        float randomRotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, 0, randomRotation);
    }
}

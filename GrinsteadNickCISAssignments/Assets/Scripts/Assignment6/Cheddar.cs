/*
 * Nick Grinstead
 * Cheddar.cs
 * Assignment 6
 * This class represents a cheddar topping to be instantiated.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheddar : Topping
{
    /// <summary>
    /// Picks a random position and sets the alpha value
    /// </summary>
    public override void ChoosePosition()
    {
        float xPos = Random.Range(-posParemeters.x, posParemeters.x);
        float yPos = Random.Range(-posParemeters.y, posParemeters.y);

        transform.position = new Vector2(xPos, yPos);

        SpriteRenderer tempSR = GetComponent<SpriteRenderer>();
        Color tempColor = tempSR.color;
        tempColor.a = oppacity;
        tempSR.color = tempColor;
    }
}

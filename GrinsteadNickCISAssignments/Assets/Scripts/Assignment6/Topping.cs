/*
 * Nick Grinstead
 * Topping.cs
 * Assignment 6
 * This class represents an abstract topping prodcuct.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Topping : MonoBehaviour
{
    // Determines parameters for a random spawn position
    [SerializeField] protected Vector2 posParemeters;
    [SerializeField] protected float oppacity;

    /// <summary>
    /// Has logic to position, rotate, and/or scale the object when instantiated
    /// </summary>
    public abstract void ChoosePosition();
}

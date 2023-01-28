/*
 * Nick Grinstead
 * IMoveBehavior.cs
 * Assignment 2
 * This interface defines a behavior for moving.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehavior
{
    /// <summary>
    /// Will allow an object to move in some fashion.
    /// </summary>
    /// <param name="speed">The rate of movement</param>
    /// <param name="objectTransform">The transform to be affected</param>
    public void Move(float speed, Transform objectTransform);
}

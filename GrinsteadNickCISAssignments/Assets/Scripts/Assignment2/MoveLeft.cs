/*
 * Nick Grinstead
 * MoveLeft.cs
 * Assignment 2
 * This class defines the behavior for moving left.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : IMoveBehavior
{
    /// <summary>
    /// Translates an object to the left
    /// </summary>
    /// <param name="speed">The rate of movement</param>
    /// <param name="objectTransform">The transform to translate</param>
    public void Move(float speed, Transform objectTransform)
    {
        objectTransform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
    }
}

/*
 * Nick Grinstead
 * Rotate.cs
 * Assignment 2
 * This class defines the behavior for rotating.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : IMoveBehavior
{
    /// <summary>
    /// Rotates an object clockwise
    /// </summary>
    /// <param name="speed">The rate of rotation</param>
    /// <param name="objectTransform">The transform to rotate</param>
    public void Move(float speed, Transform objectTransform)
    {
        objectTransform.eulerAngles += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}

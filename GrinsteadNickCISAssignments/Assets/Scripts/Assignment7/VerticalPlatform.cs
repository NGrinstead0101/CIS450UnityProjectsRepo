/*
 * Nick Grinstead
 * VerticalPlatform.cs
 * Assignment 7
 * This concrete receiver is a platform that can move up or down.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : Receiver
{
    /// <summary>
    /// Moves the platform up or down
    /// </summary>
    /// <param name="direction">Direction of travel, should be 1 or -1</param>
    public override void Move(int direction)
    {
        Vector2 force = Vector2.up * direction * speed;

        GetComponent<Rigidbody2D>().velocity = force;
    }
}

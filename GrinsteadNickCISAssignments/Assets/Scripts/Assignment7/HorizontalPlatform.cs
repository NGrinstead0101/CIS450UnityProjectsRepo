/*
 * Nick Grinstead
 * HorizontalPlatform.cs
 * Assignment 7
 * This concrete receiver is a platform that can move right or left.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : Receiver
{
    /// <summary>
    /// Moves the platform right or left
    /// </summary>
    /// <param name="direction">Direction of travel, should be 1 or -1</param>
    public override void Move(int direction)
    {
        Vector2 force = Vector2.right * direction * speed;

        GetComponent<Rigidbody2D>().velocity = force;

    }
}

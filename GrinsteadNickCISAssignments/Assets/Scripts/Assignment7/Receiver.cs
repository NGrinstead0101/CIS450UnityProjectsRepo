/*
 * Nick Grinstead
 * Receiver.cs
 * Assignment 7
 * This abstract class represents a receiver object that can receive a command
 * to move.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{
    [SerializeField] protected float speed;

    /// <summary>
    /// Moves the object in some way
    /// </summary>
    /// <param name="direction">The direction of travel, will be 1 or -1</param>
    public abstract void Move(int direction);

    /// <summary>
    /// Returns this objects current position
    /// </summary>
    /// <returns>A Vector2 position</returns>
    public Vector2 GetPosition()
    {
        return gameObject.transform.position;
    }

    /// <summary>
    /// Sets this objects position when undoing a command
    /// </summary>
    /// <param name="position">This object's new position</param>
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    /// <summary>
    /// Stops movement when a command ends
    /// </summary>
    public void StopMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}


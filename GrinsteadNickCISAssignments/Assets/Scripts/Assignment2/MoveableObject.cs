/*
 * Nick Grinstead
 * MoveableObject.cs
 * Assignment 2
 * This abstract class defines an object that is capable of moving and changing
 * in size.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveableObject : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    IMoveBehavior moveBehavior;

    /// <summary>
    /// Sets moveBehavior to change how this object moves
    /// </summary>
    /// <param name="newBehavoir">The IMoveBehavior defining movement</param>
    public void SetMoveBehavoir(IMoveBehavior newBehavoir)
    {
        moveBehavior = newBehavoir;
    }

    /// <summary>
    /// Calls the Move() function of moveBehavior
    /// </summary>
    public void DoMove()
    {
        if (moveBehavior != null)
        {
            moveBehavior.Move(moveSpeed, transform);
        }
    }

    /// <summary>
    /// When implemented, will allow object to change its scale
    /// </summary>
    public abstract void ChangeSize();
}

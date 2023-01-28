/*
 * Nick Grinstead
 * Rectangle.cs
 * Assignment 2
 * This class represents a rectangle object that can move and grow.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : MoveableObject
{
    [SerializeField] float maxSize;

    /// <summary>
    /// Grows the object until it reaches a certain size
    /// </summary>
    public override void ChangeSize()
    {
        if (!(transform.localScale.x >= maxSize) || !(transform.localScale.y >= maxSize))
        {
            transform.localScale += new Vector3(moveSpeed, moveSpeed, 0) * Time.deltaTime;
        }
    }
}

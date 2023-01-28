/*
 * Nick Grinstead
 * Rhombus.cs
 * Assignment 2
 * This class represents a rhombus object that can move and shrink.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhombus : MoveableObject
{
    [SerializeField] float minSize;

    /// <summary>
    /// Shrinks the object until it reaches a certain size
    /// </summary>
    public override void ChangeSize()
    {
        if (!(transform.localScale.x <= minSize) || !(transform.localScale.y <= minSize))
        {
            transform.localScale -= new Vector3(moveSpeed, moveSpeed, 0) * Time.deltaTime;
        }
    }
}

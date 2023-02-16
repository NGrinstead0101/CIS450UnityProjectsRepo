/*
 * Nick Grinstead
 * Projectile.cs
 * Assignment 5
 * This class represents an abstract projectile product to be instantiated by
 * a simple factory.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile: MonoBehaviour
{
    [SerializeField] protected Vector2 moveVelocity;
    [SerializeField] protected int damage;

    /// <summary>
    /// Determines what the projectile does when it hits something
    /// </summary>
    public abstract void OnHit();
}

/*
 * Nick Grinstead
 * Pebble.cs
 * Assignment 5
 * This class represents a concrete pebble projectile product that deals low 
 * damage.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Projectile
{
    /// <summary>
    /// Adds initial force
    /// </summary>
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(moveVelocity, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Destroys this object
    /// </summary>
    public override void OnHit()
    {
        Debug.Log("A pebble has hit something");
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the collision when this projectile hits something
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyDamageDisplay>().TakeDamage(damage);
            }

            OnHit();
        }
    }
}

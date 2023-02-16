/*
 * Nick Grinstead
 * Arrow.cs
 * Assignment 5
 * This class represents a concrete arrow projectile product that deals damage and 
 * remains on hit before despawning.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
    /// <summary>
    /// Adds an initial force
    /// </summary>
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(moveVelocity, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Stops movement on hit and invokes DespawnArrow()
    /// </summary>
    public override void OnHit()
    {
        Debug.Log("An arrow has hit something");
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, 0);
        rb2d.gravityScale = 0;
        Invoke("DespawnArrow", 1f);
    }

    /// <summary>
    /// Handles the collision when this projectile hits something
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Arrow"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyDamageDisplay>().TakeDamage(damage);
            }

            OnHit();
        }
    }

    /// <summary>
    /// Destroys this game object
    /// </summary>
    private void DespawnArrow()
    {
        Destroy(gameObject);
    }
}

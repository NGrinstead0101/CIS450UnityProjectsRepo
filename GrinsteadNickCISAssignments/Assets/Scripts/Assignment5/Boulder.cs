/*
 * Nick Grinstead
 * Boulder.cs
 * Assignment 5
 * This class represents a concrete boulder projectile product that deals high 
 * damage and spawns a pebble on hit.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : Projectile
{
    [SerializeField] GameObject pebblePrefab;

    /// <summary>
    /// Adds initial force
    /// </summary>
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(moveVelocity, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Destroys this object and instantiates a pebble projectile
    /// </summary>
    public override void OnHit()
    {
        Debug.Log("A boulder has hit something");

        Rigidbody2D rb2d = 
            Instantiate(pebblePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();

        Vector2 randomVelocity = new Vector2(Random.Range(-5f, 5f), 5f);
        rb2d.velocity = randomVelocity;
        
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

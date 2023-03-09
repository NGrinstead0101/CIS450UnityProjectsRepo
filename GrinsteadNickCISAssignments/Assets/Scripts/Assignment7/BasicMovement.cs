/*
 * Nick Grinstead
 * BasicMovement.cs
 * Assignment 7
 * This script will be attached to a player object and handle inputs for 
 * walking and jumping.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    Rigidbody2D rb2d;

    bool canJump = true;

    /// <summary>
    /// Initialized rigidbody variable
    /// </summary>
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Reads input for movement
    /// </summary>
    void Update()
    {
        // Walk left
        if (Input.GetKey(KeyCode.A))
        {
            Walk(-1);
        }

        // Walk right
        if (Input.GetKey(KeyCode.D))
        {
            Walk(1);
        }

        // Stop walking
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Walk(0);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        // Reset Scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Sets the player's x velocity in a certain direction
    /// </summary>
    /// <param name="direction">The direction of travel</param>
    private void Walk(int direction)
    {
        float moveVelocity = direction * moveSpeed;

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
    }

    /// <summary>
    /// Adds a vertical force to the player
    /// </summary>
    private void Jump()
    {
        canJump = false;
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    /// <summary>
    /// Ensures the player can't jump once they're in the air
    /// </summary>
    /// <param name="collision">Data from a collision</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

    /// <summary>
    /// Ensures player can jump when standing on the ground
    /// </summary>
    /// <param name="collision">Data from a collision</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
        {
            canJump = true;
        }
    }
}

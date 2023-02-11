/*
 * Nick Grinstead
 * InputManager.cs
 * Assignment 4
 * This class tracks the PlayerComponent and uses its methods to update certain
 * values in addition to reading inputs for movement.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    PlayerComponent player;
    Vector2 initialPos;
    Rigidbody2D playerRb2d;
    bool canJump = false;

    Vector2 movementStats;
    [SerializeField] TextMeshProUGUI powerUpText;

    /// <summary>
    /// Initializes variables and the initial PlayerComponent
    /// </summary>
    private void Awake()
    {
        initialPos = transform.position;
        playerRb2d = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    /// <summary>
    /// Detects player inputs and calls the appropriate functions
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        Move();
    }

    /// <summary>
    /// Translates the player left or right if they press A or D
    /// </summary>
    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            transform.Translate(new Vector2(direction * 5 * Time.deltaTime, 0));
        }
        
    }

    /// <summary>
    /// Adds a force to the right based on the x value of movementStats
    /// </summary>
    private void Dash()
    {
        playerRb2d.AddForce(new Vector2(movementStats.x, 0), ForceMode2D.Impulse);
    }

    /// <summary>
    /// Adds a vertical force based on the y value of movementStats
    /// </summary>
    private void Jump()
    {
        canJump = false;
        playerRb2d.AddForce(new Vector2(0, movementStats.y), ForceMode2D.Impulse);
    }

    /// <summary>
    /// Creates a new Player script with no decorators and resets the object's
    /// position
    /// </summary>
    public void ResetPlayer()
    {
        player = new Player();
        transform.position = initialPos;
        UpdateStats();
    }

    /// <summary>
    /// To be called by PowerUpPickup script to give the player a new decorator
    /// </summary>
    /// <param name="powerUpIndex">An int representing the power-up gained, 
    /// 0 for JumpBoost and 1 for DashBoost</param>
    public void GainPowerUp(int powerUpIndex)
    {
        if (powerUpIndex == 0)
        {
            player = new JumpBoost(player);
        }
        else
        {
            player = new DashBoost(player);
        }
        UpdateStats();
    }

    /// <summary>
    /// Called when a decorator is added to update powerUpText and movementStats
    /// </summary>
    private void UpdateStats()
    {
        powerUpText.text = player.GetDescription();
        movementStats = player.GetStats();
    }

    /// <summary>
    /// Ensure the player can't jump when leaving the ground
    /// </summary>
    private void OnTriggerExit2D()
    {
        canJump = false;
    }

    /// <summary>
    /// Ensures the player can jump when touching the ground
    /// </summary>
    /// <param name="collision">Data related to the collision</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}

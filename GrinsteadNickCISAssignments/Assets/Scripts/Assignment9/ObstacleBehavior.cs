/*
* Nick Grinstead
* ObstacleBehavior.cs
* Assignment 9
* This class handles obstacle collisions and how they move across the screen.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] Vector2 moveForce;
    [SerializeField] Vector2 fasterMoveForce;
    [SerializeField] Vector2 boostMoveForce;
    Rigidbody2D rb2d;

    CarContext carContext;
    GameController gameController;

    /// <summary>
    /// Setting variables
    /// </summary>
    private void Awake()
    {
        carContext = GameObject.FindGameObjectWithTag("Player").GetComponent<CarContext>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = moveForce;
    }

    /// <summary>
    /// Updates obstacle velocity based on CarContext's state and despawns obstacles
    /// </summary>
    private void Update()
    {
        if (carContext.currentState == CarContext.stoppedState)
        {
            rb2d.velocity = Vector2.zero;
        }
        else if (carContext.currentState == CarContext.speed1State)
        {
            rb2d.velocity = moveForce;
        }
        else if (carContext.currentState == CarContext.speed2State)
        {
            rb2d.velocity = fasterMoveForce;
        }
        else
        {
            rb2d.velocity = boostMoveForce;
        }

        // If an obstacle leaves screen, destroy it and give points
        if (transform.position.x <= -11 && gameObject != null)
        {
            gameController.AddPoints();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Makes the player lose health if necessary and destroys the obstacle
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if player was hit when not boosting
        if (collision.gameObject.CompareTag("Player") && 
            collision.gameObject.GetComponent<CarContext>().currentState != CarContext.boostState)
        {
            gameController.LoseHealth();
        }

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}

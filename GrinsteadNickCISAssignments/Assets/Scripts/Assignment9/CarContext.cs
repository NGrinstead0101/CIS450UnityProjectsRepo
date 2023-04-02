/*
* Nick Grinstead
* CarContext.cs
* Assignment 9
* This class represents a car that changes between four states (stopped, boosting,
* speed 1, and speed2) and can steer up and down.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContext : MonoBehaviour
{
    public static State stoppedState;
    public static State speed1State;
    public static State speed2State;
    public static State boostState;

    public State currentState;

    [SerializeField] float maxDisplacement;
    [SerializeField] Rigidbody2D rb2d;

    bool canBoost = true;

    /// <summary>
    /// Initializing states and starting WaitTime()
    /// </summary>
    private void Awake()
    {
        stoppedState = new Stopped(this);
        speed1State = new Speed1(this);
        speed2State = new Speed2(this);
        boostState = new Boosting(this);

        currentState = speed1State;

        StartCoroutine(WaitTime());
    }

    /// <summary>
    /// Steers up and down and/or boosts when inputs are given
    /// </summary>
    void Update()
    {
        Vector2 moveForce = Vector2.zero;
        
        // Check for steering input
        if (Input.GetAxis("Vertical") != 0)
        {
            moveForce.y = Steer((int)Input.GetAxis("Vertical"));
            rb2d.velocity = moveForce;

            // Keeping car within maxDisplacement
            if (transform.position.y < -maxDisplacement)
            {
                rb2d.velocity = Vector2.zero;
                transform.position = new Vector2(transform.position.x, -maxDisplacement);
            }
            else if (transform.position.y > maxDisplacement)
            {
                rb2d.velocity = Vector2.zero;
                transform.position = new Vector2(transform.position.x, maxDisplacement);
            }
        }

        // Check for boost input
        if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost)
        {
            canBoost = false;
            StartCoroutine(BoostCooldown());
            Boost();
        }
    }

    /// <summary>
    /// Calls Steer() on currentState to return a velocity
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>A y velocity</returns>
    private float Steer(int direction)
    {
        return currentState.Steer(direction);
    }

    /// <summary>
    /// Calls boost on currentState
    /// </summary>
    private void Boost()
    {
        currentState.Boost();
    }

    /// <summary>
    /// Calls currentState's OnWait() every 3 seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            currentState.OnWait();
        }
    }

    /// <summary>
    /// Handles collision with obstacles by calling currentState's OnCollision()
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollision();
    }

    /// <summary>
    /// Called when boosting to enable 3 second cooldown
    /// </summary>
    /// <returns></returns>
    private IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(3f);

        canBoost = true;

        StopCoroutine(BoostCooldown());
    }
}

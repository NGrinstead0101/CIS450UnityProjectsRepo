/*
* Nick Grinstead
* Stopped.cs
* Assignment 9
* This state handles what CarContext can do when the car is stopped.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopped : State
{
    CarContext context;

    /// <summary>
    /// Constructor for this class
    /// </summary>
    /// <param name="context">The current CarContext</param>
    public Stopped(CarContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Returns 0 in order to not move
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>0 since the car isn't moving</returns>
    public float Steer(int direction)
    {
        Debug.Log("You can't drive when stopped");
        return 0;
    }

    /// <summary>
    /// Does nothing
    /// </summary>
    public void Boost()
    {
        Debug.Log("You can't boost when stopped");
    }

    /// <summary>
    /// Returns to the Speed 1 state
    /// </summary>
    public void OnWait()
    {
        Debug.Log("State is Speed1");
        context.currentState = CarContext.speed1State;
    }

    /// <summary>
    /// Does nothing
    /// </summary>
    public void OnCollision()
    {
        Debug.Log("You've already collided with something");
    }
}

/*
* Nick Grinstead
* Speed2.cs
* Assignment 9
* This state handles what CarContext can do when traveling at Speed 2.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed2 : State
{
    CarContext context;

    /// <summary>
    /// Constructor for this class
    /// </summary>
    /// <param name="context">The current CarContext</param>
    public Speed2(CarContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Returns a medium velocity for steering
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>A y velocity</returns>
    public float Steer(int direction)
    {
        // handle driving at speed 2
        return direction * 8;
    }

    /// <summary>
    /// Sets the state to boosting
    /// </summary>
    public void Boost()
    {
        Debug.Log("State is boost");
        context.currentState = CarContext.boostState;
    }

    /// <summary>
    /// Does nothing
    /// </summary>
    public void OnWait()
    {
        Debug.Log("You're already at max speed");
    }

    /// <summary>
    /// Sets the state to stopped
    /// </summary>
    public void OnCollision()
    {
        Debug.Log("State is stopped");
        context.currentState = CarContext.stoppedState;
    }
}

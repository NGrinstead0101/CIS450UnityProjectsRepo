/*
* Nick Grinstead
* Speed1.cs
* Assignment 9
* This state handles what CarContext can do when traveling at Speed 1.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed1 : State
{
    CarContext context;

    /// <summary>
    /// Constructor for this class
    /// </summary>
    /// <param name="context">The current CarContext</param>
    public Speed1(CarContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Returns a lower velocity for steering
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>A y velocity</returns>
    public float Steer(int direction)
    {
        return direction * 3;
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
    /// Sets the state to speed 2
    /// </summary>
    public void OnWait()
    {
        Debug.Log("State is Speed2");
        context.currentState = CarContext.speed2State;
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

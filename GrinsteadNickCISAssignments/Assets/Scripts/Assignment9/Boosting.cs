/*
* Nick Grinstead
* Boosting.cs
* Assignment 9
* This state handles what CarContext can do when boosting.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosting : State
{
    CarContext context;

    /// <summary>
    /// Constructor for this class
    /// </summary>
    /// <param name="context">The current CarContext</param>
    public Boosting(CarContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Returns a high velocity for steering
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>A y velocity</returns>
    public float Steer(int direction)
    {
        // handle driving at boost speed
        return direction * 15;
    }

    /// <summary>
    /// Does nothing
    /// </summary>
    public void Boost()
    {
        Debug.Log("You're already boosting");
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
    /// Does nothing
    /// </summary>
    public void OnCollision()
    {
        Debug.Log("You can't crash while boosting");
    }
}

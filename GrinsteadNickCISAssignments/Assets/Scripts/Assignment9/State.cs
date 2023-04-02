/*
* Nick Grinstead
* State.cs
* Assignment 9
* This interface represents a state that CarContext can be in.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    /// <summary>
    /// Handles how the car steers in this state
    /// </summary>
    /// <param name="direction">The direction of travel, up or down</param>
    /// <returns>A y velocity</returns>
    public abstract float Steer(int direction);

    /// <summary>
    /// Handles how the car boosts in this state
    /// </summary>
    public abstract void Boost();

    /// <summary>
    /// Handles what the car does when time passes in this state
    /// </summary>
    public abstract void OnWait();

    /// <summary>
    /// Handles what the car does on collision in this state
    /// </summary>
    public abstract void OnCollision();
}

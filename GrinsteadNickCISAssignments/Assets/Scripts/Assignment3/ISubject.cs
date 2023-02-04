/*
 * Nick Grinstead
 * RoomChange.cs
 * Assignment 3
 * This interface defines three methods for a Subject to track and update
 * Observers.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    /// <summary>
    /// Called by an Observer in order to start reveiving data
    /// </summary>
    /// <param name="observer">The Observer to be added</param>
    public void RegisterObserver(IObserver observer);

    /// <summary>
    /// Called by an Observer in order to stop receiving data
    /// </summary>
    /// <param name="observer">The Observer to be removed</param>
    public void RemoveObserver(IObserver observer);

    /// <summary>
    /// Used by the Subject to pass data to all Observers
    /// </summary>
    public void NotifyObservers();
}

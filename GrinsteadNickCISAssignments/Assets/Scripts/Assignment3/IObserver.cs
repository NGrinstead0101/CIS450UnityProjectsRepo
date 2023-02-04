/*
 * Nick Grinstead
 * RoomChange.cs
 * Assignment 3
 * This interface defines the method that allows Observers to reveive data.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    /// <summary>
    /// To be called by a Subject to pass an Observer data
    /// </summary>
    /// <param name="newRoom">Represents the room the player is in</param>
    /// <param name="roomName">The name of the room the player is in</param>
    public void UpdateData(int newRoom, string roomName);
}

/*
 * Nick Grinstead
 * UIData.cs
 * Assignment 3
 * This class acts as a Subject and will track what room the player is in and 
 * pass along that information to any Observers.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIData : MonoBehaviour, ISubject
{
    List<IObserver> observers = new List<IObserver>();
    int currentRoom = 0;
    [SerializeField] string[] roomNames;

    /// <summary>
    /// Adds an Observer to the list and then notifies all Observers
    /// </summary>
    /// <param name="observer">The Observer being added</param>
    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
        NotifyObservers();
    }

    /// <summary>
    /// Removes a specific Observer from the list
    /// </summary>
    /// <param name="observer">The Observer to be removed</param>
    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    /// <summary>
    /// Loops through all Observers and passes them data by calling UpdateData
    /// </summary>
    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateData(currentRoom, roomNames[currentRoom]);
        }
    }

    /// <summary>
    /// To be called by a RoomChange script to update currentRoom then notify all Observers
    /// </summary>
    /// <param name="newRoom">Represents the room the player is in</param>
    public void SetCurrentRoom(int newRoom)
    {
        currentRoom = newRoom;
        NotifyObservers();
    }
}

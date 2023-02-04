/*
 * Nick Grinstead
 * RoomDisplay.cs
 * Assignment 3
 * This class acts as an Observer and uses the data it reveives to update a text
 * object with the name of the room the player is in.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDisplay : MonoBehaviour, IObserver
{
    [SerializeField] UIData uiData;

    /// <summary>
    /// Registers this class as an Observer
    /// </summary>
    private void Awake()
    {
        uiData.RegisterObserver(this);
    }

    /// <summary>
    /// Called by a Subject to provide new data to update the room name text with
    /// </summary>
    /// <param name="newRoom">Represents the room the player entered</param>
    /// <param name="roomName">The name of the new room</param>
    public void UpdateData(int newRoom, string roomName)
    {
        GetComponent<TextMeshProUGUI>().text = roomName;
    }
}

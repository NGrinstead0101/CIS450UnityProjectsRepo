/*
 * Nick Grinstead
 * MapDisplay.cs
 * Assignment 3
 * This class acts as an Observer and will use the data it receives to update
 * icons on a map to depict where the player is.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour, IObserver
{
    [SerializeField] UIData uiData;
    SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer[] roomIcons;
    int currentRoom = 0;

    /// <summary>
    /// Sets up references and the initial state of the mini-map
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiData.RegisterObserver(this);

        Color tempColor = roomIcons[currentRoom].color;
        tempColor.a = 1f;
        roomIcons[currentRoom].color = tempColor;
    }

    /// <summary>
    /// Called by a Subject to provide new data to update the map with
    /// </summary>
    /// <param name="newRoom">Represents the room the player entered</param>
    /// <param name="roomName">The name of the new room</param>
    public void UpdateData(int newRoom, string roomName)
    {
        // Greys out previous room
        Color tempColor = roomIcons[currentRoom].color;
        tempColor.a = 0.5f;
        roomIcons[currentRoom].color = tempColor;

        currentRoom = newRoom;

        // Highlights new room
        tempColor = roomIcons[currentRoom].color;
        tempColor.a = 1f;
        roomIcons[currentRoom].color = tempColor;
    }

    /// <summary>
    /// Called by a button to hide or reveal the mini-map
    /// Also, unregisters and registers this class as an Observer
    /// </summary>
    public void ToggleMap()
    {
        if (spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            foreach (SpriteRenderer sr in roomIcons)
            {
                sr.enabled = false;
            }
            uiData.RemoveObserver(this);
        }
        else
        {
            spriteRenderer.enabled = true;
            foreach (SpriteRenderer sr in roomIcons)
            {
                sr.enabled = true;
            }
            uiData.RegisterObserver(this);
        }
    }
}

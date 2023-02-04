/*
 * Nick Grinstead
 * RoomChange.cs
 * Assignment 3
 * This class uses a trigger to update the UIData Subject whenever the player
 * enters a new room.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] int roomNum;
    [SerializeField] UIData uiData;

    /// <summary>
    /// Detects when the player enters a new room and calls SetCurrentRoom on UIData
    /// </summary>
    /// <param name="collision">Data from a collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiData.SetCurrentRoom(roomNum);
        }
    }
}

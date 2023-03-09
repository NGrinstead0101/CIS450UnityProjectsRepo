/*
 * Nick Grinstead
 * CommandSetter.cs
 * Assignment 7
 * This class will be attached to a player object and set what receiver object
 * the player is currently sending commands to.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetter : MonoBehaviour
{
    [SerializeField] PlayerInputsInvoker invoker;

    /// <summary>
    /// On colliding with a receiver, make it be the receiver being sent commands
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Receiver"))
        {
            invoker.SetCommands(collision.gameObject.GetComponent<Receiver>());
        }
    }

    /// <summary>
    /// When the player is no longer in contact with a receiver, stop sending it
    /// commands
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Receiver"))
        {
            invoker.SetCommands(null);
        }
    }
}

/*
 * Nick Grinstead
 * ReservedNPC.cs
 * Assignment 8
 * This concrete implementation of the template represents an NPC with one 
 * dialogue message.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ReservedNPC : DialogueTreeSuperclass
{
    [SerializeField] string message;
    [SerializeField] GameObject optionButton;

    /// <summary>
    /// Displays the message string
    /// </summary>
    protected override void DisplayMessage()
    {
        optionButton.SetActive(false);

        textObject.text = message;

        Invoke("GiveContinueInput", 2f);
    }

    /// <summary>
    /// Displays a "Stop Talking" option
    /// </summary>
    protected override void DisplayOptions()
    {
        optionButton.SetActive(true);
    }

    /// <summary>
    /// Displays a parting message
    /// </summary>
    protected override void DisplayPartingMessage()
    {
        optionButton.SetActive(false);

        textObject.text = "\"Our conversation may have been short, but it was nice talking to you!\"";
    }
}

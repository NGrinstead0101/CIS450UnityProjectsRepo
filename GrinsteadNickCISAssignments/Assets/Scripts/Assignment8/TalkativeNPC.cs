/*
 * Nick Grinstead
 * TalkativeNPC.cs
 * Assignment 8
 * This concrete implementation of the template represents an NPC with multiple
 * dialogue messages to cycle through.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkativeNPC : DialogueTreeSuperclass
{
    [SerializeField] string[] messageArray;
    private int messageIndex = 0;
    [SerializeField] GameObject[] optionButtons;
    bool optionSelection;

    /// <summary>
    /// Displays the current message pulled from messageArray
    /// </summary>
    protected override void DisplayMessage()
    {
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(false);
        }    

        textObject.text = messageArray[messageIndex];

        messageIndex++;
        messageIndex %= messageArray.Length;

        Invoke("GiveContinueInput", 2f);
    }

    /// <summary>
    /// Displays "Continue" and "Stop Talking" options
    /// </summary>
    protected override void DisplayOptions()
    {
        for (int i = 0; i < optionButtons.Length; ++i)
        {
            optionButtons[i].SetActive(true);
        }
    }

    /// <summary>
    /// Displays a parting message
    /// </summary>
    protected override void DisplayPartingMessage()
    {
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(false);
        }

        textObject.text = "\"Oh, it seems that I've finally run out of dialogue! Farewell!\"";
    }

    /// <summary>
    /// Override of the hook to change logic and reset messageIndex
    /// </summary>
    /// <returns>A bool that determines if the conversation ends</returns>
    protected override bool IsDoneTalking()
    {
        if (optionSelection)
        {
            messageIndex = 0;
        }

        return optionSelection;
    }

    /// <summary>
    /// Called by the "Continue" button to change what IsDoneTalking() returns
    /// </summary>
    /// <param name="option"></param>
    public void ButtonClicked(bool option)
    {
        optionSelection = option;
    }
}

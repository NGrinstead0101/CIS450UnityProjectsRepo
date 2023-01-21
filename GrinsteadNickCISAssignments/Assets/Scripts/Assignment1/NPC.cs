/*
 * Nick Grinstead
 * NPC.cs
 * Assigment 1 - OOP Review
 * This abstract class represents a non-player character with the ability to 
 * talk to the player.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI dialogueBox;

    /// <summary>
    /// When implemented, will allow NPC to talk by modifying the text of 
    /// dialogueBox
    /// </summary>
    public abstract void Talk();

    /// <summary>
    /// Coroutine that unhighlights an NPC and clears the dialogue text when
    /// an NPC has finished talking
    /// </summary>
    /// <returns>Waits for 5 seconds before clearing</returns>
    protected IEnumerator ResetText()
    {
        bool initialDelay = false;

        while (true)
        {
            // Only clears after 5 second delay has occurred
            if (initialDelay)
            {
                // Unhighlights NPC
                Color tempColor = GetComponent<SpriteRenderer>().color;
                tempColor.a = 0.5f;
                GetComponent<SpriteRenderer>().color = tempColor;

                dialogueBox.text = "";

                StopAllCoroutines();
            }
            else
            {
                initialDelay = true;
            }

            yield return new WaitForSeconds(5f);
        }
    }
 }

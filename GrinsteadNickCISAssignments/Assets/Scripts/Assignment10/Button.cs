/*
 * Nick Grinstead
 * Button.cs
 * Assignment 10
 * This class handles the behavior of a button that displays a congratulatory 
 * message when the player puts a box on it.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;

    /// <summary>
    /// Displays a message if a box is on the button
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            displayText.text = "Congratulations!\nYou got the box to the button!";
        }
    }

    /// <summary>
    /// Displays a message if a box is on the button
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            displayText.text = "Congratulations!\nYou got the box to the button!";
        }
    }

    /// <summary>
    /// Removes the message if a box is no longer on the button
    /// </summary>
    /// <param name="collision">Data related to a collision</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            displayText.text = "";
        }
    }
}

/*
* Nick Grinstead
* ButtonHandler.cs
* Assignment 12
* This class handles the logic for when a menu button is clicked.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] MenuComponent buttonComponent;
    [SerializeField] List<ButtonHandler> buttonHandlers = new List<ButtonHandler>();

    /// <summary>
    /// Called by the button when it is clicked
    /// </summary>
    public void ButtonClicked()
    {
        SetIsActive(!isActive);
    }

    /// <summary>
    /// Updates isActive before calling Reveal() or Hide() on a MenuButton
    /// </summary>
    /// <param name="active"></param>
    private void SetIsActive(bool active)
    {
        isActive = active;

        // For the Character Status button to update its "child" buttons
        foreach (ButtonHandler handler in buttonHandlers)
        {
            handler.isActive = isActive;
        }

        if (isActive)
        {
            buttonComponent.Reveal();
        }
        else
        {
            buttonComponent.Hide();
        }
    }
}

/*
 * Nick Grinstead
 * Reset.cs
 * Assignment 6
 * This class will be connected to a button that resets the scene.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    /// <summary>
    /// Reloads the scene when a button is clicked
    /// </summary>
    public void ResetButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
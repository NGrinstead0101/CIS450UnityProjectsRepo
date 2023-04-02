/*
* Nick Grinstead
* ButtonBehavior.cs
* Assignment 9
* This class handles the function of buttons for both the start menu and the
* game over menu.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// Loads the game scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Assignment9-StatePattern");
    }

    /// <summary>
    /// Resets the game scene
    /// </summary>
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Assignment9-StatePattern");
    }

    /// <summary>
    /// Loads the start menu
    /// </summary>
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StateGameMenu");
    }
}

/*
* Nick Grinstead
* GameController.cs
* Assignment 9
* This class handles general game functions such as updating UI, player health, 
* and score.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    static int highScore = 0;

    int currentScore = 0;
    int currentHealth = 3;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject gameEndUI;
    [SerializeField] TextMeshProUGUI highScoreText;

    /// <summary>
    /// Sets initial UI text
    /// </summary>
    private void Awake()
    {
        healthText.text = "Health: " + currentHealth;
        pointsText.text = "Points: " + currentScore;
        gameEndUI.SetActive(false);
    }

    /// <summary>
    /// Called by an obstacle to give the player points and update highScore as
    /// needed
    /// </summary>
    public void AddPoints()
    {
        currentScore += 10;
        pointsText.text = "Points: " + currentScore;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    /// <summary>
    /// Called by an obstacle to reduce player health and check the loss condition
    /// </summary>
    public void LoseHealth()
    {
        --currentHealth;
        healthText.text = "Health: " + currentHealth;

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            DisplayEndMessage();
        }
    }

    /// <summary>
    /// Displays the game over UI
    /// </summary>
    private void DisplayEndMessage()
    {
        gameEndUI.SetActive(true);
        highScoreText.text = "High Score: " + highScore + "\nScore: " + currentScore;
    }
}

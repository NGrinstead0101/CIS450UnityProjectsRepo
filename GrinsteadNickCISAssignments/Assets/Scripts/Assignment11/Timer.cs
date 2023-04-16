/*
* Nick Grinstead
* Timer
* Assignment 11
* This class handles starting and running the timer for a level. It dispays this
* time during the level, and also tells the user how long a level took.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    [SerializeField] TextMeshProUGUI timerText;

    /// <summary>
    /// Called to start the timer running at 0
    /// </summary>
    public void StartTimer()
    {
        currentTime = 0f;
        timerText.text = "Time: " + currentTime;
        StartCoroutine(UpdateTime());
    }

    /// <summary>
    /// Coroutine that updates the timer every 1 second
    /// </summary>
    /// <returns>1 second of wait time</returns>
    private IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            ++currentTime;
            timerText.text = "Time: " + currentTime;
        }
    }

    /// <summary>
    /// Called to stop the timer and display the final time
    /// </summary>
    public void DisplayEndTime()
    {
        StopAllCoroutines();

        timerText.text = "The level was completed in " + currentTime + " seconds!";
    }
}

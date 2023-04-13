using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI endText;

    public void StartTimer()
    {
        endText.text = "";
        currentTime = 0f;
        timerText.text = "Time: " + currentTime;
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            ++currentTime;
            timerText.text = "Time: " + currentTime;
        }
    }

    public void DisplayEndTime()
    {
        StopAllCoroutines();

        endText.text = "The level was completed in " + currentTime + " seconds!";
    }
}

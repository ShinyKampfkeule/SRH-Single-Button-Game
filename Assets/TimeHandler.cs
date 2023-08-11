using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler = null;

    public Text timerText = null;

    float total_time = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputHandler.timerStart)
        {
            total_time += Time.deltaTime;
            updateTimer();
        }
    }

    void updateTimer()
    {
        float minutes = Mathf.FloorToInt(total_time / 60);
        float seconds = Mathf.FloorToInt(total_time % 60);
        float milliseconds = total_time % 1 * 1000;
        TotalTime.totalTime = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
